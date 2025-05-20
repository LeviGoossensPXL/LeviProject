using System.Data;
using Microsoft.Data.SqlClient;

namespace ClassLibraryLevi.Data.Framework
{
    internal abstract class SqlServer
    {
        private SqlDataAdapter _adapter;
        public abstract string TableName { get; }

        protected SelectResult SelectStatement(SqlCommand selectCommand)
        {
            var result = new SelectResult();
            try
            {
                using (SqlConnection connection = new SqlConnection(SqlSettings.ConnectionString))
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    _adapter = new SqlDataAdapter(selectCommand);
                    _adapter.Fill(result.DataTable);
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected SelectResult SelectStatement()
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM {TableName}");
            return SelectStatement(command);
        }

        protected InsertResult InsertStatement(SqlCommand insertCommand, bool hasAutoIncrementId = true) // auto increment id is for table that have no auto incrementing id
        {
            InsertResult result = new InsertResult();
            try
            {
                using (SqlConnection connection = new SqlConnection(SqlSettings.ConnectionString))
                {
                    if (hasAutoIncrementId)
                    {
                        insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                        insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    }
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    if (hasAutoIncrementId)
                    {
                        int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                        result.NewId = newId;
                    }
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected UpdateResult UpdateStatement(SqlCommand updateCommand)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                using (SqlConnection connection = new SqlConnection(SqlSettings.ConnectionString))
                {
                    updateCommand.Connection = connection;
                    connection.Open();
                    result.NumberOfRecordsAffected = updateCommand.ExecuteNonQuery();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected DeleteResult DeleteStatement(SqlCommand deleteCommand)
        {
            DeleteResult result = new DeleteResult();
            try
            {
                using (SqlConnection connection = new SqlConnection(SqlSettings.ConnectionString))
                {
                    deleteCommand.Connection = connection;
                    connection.Open();
                    result.NumberOfRecordsAffected = deleteCommand.ExecuteNonQuery();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
