using System;
using System.Data.SqlClient;

namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Kabeer\\Desktop\\Assignment-5\\AssignmentFive.mdf\";Integrated Security=True;";

            bool exitRequested = false;

            while (!exitRequested)
            {
                
                PrintCustomMenu();

                string input = Console.ReadLine();

                if (input == "1")
                {
                    PrintAllEmployeeRecords(connectionString);
                }
                else if (input == "2")
                {
                    InsertEmployeeRecord(connectionString);
                }
                else if (input == "3")
                {
                    DeleteEmployeeRecord(connectionString);
                }
                else if (input == "4")
                {
                    SelectEmployeeRecordById(connectionString);
                }
                else if (input == "5")
                {
                    UpdateEmployeeRecord(connectionString);
                }
                else if (input == "0")
                {
                    exitRequested = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }

        static void PrintCustomMenu()
        {
            
            Console.WriteLine("1. Print all records");
            Console.WriteLine("2. Insert new record");
            Console.WriteLine("3. Delete record");
            Console.WriteLine("4. Select record by ID");
            Console.WriteLine("5. Update record");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

        static void PrintAllEmployeeRecords(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["ID"]} {reader["FirstName"]} {reader["LastName"]} {reader["Email"]} {reader["PrimaryPhoneNumber"]} {reader["SecondaryPhoneNumber"]} {reader["CreatedBy"]} {reader["CreatedOn"]} {reader["ModifiedBy"]} {reader["ModifiedOn"]}");
            }

            reader.Close();
            conn.Close();
        }

        static void InsertEmployeeRecord(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter primary phone: ");
            string primaryPhone = Console.ReadLine();
            Console.Write("Enter secondary phone: ");
            string secondaryPhone = Console.ReadLine();
            Console.Write("Enter created by: ");
            string createdBy = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn) VALUES (@FirstName, @LastName, @Email, @PrimaryPhone, @SecondaryPhone, @CreatedBy, GETDATE())", conn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PrimaryPhone", primaryPhone);
            cmd.Parameters.AddWithValue("@SecondaryPhone", secondaryPhone);
            cmd.Parameters.AddWithValue("@CreatedBy", createdBy);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Record inserted");
        }

        static void DeleteEmployeeRecord(string connectionString)
        {
            Console.Write("Enter ID of record to delete: ");
            int id = int.Parse(Console.ReadLine());

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Record deleted");
            }
            else
            {
                Console.WriteLine("Record not found");
            }
        }

        static void SelectEmployeeRecordById(string connectionString)
        {
            Console.Write("Enter ID to search: ");
            int id = int.Parse(Console.ReadLine());

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"{reader["ID"]} {reader["FirstName"]} {reader["LastName"]} {reader["Email"]} {reader["PrimaryPhoneNumber"]} {reader["SecondaryPhoneNumber"]} {reader["CreatedBy"]} {reader["CreatedOn"]} {reader["ModifiedBy"]} {reader["ModifiedOn"]}");
            }
            else
            {
                Console.WriteLine("Record not found");
            }

            reader.Close();
            conn.Close();
        }

        static void UpdateEmployeeRecord(string connectionString)
        {
            Console.Write("Enter ID of record to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter primary phone: ");
            string primaryPhone = Console.ReadLine();
            Console.Write("Enter secondary phone: ");
            string secondaryPhone = Console.ReadLine();
            Console.Write("Enter created by: ");
            string createdBy = Console.ReadLine();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET Email = @Email,FirstName = @FirstName,LastName = @LastName,PrimaryPhoneNumber=@PrimaryPhone,SecondaryPhoneNumber=@SecondaryPhone,CreatedBy=@CreatedBy, ModifiedOn = GETDATE() WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@PrimaryPhone", primaryPhone);
            cmd.Parameters.AddWithValue("@SecondaryPhone", secondaryPhone);
            cmd.Parameters.AddWithValue("@CreatedBy", createdBy);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Record updated");
            }
            else
            {
                Console.WriteLine("Record not found");
            }
        }
    }
}
