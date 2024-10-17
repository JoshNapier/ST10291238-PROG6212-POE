using System.Data.SqlClient;

namespace ST10291238_PROG6212_POE.Models
{
    public class ClaimsTable
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-db;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ClaimId { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
        public string Programme { get; set; }
        public DateTime ClaimDate { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public double ClaimAmount => HourlyRate * HoursWorked;
        public string Status { get; set; } = "Pending";
        public string Notes { get; set; }

        public int insert_claim()
        {
            con.Open();
            string query = "INSERT INTO ClaimsTable (LecturerName, LecturerSurname, Programme, ClaimDate, HourlyRate, HoursWorked, ClaimAmount, Status, Notes) VALUES (@LecturerName, @LecturerSurname, @Programme, @ClaimDate, @HourlyRate, @HoursWorked, @ClaimAmount, @Status, @Notes)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@LecturerName", LecturerName);
            cmd.Parameters.AddWithValue("@LecturerSurname", LecturerSurname);
            cmd.Parameters.AddWithValue("@Programme", Programme);
            cmd.Parameters.AddWithValue("@ClaimDate", ClaimDate);
            cmd.Parameters.AddWithValue("@HourlyRate", HourlyRate);
            cmd.Parameters.AddWithValue("@HoursWorked", HoursWorked);
            cmd.Parameters.AddWithValue("@ClaimAmount", ClaimAmount);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            int rows = cmd.ExecuteNonQuery();
            con.Close();
            return rows;
        }
    }
}
