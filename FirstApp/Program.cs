using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        public static List<Employee> Update(List<Employee> resultList, string newName, int id)
        {
            //2. query
            IEnumerable<Employee> query =
                from Employee resultSet in resultList
                where resultSet.EmployeeID == id
                select resultSet;

            //3. execution
            foreach (Employee resultSet in query)
            {
                resultSet.Name = newName;
            }
            return resultList;
        }

        public static List<Employee> Remove(int Id, List<Employee> resultList)
        {
            var itemToRemove = resultList.Single(r => r.EmployeeID == Id);
            resultList.Remove(itemToRemove);
            return resultList;
        }

        public static List<Employee> Append(List<Employee> resultList, Employee itemToAdd)
        {
            resultList.Add(itemToAdd);
            return resultList;
        }

        static void Main(string[] args)
        {   
            // generic collections
            
            var employees = new List<Employee>()
            {
                {new Employee {EmployeeID=1, Name="Sidak"} },
                {new Employee {EmployeeID=2, Name="Sidak1"} },
                {new Employee {EmployeeID=3, Name="Sidak2"} },
            };

            int caseSwitch = 1;
            do
            {
                foreach (var empValue in employees)
                {
                    Console.WriteLine(value: $"Employee {empValue.EmployeeID} is {empValue.Name}");
                }
                Console.WriteLine();

                Console.WriteLine(value: $"Please provide option 1. Add, 2. Modify, 3. Delete, 4. Exit");
                caseSwitch = Convert.ToInt32(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        {
                            Console.WriteLine("Case 1: Add");
                            Console.WriteLine("Please enter Employee id and name");
                            int id = Convert.ToInt32(Console.ReadLine());
                            string name = Console.ReadLine();
                            var toAdd = new Employee { EmployeeID = id, Name = name };
                            employees = Append(employees, toAdd);
                            continue;
                        }
                    case 2:
                        {
                            Console.WriteLine("Case 2: Modify");
                            Console.WriteLine("Please enter Employee id and name");
                            int id = Convert.ToInt32(Console.ReadLine());
                            string name = Console.ReadLine();
                            employees = Update(employees, name, id);
                            continue;
                        }
                    case 3:
                        {
                            Console.WriteLine("Case 3: Remove");
                            Console.WriteLine("Please enter Employee id to remove");
                            int id = Convert.ToInt32(Console.ReadLine());
                            employees = Remove(id, employees);
                            continue;
                        }
                }
            } while (caseSwitch != 4);
        }
    }
}