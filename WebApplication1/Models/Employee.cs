using System;
using System.Globalization;

namespace EmployeesAPI.Models
{
    /// <summary>Employee</summary>
    public class Employee
	{
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The employee name.</value>
        public string name { get; set; }

        /// <summary>Gets or sets the surname.</summary>
        /// <value>The employee surname.</value>
        public string surname { get; set; }

		private DateTime _dateOfBirth;

        /// <summary>Gets or sets the date of birth.</summary>
        /// <value>The date of birth.</value>
        public string dateOfBirth
		{
            get { return _dateOfBirth.ToString("dd.MM.yyyy"); }
			set { _dateOfBirth = StringToDate(value); }
		}

        /// <summary>Strings to date.</summary>
        /// <param name="date">Date.</param>
        /// <returns>Date string "dd.MM.yyyy"</returns>
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
