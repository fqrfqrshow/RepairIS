using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RepairIS.Forms
{
    public partial class RegisterForm : Form
    {
        private List<User> users;
        private Action onUsersUpdated;

        public RegisterForm(List<User> existingUsers, Action onUsersUpdatedCallback)
        {
            InitializeComponent();
            this.users = existingUsers;
            this.onUsersUpdated = onUsersUpdatedCallback;

            // Можно зарегистрироваться только как Заказчик или Мастер
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Заказчик");
            cmbRole.Items.Add("Мастер");
            cmbRole.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(login))
            {
                ShowError("Введите логин!");
                return;
            }

            if (login.Length < 3)
            {
                ShowError("Логин должен содержать не менее 3 символов!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Введите пароль!");
                return;
            }

            if (password.Length < 4)
            {
                ShowError("Пароль должен содержать не менее 4 символов!");
                return;
            }

            if (password != confirmPassword)
            {
                ShowError("Пароли не совпадают!");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                ShowError("Введите ваше имя!");
                return;
            }

            // Проверка уникальности логина
            if (users.Any(u => u.Login == login))
            {
                ShowError("Пользователь с таким логином уже существует!");
                return;
            }

            // Определяем роль
            UserRole role = cmbRole.SelectedItem.ToString() == "Заказчик"
                ? UserRole.Client
                : UserRole.Master;

            // Создаем пользователя
            var newUser = new User
            {
                Id = GetNextId(),
                Login = login,
                Password = password,
                Name = name,
                Email = email,
                Phone = phone,
                Role = role,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            users.Add(newUser);
            onUsersUpdated?.Invoke();

            MessageBox.Show($"Регистрация успешно завершена!\n\nЛогин: {login}\nРоль: {cmbRole.SelectedItem}",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private int GetNextId()
        {
            return users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}