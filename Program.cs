using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace frappi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
            fullTimeEmployee.FullName = "Name Surname Patrionymic";
            fullTimeEmployee.position = "Director";
            while (true)
            {
                if (fullTimeEmployee.Salary == 0)
                {
                    Console.WriteLine("Введите зарплату: ");
                    fullTimeEmployee.Salary = Convert.ToInt32(Console.ReadLine());
                }
                else if (fullTimeEmployee.Bonus == 0)
                {
                    Console.WriteLine("Введите бонус: ");
                    fullTimeEmployee.Bonus = Convert.ToInt32(Console.ReadLine());
                }
                else break;

            }


        }
    }
  

    /// <summary>
    /// Класс компании
    /// </summary>
    public class Company
    {


        public string Name { get; set; }
        /// <summary>
        /// список отделов
        /// </summary>
        List<Department> Departments { get; set; } = new List<Department>();


    }
    /// <summary>
    /// класс отдела компании 
    /// </summary>
    public class Department
    {
        /// <summary>
        /// название отдела
        /// </summary>
        public string Name { get; set; }
        public int CountOfEmployee { get; set; }


    }
    /// <summary>
    /// класс сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string position { get; set; }
        private double _salary;
        /// <summary>
        /// зарплата сотрудника
        /// </summary>
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Введена отрицательная сумма");
                    }
                } 
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Введена отрицательная сумма");
                }
            }
        }
            
        /// <summary>
        /// Метод по подсчету зарплаты сотрудника
        /// </summary>
        public double CalculateSalary()
        {
            return Salary;
        }

    }
    /// <summary>
    /// Класс штатного сотрудника
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        /// <summary>
        /// Поле бонуса
        /// </summary>
        private double _bonus;
        public double Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                try
                {
                    if (Bonus < 0)
                    {
                        throw new ArgumentException("Введён отрицательный бонус");

                    }
                    else
                        _bonus = value;
                }

                catch (BonusException ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                    Console.WriteLine($"Значение которое вызвало ошибку: {ex.BonusError}");
                }
                _bonus = value;
            }
        }
        
    
        /// <summary>
        /// подсчет зарплаты штатного сотрудника
        /// </summary>
        public double CalculateSalary()
        {
            return Salary + Bonus;
        }
        /// <summary>
        /// Класс сотрудника в удалёнке
        /// </summary>
        public class ContractEmployee : Employee
        {

            /// <summary>
            /// подсчет зарплаты сотрудника по удалёнке
            /// </summary>
            public double CalculateSalary()
            {
                //TODO: Зарплата сотрудника по удалёнке
                return Salary+ (Salary / 100);
            }
        }

        public class BonusException : Exception
        {
            public double BonusError { get;set; }
            public BonusException(string message, double error ) : base(message)
            {
                BonusError = error;
                
            }
        }
    }
}

