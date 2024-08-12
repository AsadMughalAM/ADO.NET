using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NET.Entities;

namespace ADO.NET.Repositories
{
    public static class EmployeeRepository
    {
        public static string _connectionString { get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Employee;Integrated Security=True;Encrypt=False";

        public static List<Employee> GetData()
        {
            string commandString = "GetEmployees";
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(commandString, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var dataAdapter = new SqlDataAdapter(command);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    var employee = new Employee()
                    {
                        Id = (int)row["Id"],
                        Name = (string)row["Name"],
                        City = (string)row["City"],
                        Address = (string)row["Address"],
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        public static bool CreatePerson(Employee obj)
        {
            string insertQuery = "AddNewEmpDetails";

            var connection = new SqlConnection(_connectionString);
            

                connection.Open();
                var insertCommand = new SqlCommand(insertQuery, connection);

                insertCommand.CommandType = CommandType.StoredProcedure;
                insertCommand.Parameters.AddWithValue("@Name", obj.Name);
                insertCommand.Parameters.AddWithValue("@City", obj.City);
                insertCommand.Parameters.AddWithValue("@Address", obj.Address);
                insertCommand.ExecuteNonQuery();
            
            return true;
        }


        public static bool UpdatePerson(Employee obj)
        {
            string updateQuery = "UpdateEmpDetails";

            var connection = new SqlConnection(_connectionString);

            connection.Open();
            var updateCommand = new SqlCommand(updateQuery, connection);

            updateCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@Id", SqlDbType.Int);
            p1.Value = obj.Id;
            updateCommand.Parameters.Add(p1);

            updateCommand.ExecuteNonQuery();

            return true;
        }




        public static bool DeletePerson(Employee obj)
        {
            string deleteQuery = "DeleteEmpById";

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();
                var deleteCommand = new SqlCommand(deleteQuery, connection);
                
                    deleteCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.Int,
                        Value = obj.Id

                    };
                    deleteCommand.Parameters.Add(param1);
                    deleteCommand.Parameters.AddWithValue("@Id", obj.Id);

                    deleteCommand.ExecuteNonQuery();
                
                return true;
            }
        }
    }
}






