using Lesson1WPF.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public class PgDb
    {
        private readonly NpgsqlConnection _workConnection;
        private readonly NpgsqlCommand _sqlGetMessagesCommand;

        public PgDb()
        {
            _workConnection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=Qwerty123;Database=MailsAndSenders;CommandTimeOut=5000;Pooling=true");

            _sqlGetMessagesCommand = new NpgsqlCommand("select id, name, value from messages where id < :id and value != :value");
            _sqlGetMessagesCommand.Parameters.Add(new NpgsqlParameter("id", DbType.Int32));
            _sqlGetMessagesCommand.Parameters.Add(new NpgsqlParameter("value", DbType.String));
        }
        public List<Message> Messages
        {
            get
            {
                var result = new List<Message>();

                _sqlGetMessagesCommand.Connection = _workConnection;
                _sqlGetMessagesCommand.Parameters["id"].Value = 1000;
                _sqlGetMessagesCommand.Parameters["value"].Value = "testString";

                _workConnection.Open();
                var npgSqlDataReader = _sqlGetMessagesCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        try
                        {
                            var messageId = dbDataRecord.GetInt32(0);
                            var messageName = dbDataRecord.GetString(1);
                            var messageValue = dbDataRecord.GetString(2);

                            var message = new Message() {Id = messageId, Name = messageName, Value = messageValue };
                            result.Add(message);
                        }
                        catch (Exception exception)
                        {
                        }

                    }
                }
                npgSqlDataReader.Close();


                return result;
            }
        }
    }
}
