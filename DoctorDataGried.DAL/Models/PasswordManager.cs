using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorDataGried.DAL.Models
{
    public static class PasswordManager
    {
        public static string HashPassword(string password) 
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
