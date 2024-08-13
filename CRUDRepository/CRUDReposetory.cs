using System.Data;
using CRUDModels;
using CRUDRepository.Interface;
using Microsoft.Data.SqlClient;

namespace CRUDRepository
{
    public class CRUDReposetory : ICrudReposetory
    {
        private string GetDbConnectionString()
        {
            return "Server=ACU-HYD-LT-841;Database=ANGULAR;Integrated Security=true;TrustServerCertificate=True";
        }

        public void AddStudent(CreateViewModel student)
        {
            using (SqlConnection con = new SqlConnection(this.GetDbConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(this.GetDbConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<CreateViewModel> GetAllStudent()
        {
            List<CreateViewModel> lstStudent = new List<CreateViewModel>();
            using (SqlConnection con = new SqlConnection(this.GetDbConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CreateViewModel student = new CreateViewModel();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Mobile = rdr["Mobile"].ToString();
                    student.Address = rdr["Address"].ToString();

                    lstStudent.Add(student);
                }
            }
            return lstStudent;
        }

        public CreateViewModel GetStudentData(int? id)
        {
            CreateViewModel student = new CreateViewModel();

            using (SqlConnection con = new SqlConnection(this.GetDbConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Mobile = rdr["Mobile"].ToString();
                    student.Address = rdr["Address"].ToString();
                }
            }
            return student;
        }

        public void UpdateStudent(CreateViewModel student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.GetDbConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}