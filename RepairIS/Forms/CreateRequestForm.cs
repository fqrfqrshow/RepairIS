using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма создания новой заявки на ремонт.
    /// Соответствует прецеденту "Создание заявки на ремонт" из ТЗ.
    /// </summary>
    public partial class CreateRequestForm : Form
    {
        private readonly int _userId;
        private readonly RequestSystemFacade _facade;
        private List<Machine> _userMachines;

        public CreateRequestForm(int userId, RequestSystemFacade facade)
        {
            _userId = userId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadUserMachines();
            SetupValidation();
        }

        private void SetupValidation()
        {
            // Подсказки для полей
            txtDescription.TextChanged += (s, e) => ValidateFields();
            txtContactPhone.TextChanged += (s, e) => ValidateFields();
            cmbMachines.SelectedIndexChanged += (s, e) => ValidateFields();

            // Валидация телефона при вводе
            txtContactPhone.KeyPress += TxtContactPhone_KeyPress;
        }

        private void TxtContactPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, +, пробел, дефис, скобки и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' '
                && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')'
                && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void ValidateFields()
        {
            bool isValid = cmbMachines.SelectedItem != null &&
                           !string.IsNullOrWhiteSpace(txtDescription.Text) &&
                           !string.IsNullOrWhiteSpace(txtContactPhone.Text);

            btnSave.Enabled = isValid;
        }

        private void LoadUserMachines()
        {
            try
            {
                _userMachines = _facade.GetMachines(_userId);

                cmbMachines.DisplayMember = "Model";
                cmbMachines.ValueMember = "Id";
                cmbMachines.DataSource = _userMachines.ToList();
                cmbMachines.SelectedIndex = -1;

                if (_userMachines.Count == 0)
                {
                    ShowInfo("У вас нет зарегистрированных станков. Добавьте новый станок!");
                    btnSave.Enabled = false;
                }
                else
                {
                    lblMachinesCount.Text = $"Доступно станков: {_userMachines.Count}";
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка загрузки станков: {ex.Message}");
            }
        }

        private void AddNewMachine()
        {
            using (var machineForm = new Form())
            {
                machineForm.Text = "Добавление нового станка";
                machineForm.Size = new System.Drawing.Size(450, 320);
                machineForm.StartPosition = FormStartPosition.CenterParent;
                machineForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                machineForm.MaximizeBox = false;
                machineForm.MinimizeBox = false;

                // Поле Модель
                var lblModel = new Label()
                {
                    Text = "Модель:*",
                    Location = new System.Drawing.Point(30, 30),
                    Size = new System.Drawing.Size(100, 25)
                };
                var txtModel = new TextBox()
                {
                    Location = new System.Drawing.Point(140, 30),
                    Size = new System.Drawing.Size(250, 22)
                };

                // Поле Серийный номер
                var lblSerial = new Label()
                {
                    Text = "Серийный номер:",
                    Location = new System.Drawing.Point(30, 70),
                    Size = new System.Drawing.Size(100, 25)
                };
                var txtSerial = new TextBox()
                {
                    Location = new System.Drawing.Point(140, 70),
                    Size = new System.Drawing.Size(250, 22)
                };

                // Поле Производитель
                var lblManufacturer = new Label()
                {
                    Text = "Производитель:",
                    Location = new System.Drawing.Point(30, 110),
                    Size = new System.Drawing.Size(100, 25)
                };
                var txtManufacturer = new TextBox()
                {
                    Location = new System.Drawing.Point(140, 110),
                    Size = new System.Drawing.Size(250, 22)
                };

                // Кнопки
                var btnOk = new Button()
                {
                    Text = "СОХРАНИТЬ",
                    Location = new System.Drawing.Point(100, 170),
                    Size = new System.Drawing.Size(120, 35),
                    BackColor = System.Drawing.Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };

                var btnCancel = new Button()
                {
                    Text = "ОТМЕНА",
                    Location = new System.Drawing.Point(240, 170),
                    Size = new System.Drawing.Size(100, 35),
                    BackColor = System.Drawing.Color.LightCoral,
                    FlatStyle = FlatStyle.Flat
                };

                btnCancel.Click += (s, e) => machineForm.Close();

                btnOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtModel.Text))
                    {
                        MessageBox.Show("Введите модель станка!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        var newMachine = new Machine
                        {
                            Model = txtModel.Text.Trim(),
                            SerialNumber = txtSerial.Text.Trim(),
                            Manufacturer = txtManufacturer.Text.Trim(),
                            OwnerId = _userId
                        };

                        int newId = _facade.SaveMachine(newMachine);

                        if (newId > 0)
                        {
                            MessageBox.Show($"Станок \"{newMachine.Model}\" успешно добавлен!",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            machineForm.Close();
                            LoadUserMachines();

                            // Выбираем добавленный станок
                            var addedMachine = _userMachines.FirstOrDefault(m => m.Id == newId);
                            if (addedMachine != null)
                            {
                                cmbMachines.SelectedItem = addedMachine;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении станка!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                machineForm.Controls.AddRange(new Control[]
                {
                    lblModel, txtModel,
                    lblSerial, txtSerial,
                    lblManufacturer, txtManufacturer,
                    btnOk, btnCancel
                });

                machineForm.ShowDialog();
            }
        }

        private void SaveRequest()
        {
            // Валидация
            if (cmbMachines.SelectedItem == null)
            {
                ShowWarning("Выберите станок!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowWarning("Введите описание проблемы!");
                txtDescription.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactPhone.Text))
            {
                ShowWarning("Введите контактные данные!");
                txtContactPhone.Focus();
                return;
            }

            // Проверка телефона
            if (!IsValidPhone(txtContactPhone.Text))
            {
                ShowWarning("Введите корректный номер телефона!");
                txtContactPhone.Focus();
                return;
            }

            // Проверка выбора способа осмотра
            if (!rbSelfDelivery.Checked && !rbMasterVisit.Checked)
            {
                ShowWarning("Выберите способ осмотра!");
                return;
            }

            try
            {
                var selectedMachine = (Machine)cmbMachines.SelectedItem;

                var newRequest = new Request
                {
                    MachineId = selectedMachine.Id,
                    ClientId = _userId,
                    Status = "Ожидает обработки",
                    Description = txtDescription.Text.Trim(),
                    ContactPhone = txtContactPhone.Text.Trim(),
                    InspectionMethod = rbSelfDelivery.Checked ? "сам привезёт" : "выезд мастера",
                    CreatedAt = DateTime.Now
                };

                int requestId = _facade.CreateOrder(newRequest);

                if (requestId > 0)
                {
                    MessageBox.Show($"Заявка №{requestId} успешно создана!\n\n" +
                        $"Станок: {selectedMachine.Model}\n" +
                        $"Описание: {txtDescription.Text}\n" +
                        $"Способ осмотра: {(rbSelfDelivery.Checked ? "сам привезёт" : "выезд мастера")}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowError("Ошибка при создании заявки!");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private bool IsValidPhone(string phone)
        {
            string cleaned = new string(phone.Where(c => char.IsDigit(c) || c == '+').ToArray());
            return cleaned.Length >= 10 && cleaned.Length <= 12;
        }

        #region Вспомогательные методы

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Обработчики событий

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            AddNewMachine();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRequest();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMachines.SelectedItem != null)
            {
                var machine = (Machine)cmbMachines.SelectedItem;
                lblSelectedMachine.Text = $"Выбран: {machine.Model} (SN: {machine.SerialNumber ?? "нет"})";
                lblSelectedMachine.Visible = true;
            }
            ValidateFields();
        }

        private void rbInspectionMethod_CheckedChanged(object sender, EventArgs e)
        {
            // Можно добавить дополнительную логику при выборе способа осмотра
        }

        #endregion
    }
}