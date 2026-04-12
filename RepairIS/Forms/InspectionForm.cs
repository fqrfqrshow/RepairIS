using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для проведения осмотра станка и фиксации результатов.
    /// Соответствует прецеденту "Фиксация осмотра и статуса ремонта" из ТЗ.
    /// </summary>
    public partial class InspectionForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private Request _request;
        private Inspection _existingInspection;

        public InspectionForm(int requestId, RequestSystemFacade facade)
        {
            _requestId = requestId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
            SetupValidation();
        }

        private void LoadData()
        {
            try
            {
                LoadRequestInfo();
                LoadExistingInspection();
                UpdateEstimatedTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestInfo()
        {
            _request = _facade.GetRequest(_requestId);

            if (_request != null)
            {
                var machine = _facade.GetMachine(_request.MachineId);
                string machineName = machine?.Model ?? $"Станок #{_request.MachineId}";

                lblRequestInfo.Text = $"📋 Заявка №{_requestId}\n" +
                    $"🔧 Станок: {machineName}\n" +
                    $"👤 Клиент ID: {_request.ClientId}\n" +
                    $"📊 Статус: {_request.Status}";
            }
            else
            {
                lblRequestInfo.Text = $"⚠️ Заявка №{_requestId} не найдена";
                btnSave.Enabled = false;
            }
        }

        private void LoadExistingInspection()
        {
            _existingInspection = _facade.GetInspection(_requestId);

            if (_existingInspection != null)
            {
                // Заполняем поля существующими данными
                txtDescription.Text = _existingInspection.Description;
                txtWorkRequired.Text = _existingInspection.WorkRequired;
                txtPartsNeeded.Text = _existingInspection.PartsNeeded;
                txtLaborHours.Text = _existingInspection.LaborHours.ToString();
                txtEstimatedCost.Text = _existingInspection.EstimatedCost.ToString();

                lblExistingInfo.Text = $"📄 Существующий осмотр от {_existingInspection.InspectionDate:dd.MM.yyyy HH:mm}";
                lblExistingInfo.Visible = true;

                btnSave.Text = "🔄 ОБНОВИТЬ ОСМОТР";
            }
        }

        private void SetupValidation()
        {
            // Валидация трудоёмкости (только цифры и точка)
            txtLaborHours.KeyPress += ValidateNumberInput;
            txtEstimatedCost.KeyPress += ValidateNumberInput;

            // Автоматический расчет общей стоимости
            txtEstimatedCost.TextChanged += (s, e) => UpdateEstimatedTotal();
            txtLaborHours.TextChanged += (s, e) => UpdateEstimatedTotal();
        }

        private void ValidateNumberInput(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, точку, запятую и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void UpdateEstimatedTotal()
        {
            float laborHours = ParseFloat(txtLaborHours.Text);
            float estimatedCost = ParseFloat(txtEstimatedCost.Text);

            if (laborHours > 0 || estimatedCost > 0)
            {
                lblEstimatedTotal.Text = $"💰 Ориентировочная стоимость: {estimatedCost:N2} ₽\n" +
                                         $"⏱ Трудоёмкость: {laborHours:F1} ч.\n" +
                                         $"💵 Ставка в час: {(laborHours > 0 ? estimatedCost / laborHours : 0):N2} ₽/ч";
                lblEstimatedTotal.Visible = true;
            }
            else
            {
                lblEstimatedTotal.Visible = false;
            }
        }

        private float ParseFloat(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            text = text.Replace(',', '.');
            float result;
            float.TryParse(text, out result);
            return result;
        }

        private void SaveInspection()
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowWarning("Введите описание неисправности!");
                txtDescription.Focus();
                return;
            }

            float laborHours = ParseFloat(txtLaborHours.Text);
            if (laborHours <= 0)
            {
                ShowWarning("Введите корректную трудоёмкость (часы)!");
                txtLaborHours.Focus();
                return;
            }

            float estimatedCost = ParseFloat(txtEstimatedCost.Text);
            if (estimatedCost <= 0)
            {
                ShowWarning("Введите ориентировочную стоимость!");
                txtEstimatedCost.Focus();
                return;
            }

            try
            {
                var inspection = new Inspection
                {
                    RequestId = _requestId,
                    Description = txtDescription.Text.Trim(),
                    WorkRequired = txtWorkRequired.Text.Trim(),
                    PartsNeeded = txtPartsNeeded.Text.Trim(),
                    LaborHours = laborHours,
                    EstimatedCost = estimatedCost,
                    InspectionDate = DateTime.Now
                };

                int inspectionId = _facade.SaveInspection(inspection);

                if (inspectionId > 0)
                {
                    string message = _existingInspection == null
                        ? "✅ Данные осмотра успешно сохранены!\n\n" +
                          $"📝 Описание: {inspection.Description}\n" +
                          $"⏱ Трудоёмкость: {laborHours} ч\n" +
                          $"💰 Ориентир. стоимость: {estimatedCost:N2} ₽"
                        : "✅ Данные осмотра успешно обновлены!";

                    MessageBox.Show(message, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем статус заявки
                    if (_request != null && _request.Status == "Назначен мастер")
                    {
                        _facade.ChangeStatus(_requestId, "Станок принят");
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowError("Ошибка при сохранении данных осмотра!");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInspection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Очистить все поля формы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtDescription.Clear();
                txtWorkRequired.Clear();
                txtPartsNeeded.Clear();
                txtLaborHours.Clear();
                txtEstimatedCost.Clear();
                txtDescription.Focus();
            }
        }

        #endregion
    }
}