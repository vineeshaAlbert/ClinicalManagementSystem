using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.ViewModel;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClinicalManagementSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnStrMVC");
        }

        public User Login(string username, string password)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("sp_LoginUser", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Username = reader["Username"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        RoleName = reader["RoleName"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during login: " + ex.Message);
            }
        }

            public List<UserViewModel> GetAllUsers()
        {
            var list = new List<UserViewModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new UserViewModel
                    {
                        UserId = (int)reader["UserId"],
                        EmployeeId = reader["EmployeeId"].ToString(),
                        Name = reader["Name"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleId = (int)reader["RoleId"],
                        RoleName = reader["RoleName"].ToString(),
                        IsActive = (bool)reader["IsActive"]
                    });
                }
            }
            return list;
        }

        public void AddUser(UserViewModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUserStatus(int userId, bool isActive)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET IsActive = @IsActive WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
