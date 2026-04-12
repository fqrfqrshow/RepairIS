using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра и подтверждения/отклонения сметы заказчиком.
    /// Соответствует прецеденту "Рассмотреть смету" из ТЗ.
    /// </summary>
    public partial class EstimateViewForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private Estimate _estimate;
        private Request _request;

        public EstimateViewForm(int requestId, RequestSystemFacade facade)
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
                LoadRequestInfo();
                LoadEstimate();
                CheckIfAlreadyConfirmed();
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
                    $"📅 Дата создания: {_request.CreatedAt:dd.MM.yyyy}\n" +
                    $"📍 Статус: {_request.Status}";
            }
            else
            {
                lblRequestInfo.Text = $"⚠️ Заявка №{_requestId} не найдена";
                btnConfirm.Enabled = false;
                btnReject.Enabled = false;
            }
        }

        private void LoadEstimate()
        {
            _estimate = _facade.GetEstimate(_requestId);

            if (_estimate != null)
            {
                // Заполняем значения
                lblWorkValue.Text = $"{_estimate.WorkCost:N2} ₽";
                lblPartsValue.Text = $"{_estimate.PartsCost:N2} ₽";
                lblLogisticsValue.Text = $"{_estimate.LogisticsCost:N2} ₽";
                lblExtraValue.Text = $"{_estimate.ExtraCost:N2} ₽";
                lblTotalValue.Text = $"{_estimate.TotalCost:N2} ₽";

                // Цветовая индикация итога
                if (_estimate.TotalCost > 100000)
                    lblTotalValue.ForeColor = System.Drawing.Color.Red;
                else if (_estimate.TotalCost > 50000)
                    lblTotalValue.ForeColor = System.Drawing.Color.Orange;
                else
                    lblTotalValue.ForeColor = System.Drawing.Color.Green;

                // Детали сметы
                lblEstimateDetails.Text = GetEstimateDetails();
            }
            else
            {
                MessageBox.Show("Смета отсутствует! Невозможно просмотреть.",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private string GetEstimateDetails()
        {
            if (_estimate == null) return "";

            string details = "📊 Детали сметы:\n";
            if (_estimate.WorkCost > 0) details += $"  • Работы: {_estimate.WorkCost:N2} ₽\n";
            if (_estimate.PartsCost > 0) details += $"  • Запчасти: {_estimate.PartsCost:N2} ₽\n";
            if (_estimate.LogisticsCost > 0) details += $"  • Логистика: {_estimate.LogisticsCost:N2} ₽\n";
            if (_estimate.ExtraCost > 0) details += $"  • Дополнительно: {_estimate.ExtraCost:N2} ₽\n";

            return details;
        }

        private void CheckIfAlreadyConfirmed()
        {
            if (_estimate != null && _estimate.IsConfirmed)
            {
                btnConfirm.Enabled = false;
                btnReject.Enabled = false;
                lblAlreadyConfirmed.Visible = true;
                lblAlreadyConfirmed.Text = "✅ Эта смета уже была подтверждена заказчиком ранее.";
                lblAlreadyConfirmed.ForeColor = System.Drawing.Color.Green;

                // Меняем текст кнопок
                btnConfirm.Text = "Уже подтверждена";
                btnConfirm.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void ConfirmEstimate()
        {
            if (_estimate == null)
            {
                ShowWarning("Смета не найдена!");
                return;
            }

            if (_estimate.IsConfirmed)
            {
                ShowWarning("Смета уже подтверждена!");
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите ПОДТВЕРДИТЬ смету на сумму {_estimate.TotalCost:N2} ₽?\n\n" +
                $"После подтверждения заявка будет передана в работу.",
                "Подтверждение сметы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ConfirmEstimate(_requestId);

                    if (success)
                    {
                        MessageBox.Show(
                            $"✅ Смета успешно подтверждена!\n\n" +
                            $"Сумма: {_estimate.TotalCost:N2} ₽\n" +
                            $"Статус заявки: Смета подтверждена\n\n" +
                            $"В ближайшее время с вами свяжется мастер.",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        ShowError("Ошибка при подтверждении сметы!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void RejectEstimate()
        {
            if (_estimate == null)
            {
                ShowWarning("Смета не найдена!");
                return;
            }

            if (_estimate.IsConfirmed)
            {
                ShowWarning("Смета уже подтверждена, отклонение невозможно!");
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите ОТКЛОНИТЬ смету на сумму {_estimate.TotalCost:N2} ₽?\n\n" +
                $"Заявка будет закрыта.",
                "Отклонение сметы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.RejectEstimate(_requestId);

                    if (success)
                    {
                        MessageBox.Show(
                            $"❌ Смета отклонена.\n\n" +
                            $"Вы можете создать новую заявку, если хотите продолжить.",
                            "Смета отклонена",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    else
                    {
                        ShowError("Ошибка при отклонении сметы!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
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

        #endregion

        #region Обработчики событий

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmEstimate();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            RejectEstimate();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // TODO: печать сметы
            MessageBox.Show("Функция печати будет доступна в следующей версии.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}