using RepairIS.Facades;
using RepairIS.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RepairIS.Forms
{
    /// <summary>
    /// Главная форма клиента (заказчика).
    /// Соответствует прецедентам: "Создание заявки", "Просмотр статуса", "Просмотр истории заявок"
    /// </summary>
    public partial class ClientMainForm : Form
    {
        private readonly int _userId;
        private readonly RequestSystemFacade _facade;
        private User _currentUser;

        public ClientMainForm(int userId, RequestSystemFacade facade)
        {
            _userId = userId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadUserData();
            UpdateStatistics();
        }

        private void LoadUserData()
        {
            // Пытаемся получить информацию о пользователе
            // TODO: когда добавите User, заменить на получение из _facade
            _currentUser = new User
            {
                Id = _userId,
                Name = $"Клиент {_userId}",
                Role = UserRole.Client
            };

            lblWelcome.Text = $"👋 Добро пожаловать, {_currentUser.Name}!";
            lblUserId.Text = $"ID: {_userId}";
        }

        private void UpdateStatistics()
        {
            try
            {
                var requests = _facade.GetRequestsByClientId(_userId);

                int totalCount = requests.Count;
                int pendingCount = requests.Count(r => r.Status == "Ожидает обработки");
                int inProgressCount = requests.Count(r => r.Status == "В работе" || r.Status == "Назначен мастер");
                int completedCount = requests.Count(r => r.Status == "Завершено" || r.Status == "Оплачено");

                lblStats.Text = $"📊 Ваши заявки: Всего: {totalCount} | В работе: {inProgressCount} | Завершено: {completedCount}";

                // Если есть заявки, ожидающие обработки - подсветить
                if (pendingCount > 0)
                {
                    lblStats.ForeColor = System.Drawing.Color.Orange;
                    lblStats.Text += $" | ⚠️ Ожидают: {pendingCount}";
                }
                else
                {
                    lblStats.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblStats.Text = "Не удалось загрузить статистику";
                Console.WriteLine($"Error loading stats: {ex.Message}");
            }
        }

        #region Обработчики событий

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var createForm = new CreateRequestForm(_userId, _facade))
                {
                    if (createForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateStatistics();
                        MessageBox.Show("Заявка успешно создана!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заявки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            try
            {
                using (var myRequestsForm = new MyRequestsForm(_userId, _facade))
                {
                    myRequestsForm.ShowDialog();
                    UpdateStatistics(); // Обновляем статистику после закрытия
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                using (var statusForm = new RequestStatusForm(_userId, _facade))
                {
                    statusForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void ClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Очистка ресурсов при закрытии
            _facade?.GetAllRequests(); // любой вызов для триггера, если нужно
        }

        #endregion
    }
}