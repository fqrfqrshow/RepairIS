using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для создания и редактирования сметы.
    /// Соответствует прецеденту "Сформировать смету" из ТЗ.
    /// </summary>
    public partial class EstimateForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private Inspection _inspection;
        private Estimate _existingEstimate;

        public EstimateForm(int requestId, RequestSystemFacade facade)
        {
            _requestId = requestId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadInspectionData();
                LoadExistingEstimate();
                SetupValidation();
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInspectionData()
        {
            _inspection = _facade.GetInspection(_requestId);

            if (_inspection != null)
            {
                lblInspectionData.Text = $"📋 Данные осмотра от {_inspection.InspectionDate:dd.MM.yyyy}\n" +
                    $"🔧 Описание: {_inspection.Description}\n" +
                    $"⏱ Трудоёмкость: {_inspection.LaborHours} ч | 💰 Ориентир. стоимость: {_inspection.EstimatedCost:N2} ₽\n" +
                    $"🔩 Необходимые детали: {(_inspection.PartsNeeded ?? "не указаны")}\n" +
                    $"🛠 Работы: {(_inspection.WorkRequired ?? "не указаны")}";

                // Заполняем поля на основе осмотра
                txtWorkCost.Text = _inspection.EstimatedCost.ToString("F2");
                btnAutoFill.Visible = true;
            }
            else
            {
                lblInspectionData.Text = "⚠️ Данные осмотра отсутствуют.\nСначала проведите осмотр станка.";
                lblInspectionData.ForeColor = System.Drawing.Color.Orange;
                btnAutoFill.Visible = false;

                // Предложить провести осмотр
                var result = MessageBox.Show("Для создания сметы необходимо провести осмотр. Провести осмотр сейчас?",
                    "Осмотр не проведен", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var inspectionForm = new InspectionForm(_requestId, _facade))
                    {
                        if (inspectionForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadInspectionData(); // Перезагружаем
                        }
                    }
                }
            }
        }

        private void LoadExistingEstimate()
        {
            _existingEstimate = _facade.GetEstimate(_requestId);

            if (_existingEstimate != null)
            {
                txtWorkCost.Text = _existingEstimate.WorkCost.ToString("F2");
                txtPartsCost.Text = _existingEstimate.PartsCost.ToString("F2");
                txtLogisticsCost.Text = _existingEstimate.LogisticsCost.ToString("F2");
                txtExtraCost.Text = _existingEstimate.ExtraCost.ToString("F2");

                lblExistingInfo.Text = $"📄 Существующая смета от {GetEstimateDate()}";
                lblExistingInfo.Visible = true;

                if (_existingEstimate.IsConfirmed)
                {
                    SetControlsEnabled(false);
                    btnSave.Enabled = false;
                    btnAutoFill.Enabled = false;
                    lblConfirmedWarning.Text = "⚠️ Эта смета уже подтверждена заказчиком. Изменение невозможно.";
                    lblConfirmedWarning.Visible = true;
                }
            }
        }

        private string GetEstimateDate()
        {
            // TODO: добавить дату создания в модель Estimate
            return "ранее";
        }

        private void SetupValidation()
        {
            // Добавляем события для авто-расчета
            txtWorkCost.TextChanged += (s, e) => UpdateTotal();
            txtPartsCost.TextChanged += (s, e) => UpdateTotal();
            txtLogisticsCost.TextChanged += (s, e) => UpdateTotal();
            txtExtraCost.TextChanged += (s, e) => UpdateTotal();

            // Валидация ввода (только цифры и точка)
            txtWorkCost.KeyPress += ValidateNumberInput;
            txtPartsCost.KeyPress += ValidateNumberInput;
            txtLogisticsCost.KeyPress += ValidateNumberInput;
            txtExtraCost.KeyPress += ValidateNumberInput;
        }

        private void ValidateNumberInput(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, точку, запятую и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            // Только одна точка/запятая
            var textBox = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void UpdateTotal()
        {
            float work = ParseFloat(txtWorkCost.Text);
            float parts = ParseFloat(txtPartsCost.Text);
            float logistics = ParseFloat(txtLogisticsCost.Text);
            float extra = ParseFloat(txtExtraCost.Text);

            float total = work + parts + logistics + extra;
            lblTotal.Text = $"💰 ИТОГО: {total:N2} ₽";

            // Цветовая индикация
            if (total > 100000)
                lblTotal.ForeColor = System.Drawing.Color.Red;
            else if (total > 50000)
                lblTotal.ForeColor = System.Drawing.Color.Orange;
            else
                lblTotal.ForeColor = System.Drawing.Color.Green;
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

        private void AutoFillFromInspection()
        {
            if (_inspection != null)
            {
                txtWorkCost.Text = _inspection.EstimatedCost.ToString("F2");
                txtPartsCost.Text = "0";
                txtLogisticsCost.Text = "0";
                txtExtraCost.Text = "0";

                MessageBox.Show("Поля автоматически заполнены на основе данных осмотра.",
                    "Автозаполнение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveEstimate()
        {
            // Валидация
            float workCost = ParseFloat(txtWorkCost.Text);
            float partsCost = ParseFloat(txtPartsCost.Text);
            float logisticsCost = ParseFloat(txtLogisticsCost.Text);
            float extraCost = ParseFloat(txtExtraCost.Text);

            if (workCost <= 0 && partsCost <= 0 && logisticsCost <= 0 && extraCost <= 0)
            {
                ShowWarning("Сумма сметы не может быть равна 0!");
                return;
            }

            if (_existingEstimate?.IsConfirmed == true)
            {
                ShowWarning("Нельзя изменить уже подтвержденную смету!");
                return;
            }

            try
            {
                var estimate = new Estimate
                {
                    RequestId = _requestId,
                    WorkCost = workCost,
                    PartsCost = partsCost,
                    LogisticsCost = logisticsCost,
                    ExtraCost = extraCost,
                    IsConfirmed = false
                };

                _facade.SaveEstimate(estimate);

                float total = workCost + partsCost + logisticsCost + extraCost;

                MessageBox.Show($"✅ Смета успешно сохранена!\n\n" +
                    $"📊 Работы: {workCost:N2} ₽\n" +
                    $"🔩 Запчасти: {partsCost:N2} ₽\n" +
                    $"🚚 Логистика: {logisticsCost:N2} ₽\n" +
                    $"📦 Дополнительно: {extraCost:N2} ₽\n" +
                    $"━━━━━━━━━━━━━━━━━━━\n" +
                    $"💰 ИТОГО: {total:N2} ₽",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при сохранении сметы: {ex.Message}");
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtWorkCost.Enabled = enabled;
            txtPartsCost.Enabled = enabled;
            txtLogisticsCost.Enabled = enabled;
            txtExtraCost.Enabled = enabled;
            btnAutoFill.Enabled = enabled;
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

        #endregion

        #region Обработчики событий

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEstimate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAutoFill_Click(object sender, EventArgs e)
        {
            AutoFillFromInspection();
        }

        #endregion
    }
}