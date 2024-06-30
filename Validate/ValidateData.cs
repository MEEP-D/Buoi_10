using System;
using System.Globalization;

namespace Common
{
    public class ValidateEmployeeData
    {
        public bool ValidateEmployee(string id, string name, string dateJoinedInput, string salaryCoefficientInput, out DateTime dateJoined, out double salaryCoefficient)
        {
            dateJoined = DateTime.MinValue;
            salaryCoefficient = 0;

            if (HasInvalidInput(id, name, dateJoinedInput, salaryCoefficientInput))
            {
                return false;
            }

            if (!IsValidDate(dateJoinedInput, out dateJoined))
            {
                return false;
            }

            if (!IsValidSalaryCoefficient(salaryCoefficientInput, out salaryCoefficient))
            {
                return false;
            }

            return true;
        }

        private bool HasInvalidInput(params string[] inputs)
        {
            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsValidDate(string dateInput, out DateTime date)
        {
            return DateTime.TryParseExact(dateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        private bool IsValidSalaryCoefficient(string salaryInput, out double salaryCoefficient)
        {
            return double.TryParse(salaryInput, out salaryCoefficient) && salaryCoefficient > 0;
        }
    }
}
