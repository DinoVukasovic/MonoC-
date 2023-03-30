using DataConnection.Model;
using DataConnection.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public static string connectionString = "Data Source=LAPTOP-1P438MBR;Initial Catalog=Hospital;Integrated Security=True";

        public async Task<PatientModel> GetPatient(Guid id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Patient WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    PatientModel patient = new PatientModel();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        patient.Id = reader.GetGuid(0);
                        patient.Name = reader.GetString(1);
                        patient.Surname = reader.GetString(2);
                        patient.DateOfBirth = reader.GetDateTime(3);
                        patient.CityId = reader.GetGuid(4);
                        patient.Illness = reader.IsDBNull(5) ? null : reader.GetString(5);

                        reader.Close();
                        return patient;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> AddNewPatient(PatientModel patient)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using(connection)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Patient values(@Id, @Name, @Surname, @DateOfBirth,@CityId, @Illness)", connection);
                    command.Parameters.AddWithValue("@Id", patient.Id);
                    command.Parameters.AddWithValue("@Name", patient.Name);
                    command.Parameters.AddWithValue("@Surname", patient.Surname);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@CityId", patient.CityId);
                    command.Parameters.AddWithValue("@Illness", patient.Illness);

                    connection.Open();
                    int numberOfAffectedRows = await command.ExecuteNonQueryAsync();
                    if (numberOfAffectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditPatient(Guid id, PatientModel patient)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand commandEdit = new SqlCommand("UPDATE Patient SET Name=@Name, Surname=@Surname, DateOfBirth=@DarteOfBirth, CityId=@CityId, Illness=@Illness", connection);

                    commandEdit.Parameters.AddWithValue("@Id", id);
                    commandEdit.Parameters.AddWithValue("@Name", patient.Name);
                    commandEdit.Parameters.AddWithValue("@Surname", patient.Surname);
                    commandEdit.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    commandEdit.Parameters.AddWithValue("@CityId", patient.CityId);
                    commandEdit.Parameters.AddWithValue("@Illness", patient.Illness);

                    connection.Open();

                    int numberOfAffectedRows = await commandEdit.ExecuteNonQueryAsync();
                    if (numberOfAffectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePatient (Guid id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Patient WHERE Id=@id;", connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    int numberOfAffectedRows = await command.ExecuteNonQueryAsync();
                    if (numberOfAffectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } catch(Exception)
            {
                return false;
            }
        }
    }
}

