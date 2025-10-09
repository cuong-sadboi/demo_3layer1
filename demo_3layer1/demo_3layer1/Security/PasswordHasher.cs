using System;
using System.Security.Cryptography;

namespace demo_3layer1.Security
{
    public static class PasswordHasher
    {
        private const int Iterations = 100000;
        private const int SaltSizeBytes = 16;     // 128-bit salt
        private const int KeySizeBytes = 32;      // 256-bit subkey
        private const string Prefix = "PBKDF2";  // simple marker to detect hashed format

        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            byte[] salt = new byte[SaltSizeBytes];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // .NET Framework Rfc2898DeriveBytes defaults to HMACSHA1
            byte[] key;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                key = pbkdf2.GetBytes(KeySizeBytes);
            }

            string encoded = string.Join("$",
                Prefix,
                Iterations.ToString(),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(key));

            return encoded;
        }

        public static bool IsHashed(string value)
        {
            return !string.IsNullOrEmpty(value) && value.StartsWith(Prefix + "$", StringComparison.Ordinal);
        }

        public static bool Verify(string encoded, string password)
        {
            if (string.IsNullOrEmpty(encoded) || password == null)
                return false;

            var parts = encoded.Split('$');
            if (parts.Length != 4 || !string.Equals(parts[0], Prefix, StringComparison.Ordinal))
                return false;

            if (!int.TryParse(parts[1], out int iterations) || iterations <= 0)
                return false;

            byte[] salt;
            byte[] expectedKey;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedKey = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actualKey;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                actualKey = pbkdf2.GetBytes(expectedKey.Length);
            }

            return FixedTimeEquals(actualKey, expectedKey);
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
    }
}
