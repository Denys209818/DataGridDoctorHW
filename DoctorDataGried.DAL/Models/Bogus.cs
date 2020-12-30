using Bogus;
using DoctorDataGried.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Bogus.DataSets.Name;

namespace DoctorDataGried.DAL.Models
{
    public static class BogusManager
    {
        public static void FillData(Context context) 
        {
            Random r = new Random();
            Department dep1 = new Department();
            Department dep2 = new Department();
            
            dep1.Name = "Хірургія";
            dep1.CabinetNumber = 3;
            
            dep2.Name = "Інфекційне";
            dep2.CabinetNumber = 1;
            
            context.departments.AddRange(
                dep1,
                dep2
                );
            
                Faker<Doctor> faker = new Faker<Doctor>("uk");
                faker.RuleFor(doc => doc.FirstName, (f, u) =>  f.Name.FirstName(Gender.Male));
                faker.RuleFor(doc => doc.LastName, f => f.Name.LastName(Gender.Male));
                faker.RuleFor(doc => doc.Login, f => f.Phone.PhoneNumber());
                faker.RuleFor(doc => doc.Password, f => PasswordManager.HashPassword(f.Internet.Password(8)));

            for (int i = 0; i < 200; i++)
            {

                Doctor doctor = faker.Generate();
                int ind = r.Next(1, 3);
                if (ind == 3) 
                {
                    ind = 2;
                }
                switch (ind)
                {
                    case 1:
                        {
                            doctor.Department = dep1;
                            break;
                        }
                    case 2:
                        {
                            doctor.Department = dep2;
                            break;
                        }
                }
                context.doctors.Add(doctor);
            }
            context.SaveChanges();
        }
    }
}
