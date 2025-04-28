using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Models
{
    internal class Log
    {
        private string _fileName;
        private SqlConnection _connection;

        public Log(string fileName)
        {
            _fileName = fileName;
        }

        public Log(SqlConnection connection)
        {
            _connection = connection;
        }


        public virtual void Write(string message)
        {
            Data.LoggingData.Logs.Add(DateTime.Now, message);

            if (!string.IsNullOrEmpty(_fileName))
            {
                using (StreamWriter sw = new StreamWriter(_fileName, true))
                {
                    sw.WriteLine(message);
                }
            }

            if (_connection != null)
            {
                _connection.Open();

                string query = "INSERT INTO Logs VALUES (@time, @message)";
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void DisplayLog()
        {
            foreach (var log in Data.LoggingData.Logs)
            {
                Console.WriteLine($"{log.Key}\t{log.Value}");
            }
        }

	}
}
