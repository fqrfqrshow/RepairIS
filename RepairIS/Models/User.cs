using System;

namespace RepairIS.Models
{
    public enum UserRole
    {
        Client,   // Заказчик
        Master,   // Мастер  
        Manager   // Менеджер
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Для обратной совместимости с существующим кодом
        public int GetClientId() => Role == UserRole.Client ? Id : 0;
        public int GetMasterId() => Role == UserRole.Master ? Id : 0;
    }
}