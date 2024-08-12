using ADO.NET.Entities;
using ADO.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.WriteLine("Select from the options below\n1.Retrieve\n2.Create\n3.Update\n4.Delete");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var list = EmployeeRepository.GetData();
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{item.Id}\t|\t{item.Name}\t|\t{item.City}\t|\t{item.Address}");
                        }
                        break;

                    case 2:
                        var obj = new Employee();

                        Console.Write("Enter Id: ");
                        obj.Id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        obj.Name = Console.ReadLine();

                        Console.Write("Enter City: ");
                        obj.City = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        obj.Address = Console.ReadLine();

                        bool result = EmployeeRepository.CreatePerson(obj);
                        string message = result ? "Person created!" : "Failed something went wrong";
                        Console.WriteLine(message);
                        break;

                    case 3:
                        var Obj = new Employee();

                        Console.Write("Enter Id: ");
                        Obj.Id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        Obj.Name = Console.ReadLine();

                        Console.Write("Enter City: ");
                        Obj.City = Console.ReadLine();

                        Console.Write("Enter Address: ");
                        Obj.Address = Console.ReadLine();

                        bool result1 = EmployeeRepository.UpdatePerson(Obj);
                        string message1 = result1 ? "Person updated!" : "Failed something went wrong";
                        Console.WriteLine(message1);
                        break;

                    case 4:
                        var obj1 = new Employee();
                        Console.WriteLine("Enter the id of the person you want to delete");
                        obj1.Id = int.Parse(Console.ReadLine());

                        bool result2 = EmployeeRepository.DeletePerson(obj1);
                        string message2 = result2 ? "Person deleted!" : "Failed something went wrong";
                        Console.WriteLine(message2);
                        break;

                    default:
                        Console.WriteLine("Invalid Number");
                        break;
                }
                Console.WriteLine("Do you want to continue?");
                answer = Console.ReadLine();
            }
            while (answer != "no");
        }
    }
}


