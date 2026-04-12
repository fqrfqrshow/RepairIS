using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для добавления нового мастера.
    /// Соответствует прецеденту "Добавить мастера" из ТЗ.
    /// </summary>
    public partial class AddMasterForm : Form
    {
        private readonly RequestSystemFacade _facade;
        private bool _isEditMode;
        private Master _editingMaster;

        /// <summary>
        /// Конструктор для добавления нового мастера
        /// </summary>
        public AddMasterForm(RequestSystemFacade facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            _isEditMode = false;
            SetupForm();
        }

        /// <summary>
        /// Конструктор для редактирования существующего мастера
        /// </summary>
        public AddMasterForm(RequestSystemFacade facade, Master master) : this(facade)
        {
            _isEditMode = true;
            _editingMaster = master;
            LoadMasterData();
            this.Text = "Редактирование мастера";
            btnSave.Text = "Сохранить изменения";
        }

        private void SetupForm()
        {
            // Устанавливаем AcceptButton для удобства
            this.AcceptButton = btnSave;

            // Добавляем валидацию при вводе
            txtPhone.KeyPress += TxtPhone_KeyPress;
        }

        private void LoadMasterData()
        {
            if (_editingMaster != null)
            {
                txtName.Text = _editingMaster.Name;
                txtPhone.Text = _editingMaster.Phone;
                txtEmail.Text = _editingMaster.Email;
            }
        }

        #region Валидация

        private bool ValidateInputs()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Введите ФИО мастера!", txtName);
                return false;
            }

            if (txtName.Text.Length < 2)
            {
                ShowError("ФИО должно содержать не менее 2 символов!", txtName);
                return false;
            }

            // Проверка телефона
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowError("Введите телефон мастера!", txtPhone);
                return false;
            }

            if (!IsValidPhone(phone))
            {
                ShowError("Введите корректный номер телефона (например: +7 999 123-45-67 или 89991234567)", txtPhone);
                return false;
            }

            // Проверка email (если заполнен)
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                ShowError("Введите корректный email (например: master@repair.ru)", txtEmail);
                return false;
            }

            return true;
        }

        private bool IsValidPhone(string phone)
        {
            // Удаляем все пробелы, скобки, дефисы
            string cleaned = Regex.Replace(phone, @"[\s\-\(\)]", "");

            // Проверка: +7XXXXXXXXXX или 8XXXXXXXXXX или 9XXXXXXXXX
            Regex phoneRegex = new Regex(@"^(\+7|8|9)?\d{10}$");
            return phoneRegex.IsMatch(cleaned);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ShowError(string message, Control control = null)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (control != null)
            {
                control.Focus();
                // Исправление ошибки SelectAll
                if (control is TextBox textBox)
                {
                    textBox.SelectAll();
                }
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, +, пробел, дефис, скобки и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' '
                && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')'
                && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Сохранение

        private void Save()
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (_isEditMode)
                {
                    // Режим редактирования
                    _editingMaster.Name = txtName.Text.Trim();
                    _editingMaster.Phone = txtPhone.Text.Trim();
                    _editingMaster.Email = txtEmail.Text.Trim();

                    bool success = _facade.UpdateMaster(_editingMaster);

                    if (success)
                    {
                        MessageBox.Show($"Данные мастера {txtName.Text} успешно обновлены!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновлении данных мастера!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Режим добавления
                    var newMaster = new Master
                    {
                        Name = txtName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim()
                    };

                    int newId = _facade.SaveMaster(newMaster);

                    if (newId > 0)
                    {
                        MessageBox.Show($"Мастер {txtName.Text} успешно добавлен!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении мастера!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Обработчики событий

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddMasterForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем курсор в поле имени
            txtName.Focus();
        }

        #endregion
    }
}