using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Infrastructure.Tools.Configuration;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace System.Persistence.Core
{
    public class ConnectionBase : IConnectionBase
    {
        //Cadena de conexion
        private string strConexionSQLExigoWeb1 = null;
        private string strConexionSQLFuxion1 = null;
        private string strConexionSQLReporting = null;
        private string strConexionSQLOffix = null;
        private string strConexionSQLFuxion = null;
        private string strConexionMySqlFuxion = null;
        private string strConexionSQLFuxionPenny = null;

        //Constante de conexion
        SqlConnection DataConnectionSQLExigoWeb1 = new SqlConnection();
        SqlConnection DataConnectionSQLFuxion1 = new SqlConnection();
        SqlConnection DataConnectionSQLReporting = new SqlConnection();
        SqlConnection DataConnectionSQLOffix = new SqlConnection();
        SqlConnection DataConnectionSQLFuxion = new SqlConnection();
        MySqlConnection DataConnectionMySqlFuion = new MySqlConnection();
        SqlConnection DataConnectionSQLFuxionPenny = new SqlConnection();

        //Clases imagen del appsetting.config
        private readonly AppSettings _appSettings;

        //Opciones de conexión
        public enum enuTypeDataBase
        {
            SQLFuxionReporting,
            SQLFuxionOffix,
            SQLFuxion,
            SQLFuxionPenny,
            SQLExigoWeb1,
            SQLFuxion1,
            MySqlFuxion
        }

        public enum enuTypeExecute
        {
            ExecuteNonQuery,
            ExecuteReader
        }

        public DbParameterCollection ParamsCollectionResult { get; set; }

        public ConnectionBase(IConfiguration Configuration)
        {
            //Mapeo conexiones

            //Sql 1 ExigoWeb
            this.strConexionSQLExigoWeb1 = Configuration["AppSettings:ConnectionStringSQLExigoWeb1"];
            DataConnectionSQLExigoWeb1.ConnectionString = this.strConexionSQLExigoWeb1;

            //Sql 1 DbFuxion
            this.strConexionSQLFuxion1 = Configuration["AppSettings:ConnectionStringSQLFuxion1"];
            DataConnectionSQLFuxion1.ConnectionString = this.strConexionSQLFuxion1;

            //Reporting
            this.strConexionSQLReporting = Configuration["AppSettings:ConnectionStringSQLReporting"];
            DataConnectionSQLReporting.ConnectionString = this.strConexionSQLReporting;

            //Offix
            this.strConexionSQLOffix = Configuration["AppSettings:ConnectionStringSQLOffix"];
            DataConnectionSQLOffix.ConnectionString = this.strConexionSQLOffix;

            //Fuxion
            this.strConexionSQLFuxion= Configuration["AppSettings:ConnectionStringSQLFuxion"];
            DataConnectionSQLFuxion.ConnectionString = this.strConexionSQLFuxion;

            //Fuxion Penny
            this.strConexionSQLFuxionPenny = Configuration["AppSettings:ConnectionStringSQLPenny"];
            DataConnectionSQLFuxionPenny.ConnectionString = this.strConexionSQLFuxionPenny;

            //Mysql Fuxion
            this.strConexionMySqlFuxion = Configuration["AppSettings:ConnectionStringMySqlFuxion"];
            DataConnectionMySqlFuion.ConnectionString = this.strConexionMySqlFuxion;

        }

        public DbConnection ConnectionGet(enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxionOffix)
        {
            DbConnection DataConnection = null;
            switch (typeDataBase)
            {
                case enuTypeDataBase.SQLFuxionOffix:
                    DataConnection = DataConnectionSQLOffix;
                    break;
                case enuTypeDataBase.SQLFuxionReporting:
                    DataConnection = DataConnectionSQLReporting;
                    break;
                case enuTypeDataBase.SQLFuxion:
                    DataConnection = DataConnectionSQLFuxion;
                    break;
                case enuTypeDataBase.MySqlFuxion:
                    DataConnection = DataConnectionMySqlFuion;
                    break;
                case enuTypeDataBase.SQLExigoWeb1:
                    DataConnection = DataConnectionSQLExigoWeb1;
                    break;
                case enuTypeDataBase.SQLFuxion1:
                    DataConnection = DataConnectionSQLFuxion1;
                    break;
                case enuTypeDataBase.SQLFuxionPenny:
                    DataConnection = DataConnectionSQLFuxionPenny;
                    break;
                default:
                    break;
            }
            return DataConnection;
        }

        public DbDataReader ExecuteByStoredProcedure(string nameStore,
                IEnumerable<DbParameter> parameters = null,
                enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxionOffix,
                enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
                )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                //z = ParamsCollectionResult;
                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;
        }
        public DbDataReader ExecuteByStoredProcedureExigoWeb(string nameStore,
               IEnumerable<DbParameter> parameters = null,
               enuTypeDataBase typeDataBase = enuTypeDataBase.SQLExigoWeb1,
               enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
               )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                //z = ParamsCollectionResult;
                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;
        }

        public DbDataReader ExecuteByStoredProcedurePenny(string nameStore,
               IEnumerable<DbParameter> parameters = null,
               enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxionPenny,
               enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
               )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                //z = ParamsCollectionResult;
                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;
        }
        public DbDataReader ExecuteByStoredProcedureFuxion1(string nameStore,
               IEnumerable<DbParameter> parameters = null,
               enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxion1,
               enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader
               )
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = nameStore;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                //z = ParamsCollectionResult;
                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;
        }
        public DbDataReader ExecuteBySentence(string query,
                            enuTypeDataBase typeDataBase = enuTypeDataBase.SQLFuxionOffix,
                            enuTypeExecute typeExecute = enuTypeExecute.ExecuteReader)
        {
            DbConnection DataConnection = ConnectionGet(typeDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = query;

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == enuTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();

                cmdCommand.Connection.Close();
                myReader = null;
            }
            return myReader;

        }
    }
}
