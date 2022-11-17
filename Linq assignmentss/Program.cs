using System;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Collections.Generic;

using System.Runtime.Remoting.Services;

using System.ComponentModel.Design;

using System.Security.Cryptography;

using System.Text.RegularExpressions;

using System.Reflection;




namespace LinqAssignment

{
    public class Employee
    {
        int EmployeeID;
        string FirstName;
        string LastName;
        string Title;
        DateTime DOB;
        DateTime DOJ;
        string City;
        public Employee(int EmployeeID, string FirstName, string LastName, string Title, DateTime DOB, DateTime DOJ, string City)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.DOB = DOB;
            this.DOJ = DOJ;
            this.City = City;




        }
        public int EmployeeId
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }
        public string Firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        public string Lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }
        public DateTime dob
        {
            get { return DOB; }
            set { DOB = value; }
        }
        public DateTime doj
        {
            get { return DOJ; }
            set { DOJ = value; }
        }
        public string city
        {
            get { return City; }
            set { City = value; }
        }
        public static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai"));
            empList.Add(new Employee(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"));
            empList.Add(new Employee(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "pune"));
            empList.Add(new Employee(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"));
            empList.Add(new Employee(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"));
            empList.Add(new Employee(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"));
            empList.Add(new Employee(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"));
            empList.Add(new Employee(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"));
            empList.Add(new Employee(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"));
            empList.Add(new Employee(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune"));
            IEnumerable<Employee> query = from emp in empList select emp;
            foreach (var emp in query)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);
            }

            Console.WriteLine("enter emp whose location is not mumbai");
            IEnumerable<Employee> query2 = from emp in empList where emp.city != "Mumbai" select emp;
            foreach (var emp in query2)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);




            }
            Console.WriteLine("enter emp whose Title is AsstManager");
            IEnumerable<Employee> query3 = from emp in empList where emp.Title == "AsstManager" select emp;
            foreach (var emp in query3)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);
            }
            Console.WriteLine("enter emp whose Lastname starts with S");
            IEnumerable<Employee> query4 = from emp in empList where (emp.Lastname.StartsWith("S")) select emp;
            foreach (var emp in query4)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);
            }
            Console.WriteLine("enter emp whose dob is after 1/1/1990");
            IEnumerable<Employee> query6 = from emp in empList where emp.DOB < (new DateTime(1990, 1, 1)) select emp;
            foreach (var emp in query6)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);
            }
            Console.WriteLine("enter emp whose designation is Consultant and Associate");
            IEnumerable<Employee> query7 = from emp in empList where emp.Title == "Consultant" || emp.Title == "Associate" select emp;
            foreach (var emp in query7)
            {
                Console.WriteLine("Employee: {0},{1},{2},{3},{4},{5},{6}", emp.EmployeeId, emp.Firstname, emp.Lastname, emp.Title, emp.dob, emp.doj, emp.city);
            }
            Console.WriteLine("-------------");
            Console.WriteLine("total count of employee");
            var result = empList.Count();
            {
                Console.WriteLine("print the result" + result);
            }
            Console.WriteLine("-------");
            Console.WriteLine("count of employees belonging to Chennai");
            var j = (from emp in empList where emp.city == "Chennai" select emp).Count();
            {
                Console.WriteLine("print the count" + j);
            }
            Console.WriteLine("--------");
            Console.WriteLine("highest employeeid from list");
            var value = empList.Max(em => em.EmployeeID);
            Console.WriteLine("print the maximum value" + value);
            Console.WriteLine("---------");
            Console.WriteLine("enter total number of employees joined after 1/1/2015");
            var k = (from emp in empList where emp.doj > (new DateTime(2015 / 1 / 1)) select emp).Count();
            Console.WriteLine("print the total number of employees joined after 2015/1/1 :" + k);
            Console.WriteLine("---------");
            Console.WriteLine("enter emp whose designation is not Associate");
            var l = (from emp in empList where emp.Title != "Associate" select emp).Count();
            Console.WriteLine("print the number of employees whose designation is not Associate :" + l);
            Console.WriteLine("---------Group by City------------");
            var empgrps = from emp in empList
                          group emp by emp.city;
            foreach (var group in empgrps)
            {
                Console.WriteLine("{0}-{1}", group.Key, group.Count());
            }




            var n = (from emp in empList group emp by (emp.City, emp.Title)).Count();
            Console.WriteLine("\n\n\n Employees based on City and Title are:" + n);




            var youngest = empList.Select(em => em.DOB);
            Console.WriteLine("\n\n\n The youngest employee is:" + youngest.Min());
            Console.ReadKey();
        }

    }
}
