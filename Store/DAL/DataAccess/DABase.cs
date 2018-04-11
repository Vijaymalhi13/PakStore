using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using eLearning.Common.Utils;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using eLearning.DAL.MakerChecker;
using System.Resources;
using System.Reflection;
using System.Text;


namespace eLearning.DAL.DataAccess
{
    public class DABase
    {
        private DbTransaction Transaction { get; set; }
        static Database db = DatabaseFactory.CreateDatabase();
        DbConnection conn;
        private Logger logger = Logger.getInstance();
        private static readonly string MODULE_NAME = "DABase";
        protected string dbDateFunction = "GETDATE()";
        public SchemaManager SchemaManager { get; set; }
        public DefaultManager DefaultManager { get; set; }
        public TokenProvider TokenProvider { get; set; }
        public DABase()
        {
            this.DefaultManager = new DefaultManager(DABase.db);
            this.TokenProvider = new TokenProvider(DABase.db);
            this.SchemaManager = new SchemaManager(DABase.db);
            //
            // TODO: Add constructor logic here
            //
            //if(db == null)
            //    db = DatabaseFactory.CreateDatabase();


        }
        public DABase(Database dbname)
        {
            db = dbname;
        }
        protected Database DB
        {
            get { return db; }
        }

        //===========================================================================
        /// <summary>
        /// Take the SQL as input and execute it on database. 
        /// Normally use to persist data in DB.
        /// </summary>
        /// <param name="queryString">DML SQL statements e.g Insert / Update / Delete </param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string queryString)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + queryString);
                return db.ExecuteNonQuery(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", queryString, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(DbCommand cmd)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + cmd.CommandText);
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", cmd.CommandText, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(DbCommand cmd, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + cmd.CommandText);
                return db.ExecuteNonQuery(cmd, transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", cmd.CommandText, exception);
                throw exception;
            }
        }
        protected int ExecuteNonQuery(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteNonQuery", "QUERY|" + queryString);
                return db.ExecuteNonQuery(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteNonQuery", queryString, exception);
                throw exception;
            }
        }

        protected object ExecuteScalar(string queryString)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteScalar", "QUERY|" + queryString);
                return db.ExecuteScalar(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteScalar", queryString, exception);
                throw exception;
            }
        }

        protected object ExecuteScalar(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteScalar", "QUERY|" + queryString);
                return db.ExecuteScalar(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteScalar", queryString, exception);
                throw exception;
            }
        }

      static  protected DataSet ExecuteDataSet(string queryString)
        {
            try
            {
               // logger.Debug(MODULE_NAME, "ExecuteDataSet", "QUERY|" + queryString);
                return db.ExecuteDataSet(db.GetSqlStringCommand(queryString));
            }
            catch (Exception exception)
            {
               // logger.Error(MODULE_NAME, "ExecuteDataSet", queryString, exception);
                throw exception;
            }
        }
        protected DataSet ExecuteDataSet(string queryString, DbTransaction transaction)
        {
            try
            {
                logger.Debug(MODULE_NAME, "ExecuteDataSet", "QUERY|" + queryString);
                return db.ExecuteDataSet(db.GetSqlStringCommand(queryString), transaction);
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteDataSet", queryString, exception);
                throw exception;
            }
        }
        protected void ExecuteBulkCopy(DataTable dt, string tableName)
        {
            try
            {
                using (DbConnection connection = db.CreateConnection())
                {
                    connection.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy((SqlConnection)connection))
                    {
                        copy.DestinationTableName = tableName;
                        //Define column mappings
                        foreach (DataColumn col in dt.Columns)
                        {
                            copy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }
                        copy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error(MODULE_NAME, "ExecuteBulkCopy", exception);
                throw exception;
            }
        }

        //public DataSet ExecuteStoredProcedure(string procedureName, List<StoredProcedureParams> parametersList)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand(procedureName);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    foreach (var item in parametersList)
        //    {
        //        if (item.ParamType == DbType.Object)
        //        {
        //            SqlParameter sqlParam = new SqlParameter(item.ParamName, item.ParamObject);
        //            sqlParam.SqlDbType = SqlDbType.Structured;
        //            sqlParam.TypeName = item.TypeName;
        //            cmd.Parameters.Add(sqlParam);
        //            //db.AddInParameter(cmd, item.ParamName, (DbType)item.ParamType, item.ParamObject);
        //        }
        //        else
        //        {
        //            if (item.ParamType.Equals(DbType.DateTime) && (item.ParamValue == null || item.ParamValue.Length <= 0))
        //            {
        //                item.ParamValue = DBNull.Value.ToString();
        //            }
        //            db.AddInParameter(cmd, item.ParamName, (DbType)item.ParamType, item.ParamValue);
        //        }
        //    }

        //    DataSet ds = db.ExecuteDataSet(cmd);
        //    if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {

        //        if (ds.Tables[0].Columns.Contains("ERROR_MESSAGE"))
        //        {
        //            throw new Exception("Error Occured While executing the stored procedure at break point:" + ds.Tables[0].Rows[0]["ERROR_MESSAGE"].ToString());
        //        }
        //    }
        //    return ds;
        //}

        public DbTransaction CreateTransaction()
        {
            conn = db.CreateConnection();
            conn.Open();
            return conn.BeginTransaction();
        }
        public void CommitTransaction(DbTransaction transaction)
        {
            transaction.Commit();
            conn.Close();
        }
        public void RollbackTransaction(DbTransaction transaction)
        {
            transaction.Rollback();
            conn.Close();
        }

        /// <summary>
        /// This method uses SearhOptions class to apply pagination and sorting 
        /// on existing queries, following points to be considered before using
        /// this methods.
        /// 
        /// 1. Query should not have (TOP n *)
        /// 2. Query should not have ORDER BY clause
        /// 3. Query may or may not have WHERE clause
        /// 4. In SearchOptions default SortExpression is required
        /// 
        /// </summary>
        /// <param name="sql">Existing query, please see the description for details.</param>
        /// <param name="options">Search options to apply on query.</param>
        /// <returns></returns>
        public string ApplySearchOptions(string sql, SearchOptions options)
        {
            string template = @"ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY;";
            string appliedSql = sql + " " + string.Format(template,
                                options.SortExpression,
                                options.SortDirection,
                                options.PageIndex * options.PageSize,
                                options.PageSize);
            return appliedSql;
        }

        #region General Functions 
        public static string RectifyValues(string stringWithSingleQuote)
        {
            stringWithSingleQuote = stringWithSingleQuote.Trim();
            StringBuilder buffer = new StringBuilder(stringWithSingleQuote);
            buffer = buffer.Replace("\'", "\''");
            //buffer = buffer.Replace(">","&gt;");
            //buffer = buffer.Replace("<","&lt;");
            //buffer = buffer.Replace("\"","&quote;");

            return buffer.ToString();
        }
        #endregion 

        #region GetFieldValue
        protected object GetFieldValue(DataTable dt, string fieldName)
        {
            return GetFieldValue(dt, fieldName, DBNull.Value);
        }
        protected object GetFieldValue(DataRow dr, string fieldName)
        {
            return GetFieldValue(dr.Table, dr, fieldName, "null");
        }
        protected object GetFieldValue(DataRow dr, string fieldName, object defValue)
        {
            return GetFieldValue(dr.Table, dr, fieldName, defValue);
        }
        protected object GetFieldValue(DataTable dt, string fieldName, object defValue)
        {
            return GetFieldValue(dt, dt.Rows[0], fieldName, defValue);
        }
        /// <summary>
        /// Use this method if you have a nullable string column
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="encloseQuotation"></param>
        /// <returns></returns>
        protected object GetFieldValue(DataRow dr, string fieldName, bool encloseQuotation)
        {
            if (encloseQuotation)
                //enclose quotation marks if the string type column has a value
                if (dr.Table.Columns.Contains(fieldName) && dr.Table.Columns[fieldName].DataType == Type.GetType(
                    "System.String") && !Convert.IsDBNull(dr[fieldName]))
                    return "'" + RectifyValues(dr[fieldName].ToString()) + "'";

            return GetFieldValue(dr.Table, dr, fieldName, "null");
        }
        protected object GetFieldValue(object val, bool encloseQuotation)
        {
            if (val == null)
                return "NULL";

            if (encloseQuotation)
                if (val.GetType() == typeof(string) && !Convert.IsDBNull(val))
                    return "'" + RectifyValues(val.ToString()) + "'";

            return GetFieldValue(val, "NULL");
        }
        protected object GetFieldValue(object val)
        {
            return GetFieldValue(val, "NULL");
        }
        protected object GetFieldValue(object val, object defValue)
        {
            object retValue = null;
            if (val == null)
                retValue = defValue;
            else if (val.GetType() == Type.GetType("System.Boolean"))
                retValue = Convert.ToBoolean(val) ? 1 : 0;
            else if (val.GetType() == Type.GetType("System.DateTime"))
                retValue = Util.ConvertDateTimeForSQL(Convert.ToDateTime(val));
            else if (val.GetType() == Type.GetType("System.String"))
                retValue = RectifyValues(val.ToString());
            else
                retValue = val;

            return retValue;
        }
        protected object GetFieldValue(DataTable dt, DataRow dr, string fieldName, object defValue)
        {
            if (dt.Columns.Contains(fieldName) && dr[fieldName] != DBNull.Value)
                return GetFieldValue(dr[fieldName], defValue);
            else
                return defValue;
        }
        #endregion
    }
}