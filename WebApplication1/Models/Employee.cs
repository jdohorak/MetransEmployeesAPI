using System;
using System.Globalization;

namespace EmployeesAPI.Models
{
	public class Employee
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }

		private DateTime _dateOfBirth;

        public string dateOfBirth
		{
            get { return _dateOfBirth.ToString("dd.MM.yyyy"); }
			set { _dateOfBirth = StringToDate(value); }
		}

		private DateTime StringToDate(string date)
        {
			DateTime result = new DateTime();
            try
            {
				CultureInfo cultureInfo = new CultureInfo("sk-SK");
				result = DateTime.Parse(date, cultureInfo);
            }
            catch
            {
				result = DateTime.Now;
            }

			return result;
        }
    }
}
