using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace SistemaNotificacaoEscolarBack.Models.Entities
{
    public enum UserRole
    {
        Admin,
        Teacher,
        Student,
        Parent
    }

    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(254)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Stored as: {iterations}.{saltBase64}.{hashBase64}
        [Required]
        public string PasswordHash { get; private set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; } = UserRole.Student;

        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Set a password using PBKDF2 (RFC2898) with SHA256
        public void SetPassword(string password, int iterations = 100_000)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[16];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            PasswordHash = $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            UpdatedAt = DateTime.UtcNow;
        }

        public bool VerifyPassword(string password)
        {
            if (string.IsNullOrEmpty(PasswordHash)) return false;
            try
            {
                var parts = PasswordHash.Split('.', 3);
                if (parts.Length != 3) return false;

                var iterations = int.Parse(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var storedHash = Convert.FromBase64String(parts[2]);

                using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
                var computedHash = pbkdf2.GetBytes(storedHash.Length);

                return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
            }
            catch
            {
                return false;
            }
        }

        public void TouchUpdated() => UpdatedAt = DateTime.UtcNow;
    }
}