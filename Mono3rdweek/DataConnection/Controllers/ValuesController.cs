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
    }
}