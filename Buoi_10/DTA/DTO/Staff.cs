using System;
using System.Collections.Generic;

namespace Buoi_10.DTA.DTO
{
    public class Employy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double BaseSalary { get; set; }
        public double SalaryCoefficient { get; set; }
        public double Allowance { get; set; }
        public double TotalSalary => BaseSalary * SalaryCoefficient + Allowance;

        public List<Stage> Stages { get; set; }

        public Employy()
        {
            Stages = new List<Stage>();
        }

        public static Employy CreateEmployee(int id, string name, string gender, int age, double baseSalary, double salaryCoefficient, double allowance)
        {
            Employy employee = new Employy
            {
                Id = id,
                Name = name,
                Gender = gender,
                Age = age,
                BaseSalary = baseSalary,
                SalaryCoefficient = salaryCoefficient,
                Allowance = allowance
            };
            return employee;
        }
    }
}
