﻿namespace TransActiva.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int UserTypeId { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockoutUntil { get; set; }
    }
}