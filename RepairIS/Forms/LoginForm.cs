using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class LoginForm : Form
    {
        private RequestSystemFacade facade;
        private const string USERS_FILE = "users.json";
        private List<User> users;

        public LoginForm()
        {
            facade = new RequestSystemFacade();
            InitializeComponent();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            // Загрузка существующих пользователей
            if (File.Exists(USERS_FILE))
            {
                string json = File.ReadAllText(USERS_FILE);
                users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                users = new List<User>();
                ConvertExistingMastersToUsers();
            }

            // Создаем менеджера по умолчанию, если нет ни одного менеджера
            if (!users.Any(u => u.Role == UserRole.Manager))
            {
                var defaultManager = new User
                {
                    Id = GetNextId(),
                    Login = "manager",
                    Password = "manager",
                    Name = "Главный менеджер",
                    Email = "manager@repair.ru",
                    Phone = "+79990000001",
                    Role = UserRole.Manager,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };
                users.Add(defaultManager);
                SaveUsers();
            }

            // Заполняем ComboBox ролями
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Заказчик");
            cmbRole.Items.Add("Мастер");
            cmbRole.Items.Add("Менеджер");
            cmbRole.SelectedIndex = 0;
        }

        private void ConvertExistingMastersToUsers()
        {
            string mastersFile = "masters.json";
            if (File.Exists(mastersFile))
            {
                string json = File.ReadAllText(mastersFile);
                var masters = JsonConvert.DeserializeObject<List<Master>>(json) ?? new List<Master>();

                foreach (var master in masters)
                {
                    users.Add(new User
                    {
                        Id = master.Id,
                        Login = $"master_{master.Id}",
                        Password = "master123",
                        Name = master.Name,
                        Email = master.Email,
                        Phone = master.Phone,
                        Role = UserRole.Master,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    });
                }
            }
        }

        private int GetNextId()
        {
            return users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
        }

        private void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(USERS_FILE, json);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string selectedRole = cmbRole.SelectedItem?.ToString();

            // Валидация
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Поиск пользователя
            var user = users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка активности
            if (!user.IsActive)
            {
                MessageBox.Show("Ваша учетная запись заблокирована! Обратитесь к менеджеру.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка соответствия роли (C# 7.3 - без рекурсивных шаблонов)
            UserRole expectedRole;
            if (selectedRole == "Заказчик")
                expectedRole = UserRole.Client;
            else if (selectedRole == "Мастер")
                expectedRole = UserRole.Master;
            else if (selectedRole == "Менеджер")
                expectedRole = UserRole.Manager;
            else
                expectedRole = UserRole.Client;

            if (user.Role != expectedRole)
            {
                string roleRu;
                if (user.Role == UserRole.Client)
                    roleRu = "Заказчик";
                else if (user.Role == UserRole.Master)
                    roleRu = "Мастер";
                else
                    roleRu = "Менеджер";

                MessageBox.Show($"Вы зарегистрированы как {roleRu}. Пожалуйста, выберите правильную роль для входа.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Открываем главную форму
            OpenMainForm(user);
        }

        private void OpenMainForm(User user)
        {
            if (user.Role == UserRole.Client)
            {
                ClientMainForm clientForm = new ClientMainForm(user.Id, facade);
                clientForm.Show();
            }
            else if (user.Role == UserRole.Master)
            {
                MasterRequestsForm masterForm = new MasterRequestsForm(user.Id, facade);
                masterForm.Show();
            }
            else if (user.Role == UserRole.Manager)
            {
                AllRequestsForm managerForm = new AllRequestsForm(facade);
                managerForm.Show();
            }
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // RegisterForm временно отключен, так как вызывает ошибки
            MessageBox.Show("Регистрация временно недоступна. Обратитесь к менеджеру.",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // RegisterForm registerForm = new RegisterForm(users, SaveUsers);
            // registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}