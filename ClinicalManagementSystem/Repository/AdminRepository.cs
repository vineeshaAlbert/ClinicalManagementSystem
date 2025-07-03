using ClinicalManagementSystem.Models;
using ClinicalManagementSystem.ViewModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace ClinicalManagementSystem.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnStrMVC");
        }

        // ===================== RECEPTIONIST =====================
        public List<Receptionist> GetReceptionists() => ExecuteList<Receptionist>("sp_GetReceptionists");

        public void AddReceptionist(StaffCreateViewModel r)
        {
            try
            {
                ExecuteNonQuery("sp_InsertReceptionist",
                    new SqlParameter("@Name", r.Name),
                    new SqlParameter("@Contact", r.Contact));

                // Optional: You could log or notify that insertion succeeded here
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting receptionist: " + ex.Message);
            }
        }


        public Receptionist GetReceptionistById(int id) =>
            ExecuteSingle<Receptionist>("sp_GetReceptionistById", new SqlParameter("@ReceptionistId", id));

        public void UpdateReceptionist(StaffCreateViewModel r) =>
            ExecuteNonQuery("sp_UpdateReceptionist",
                new SqlParameter("@ReceptionistId", r.ReceptionistId),
                new SqlParameter("@Name", r.Name),
                new SqlParameter("@Contact", r.Contact));

        public void DeactivateReceptionist(int id) =>
            ExecuteNonQuery("sp_DeactivateReceptionist", new SqlParameter("@ReceptionistId", id));

        // ===================== DOCTOR =====================
        public List<Doctor> GetDoctors() => ExecuteList<Doctor>("sp_GetDoctors");

        public void AddDoctor(StaffCreateViewModel d)
        {
            try
            {

                ExecuteNonQuery("sp_InsertDoctor",
                    new SqlParameter("@Name", d.Name),
                    new SqlParameter("@Contact", d.Contact));

                // Optional: You could log or notify that insertion succeeded here
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting receptionist: " + ex.Message);
            }
        }
        public Doctor GetDoctorById(int id) =>
            ExecuteSingle<Doctor>("sp_GetDoctorById", new SqlParameter("@DoctorId", id));

        public void UpdateDoctor(StaffCreateViewModel d) =>
            ExecuteNonQuery("sp_UpdateDoctor",
                new SqlParameter("@DoctorId", d.DoctorId),
                new SqlParameter("@Name", d.Name),
                new SqlParameter("@Contact", d.Contact));

        public void DeactivateDoctor(int id) =>
            ExecuteNonQuery("sp_DeactivateDoctor", new SqlParameter("@DoctorId", id));

        // ===================== PHARMACIST =====================
        public List<Pharmacist> GetPharmacists() => ExecuteList<Pharmacist>("sp_GetPharmacists");

        public void AddPharmacist(StaffCreateViewModel p)
        {
            try
            {

                ExecuteNonQuery("sp_InsertPharmacist",
                    new SqlParameter("@Name", p.Name),
                    new SqlParameter("@Contact", p.Contact));
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting pharmacist: " + ex.Message);
            }
        }

        public Pharmacist GetPharmacistById(int id) =>
            ExecuteSingle<Pharmacist>("sp_GetPharmacistById", new SqlParameter("@PharmacistId", id));

        public void UpdatePharmacist(StaffCreateViewModel p) =>
            ExecuteNonQuery("sp_UpdatePharmacist",
                new SqlParameter("@PharmacistId", p.PharmacistId),
                new SqlParameter("@Name", p.Name),
                new SqlParameter("@Contact", p.Contact));

        public void DeactivatePharmacist(int id) =>
            ExecuteNonQuery("sp_DeactivatePharmacist", new SqlParameter("@PharmacistId", id));

        // ===================== LAB TECHNICIAN =====================
        public List<Lab> GetLabTechnicians() => ExecuteList<Lab>("sp_GetLabTechnicians");

        public void AddLabTechnician(StaffCreateViewModel l)
        {
            try
            {

                ExecuteNonQuery("sp_InsertLabTechnician",
                    new SqlParameter("@Name", l.Name),
                    new SqlParameter("@Contact", l.Contact));
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting lab technician: " + ex.Message);
            }
        }

        public Lab GetLabTechnicianById(int id) =>
            ExecuteSingle<Lab>("sp_GetLabTechnicianById", new SqlParameter("@LabTechnicianId", id));

        public void UpdateLabTechnician(StaffCreateViewModel l) =>
            ExecuteNonQuery("sp_UpdateLabTechnician",
                new SqlParameter("@LabId", l.LabId),
                new SqlParameter("@Name", l.Name),
                new SqlParameter("@Contact", l.Contact));

        public void DeactivateLabTechnician(int id) =>
            ExecuteNonQuery("sp_DeactivateLabTechnician", new SqlParameter("@LabTechnicianId", id));

        // ===================== HELPERS =====================
        private List<T> ExecuteList<T>(string spName, params SqlParameter[] parameters) where T : new()
        {
            var list = new List<T>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(spName, conn) { CommandType = CommandType.StoredProcedure };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            var props = typeof(T).GetProperties();
            while (reader.Read())
            {
                var item = new T();
                foreach (var prop in props)
                {
                    if (!reader.HasColumn(prop.Name) || reader[prop.Name] is DBNull) continue;
                    prop.SetValue(item, reader[prop.Name]);
                }
                list.Add(item);
            }
            return list;
        }

        private T ExecuteSingle<T>(string spName, params SqlParameter[] parameters) where T : new()
        {
            return ExecuteList<T>(spName, parameters).FirstOrDefault();
        }

        private void ExecuteNonQuery(string spName, params SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(spName, conn) { CommandType = CommandType.StoredProcedure };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void UpdateUserStatus(int userId, bool isActive)
        {
            ExecuteNonQuery("sp_UpdateUserStatus",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@IsActive", isActive));
        }
    }

    public static class SqlDataReaderExtensions
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    


}
