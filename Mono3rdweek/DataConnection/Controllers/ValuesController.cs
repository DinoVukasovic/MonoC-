using DataConnection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataConnection.Controllers
{
    public class ValuesController : ApiController
    {
        private static string connectionString = "Data Source=LAPTOP-1P438MBR;Initial Catalog=Hospital;Integrated Security=True";

        [HttpGet]
        public HttpResponseMessage Get()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Patient;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Patient> patients = new List<Patient>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient();
                        patient.Id = reader.GetGuid(0);
                        patient.Name = reader.GetString(1);
                        patient.Surname = reader.GetString(2);
                        patient.DateOfBirth = reader.GetDateTime(3);
                        patient.CityId = reader.GetGuid(4);
                        patient.Illness = reader.IsDBNull(5) ? null : reader.GetString(5);
                        patients.Add(patient);
                    }
                    reader.Close();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, patients);
            }
        }

        [Route("api/values/get-by-id/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Patient WHERE Id=@id;", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                Patient patient = new Patient();
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
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Patient WHERE Id=@id;", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int numberOfAffectedRows = command.ExecuteNonQuery();
                if (numberOfAffectedRows > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, id);
                }
            }
            
        }
        [HttpPost]
        public HttpResponseMessage Post(Patient patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Patient values(@Id, @Name, @Surname, @DateOfBirth,@CityId, @Illness)", connection);
                patient.Id = Guid.NewGuid();
                command.Parameters.AddWithValue("@Id",patient.Id);
                command.Parameters.AddWithValue("@Name", patient.Name);
                command.Parameters.AddWithValue("@Surname", patient.Surname);
                command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@CityId", patient.CityId);
                command.Parameters.AddWithValue("@Illness", patient.Illness);

                connection.Open();

                int numberOfAffectedRows = command.ExecuteNonQuery();
                if (numberOfAffectedRows > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Created a new patient");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Uanble to create new patient");
                }

            }
            
        }
        [HttpPut]
        public HttpResponseMessage Update(Guid id, Patient patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand commandSelect = new SqlCommand("SELECT * FROM Patient where Id=@id", connection);
                commandSelect.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = commandSelect.ExecuteReader();
                Patient currentPatient = new Patient();
                if (!reader.HasRows)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Patient found");
                }

                reader.Read();

                reader.Read();
                patient.Id = reader.GetGuid(0);
                patient.Name = reader.GetString(1);
                patient.Surname = reader.GetString(2);
                patient.DateOfBirth = reader.GetDateTime(3);
                patient.CityId = reader.GetGuid(4);
                patient.Illness = reader.IsDBNull(5) ? null : reader.GetString(5);
                reader.Close();

                SqlCommand commandEdit = new SqlCommand("UPDATE Patient SET Name=@Name, Surname=@Surname, DateOfBirth=@DateOfBirth, CityId=@CityId, Illness=@Illness WHERE Id=@id", connection);
                commandEdit.Parameters.AddWithValue("@Id", id);
                commandEdit.Parameters.AddWithValue("@Name", string.IsNullOrWhiteSpace(patient.Name) ? currentPatient.Name : patient.Name);
                commandEdit.Parameters.AddWithValue("@Surname", string.IsNullOrWhiteSpace(patient.Surname) ? currentPatient.Surname : patient.Surname);
                commandEdit.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(string.IsNullOrWhiteSpace(patient.DateOfBirth.ToString()) ? currentPatient.DateOfBirth : patient.DateOfBirth));
                commandEdit.Parameters.AddWithValue("@CityId", Guid.Parse(string.IsNullOrWhiteSpace(patient.CityId.ToString()) ? currentPatient.CityId.ToString() : patient.CityId.ToString()));
                commandEdit.Parameters.AddWithValue("@Illness", string.IsNullOrWhiteSpace(patient.Illness) ? currentPatient.Illness : patient.Illness);
               
                int numberOfAffectedRows = commandEdit.ExecuteNonQuery();
                if (numberOfAffectedRows > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to update Patient");
                }


            }
        }
    }
}