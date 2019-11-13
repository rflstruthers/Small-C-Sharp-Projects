using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        //Connection string to School database
        private string _connectionString = @"Data Source=DESKTOP-S50JDVF\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        // GET: Student
        public ActionResult Index()
        {
            //SQL code that is sent to the database
            string queryString = "SELECT * FROM Students";

            //Empty list of Student data type to be populated by requested data from database
            List<Student> students = new List<Student>();

            //Only connect to the DB to do the operations specified in { }
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //Set command variable with parameters
                SqlCommand command = new SqlCommand(queryString, connection);
                //Open the connection to the DB
                connection.Open();
                //Read the table specified in the queryString
                SqlDataReader reader = command.ExecuteReader();

                //What to do while reading the table
                while (reader.Read())
                {
                    //Empty Student object
                    Student student = new Student();
                    //make entry from Id column in DB the Id parameter of the Student object
                    student.Id = Convert.ToInt32(reader["Id"]);
                    //make entry from FirstName column in DB the FirstName parameter of the Student object
                    student.FirstName = reader["FirstName"].ToString();
                    //make entry from LastName column in DB the LastName parameter of the Student object
                    student.LastName = reader["LastName"].ToString();
                    //Add the filled Student object to the Students list
                    students.Add(student);
                }
                //Close connection to DB
                connection.Close();
            }
            return View(students);
        }

        // GET: Student
        public ActionResult Add()
        {
            //Pulls up the Add.cshtml file
            return View();
        }

        //This is a Post method
        [HttpPost]
        public ActionResult Add(Student student)
        {
            //SQL adding data to Students Table
            string queryString = @"INSERT INTO Students (FirstName, LastName) Values (@FirstName, @LastName)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //protection so user doesnt mess up DB
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);

                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //search Students Table for desired Id
            string queryString = @"SELECT * FROM Students WHERE Id = @Id";
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //command with the SQL and connection parameters
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", SqlDbType.Int);

                command.Parameters["@Id"].Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["Firstname"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }
                connection.Close();
            }
            //pass student details to the View
            return View(student);
        }

        //takes Id of student as parameter and gets that student from the DB and passes it to the View
        public ActionResult Edit(int id)
        {
            string queryString = @"SELECT * FROM Students WHERE Id = @id";
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);

                command.Parameters["@id"].Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }
                connection.Close();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            string querystring = @"UPDATE Students SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(querystring, connection);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);

                command.Parameters["@Id"].Value = student.Id;
                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}