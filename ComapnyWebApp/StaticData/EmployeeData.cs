//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ComapnyWebApp.Models;

//namespace ComapnyWebApp.StaticData
//{
//    public class EmployeeData
//    {
//        private static List<Employee> _lstEmployee = staticEmployee();
      
       
//        public static List<Employee> GetAllEmployees()
//        {
//            return _lstEmployee;
//        }
//        public static void AddEmployee(Employee employee)
//        {
//            _lstEmployee.Add(employee);
//        }

//        public static Employee GetEmployeeById(string empcode)
//        {
//            return _lstEmployee.FirstOrDefault(e => e.EmployeeCode == empcode);
//        }

//        public static void UpdateEmployee(Employee updatedEmployee)
//        {
//            var existingEmployee = _lstEmployee.FirstOrDefault(e => e.EmployeeCode == updatedEmployee.EmployeeCode);

//            if (existingEmployee != null)
//            {
//                // Update the properties of the existing employee
//                existingEmployee.EmployeeCode = updatedEmployee.EmployeeCode;
//                existingEmployee.FirstName = updatedEmployee.FirstName;
//                //existingEmployee.LastName = updatedEmployee.LastName;
//                //existingEmployee.Email = updatedEmployee.Email;
//                //existingEmployee.Mobile = updatedEmployee.Mobile;
//                //existingEmployee.Gender = updatedEmployee.Gender;
//                //existingEmployee.DOB = updatedEmployee.DOB;
//            }
//        }

//        public static void DeleteEmployee(string empcode)
//        {
//            var employeeToRemove = _lstEmployee.FirstOrDefault(e => e.EmployeeCode == empcode);

//            if (employeeToRemove != null)
//            {
//                _lstEmployee.Remove(employeeToRemove);
//            }
//        }

//        public static List<Employee> staticEmployee()
//        {
//            List<Employee> _lst = new List<Employee>();
//            Employee emp = new Employee()
//            {
//                EmployeeCode = "123",
//                FirstName = "Test",
//                LastName = "1",
//                Email = "test@email.com",
//                Mobile = "9910878",
//                Gender = "Male",
//                DOB = new DateTime(1995, 09, 23)
//            };

//            Employee emp1 = new Employee()
//            {
//                EmployeeCode = "124",
//                FirstName = "Test",
//                LastName = "2",
//                Email = "test@email.com",
//                Mobile = "989988",
//                Gender = "Female",
//                DOB = new DateTime(1997, 08, 21)
//            };

//            _lst.Add(emp1);
//            _lst.Add(emp);

//            return _lst;         
//        }
//    }
//}
