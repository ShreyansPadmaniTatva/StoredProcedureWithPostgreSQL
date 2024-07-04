using Dapper;
using NewsDemo.Common;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace NewsDemo.Data
{
    public class DapperService : IDapperService
    {
        #region Properties
        //private static readonly string ConnStringInfoCar = ConfigItems.ConnectionStringInfoCar;
        //private static readonly string ConnStringFFM2 = ConfigItems.ConnectionStringFFM2;
        private static readonly string connString = "Host=localhost;Database=HalloDoc;Username=postgres;Password=1936";

        public object DapperHelpers { get; private set; } = null!;

        private readonly int defaultCommandTimeout = 3000;

        #endregion

        #region Methods
        /// <summary>
        /// It will check whether Stored procedure needs to call another read only database or not.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static string UseConnectionString()
        {
            //if (Enums.ExternalDatabase.Infocar.GetHashCode() == dbName)
            //{
            //    return ConnStringInfoCar;
            //}
            //else
            //{
            //    return ConnStringFFM2;
            //}
            return connString;
        }

        public object ExecuteScalar(string commandText,
                           object? param = null,
                           NpgsqlTransaction? transaction = null,
                           int? commandTimeout = null)
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.ExecuteScalar(commandText,
                                        param: param,
                                        transaction: transaction,
                                        commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                        commandType: CommandType.StoredProcedure);
            }
        }

        public int Execute(string commandText,
                           object? param = null,
                           NpgsqlTransaction? transaction = null,
                           int? commandTimeout = null,
                           bool IsSP = false)
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                if (IsSP)
                {
                    return _db.Execute(commandText,
                                        param: param,
                                        transaction: transaction,
                                        commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                        commandType: CommandType.StoredProcedure);
                }
                else
                {
                    return _db.Execute(commandText, param);
                }
            }
        }

        public IEnumerable<TEntity> Query<TEntity>(string commandText,
                                                   object? param = null) where TEntity : class
        {

            var connString = UseConnectionString();
            using (IDbConnection _db = new NpgsqlConnection(connString))
            {
                return _db.Query<TEntity>(commandText, param: param , commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<TEntity>> QuerySPAsync<TEntity>(string storedProcedure,
            object? param = null,
            dynamic? outParam = null,
            NpgsqlTransaction? transaction = null,
            int? commandTimeout = null) where TEntity : class
        {
            var connString = UseConnectionString();
            using (IDbConnection _db = new NpgsqlConnection(connString))
            {
                var res = await _db.QueryAsync<TEntity>(storedProcedure,
                    param: param,
                    transaction: transaction,
                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                    commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        public IEnumerable<T1> QueryOneToMany<T1, T2>(string storedProcedure,
                                                    System.Func<T1, T2, T1> map,
                                                    object? param = null,
                                                    dynamic? outParam = null,
                                                    NpgsqlTransaction? transaction = null,
                                                    bool buffered = true,
                                                    string splitOn = "",
                                                    int? commandTimeout = null) where T1 : class
                                                    where T2 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T1>(storedProcedure,
                                    map: map,
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<TEntity> QuerySP<TEntity>(string storedProcedure,
                                                object? param = null,
                                                dynamic? outParam = null,
                                                NpgsqlTransaction? transaction = null,
                                                bool buffered = true,
                                                int? commandTimeout = null) where TEntity : class
        {
            var connString = UseConnectionString();
            using (IDbConnection _db = new NpgsqlConnection(connString))
            {
                return _db.Query<TEntity>(storedProcedure,
                                        param: param,
                                        transaction: transaction,
                                        buffered: buffered,
                                        commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                        commandType: CommandType.StoredProcedure);
            }
        }


        public IEnumerable<T1> QuerySP<T1, T2>(string storedProcedure,
                                                    object? param = null,
                                                    dynamic? outParam = null,
                                                    NpgsqlTransaction? transaction = null,
                                                    bool buffered = true,
                                                    string splitOn = "",
                                                    int? commandTimeout = null)
                                                    where T1 : class
                                                    where T2 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T1>(storedProcedure,
                                    (arg, t2) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T1> QuerySP<T1, T2, T3>(string storedProcedure,
                                                   object? param = null,
                                                   dynamic? outParam = null,
                                                   NpgsqlTransaction? transaction = null,
                                                   bool buffered = true,
                                                   string splitOn = "",
                                                   int? commandTimeout = null)
                                                   where T1 : class
                                                   where T2 : class
                                                   where T3 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T3, T1>(storedProcedure,
                                    (arg, t2, t3) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        arg.GetType().GetProperty(typeof(T3).Name)?.SetValue(arg, t3);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T1> QuerySP<T1, T2, T3, T4>(string storedProcedure,
                                                  object? param = null,
                                                  dynamic? outParam = null,
                                                  NpgsqlTransaction? transaction = null,
                                                  bool buffered = true,
                                                  string splitOn = "",
                                                  int? commandTimeout = null)
                                                  where T1 : class
                                                  where T2 : class
                                                  where T3 : class
                                                  where T4 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T3, T4, T1>(storedProcedure,
                                    (arg, t2, t3, t4) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        arg.GetType().GetProperty(typeof(T3).Name)?.SetValue(arg, t3);
                                        arg.GetType().GetProperty(typeof(T4).Name)?.SetValue(arg, t4);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5>(string storedProcedure,
                                                  object? param = null,
                                                  dynamic? outParam = null,
                                                  NpgsqlTransaction? transaction = null,
                                                  bool buffered = true,
                                                  string splitOn = "",
                                                  int? commandTimeout = null)
                                                  where T1 : class
                                                  where T2 : class
                                                  where T3 : class
                                                  where T4 : class
                                                  where T5 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T3, T4, T5, T1>(storedProcedure,
                                    (arg, t2, t3, t4, t5) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        arg.GetType().GetProperty(typeof(T3).Name)?.SetValue(arg, t3);
                                        arg.GetType().GetProperty(typeof(T4).Name)?.SetValue(arg, t4);
                                        arg.GetType().GetProperty(typeof(T5).Name)?.SetValue(arg, t5);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5, T6>(string storedProcedure,
                                                 object? param = null,
                                                 dynamic? outParam = null,
                                                 NpgsqlTransaction? transaction = null,
                                                 bool buffered = true,
                                                 string splitOn = "",
                                                 int? commandTimeout = null)
                                                 where T1 : class
                                                 where T2 : class
                                                 where T3 : class
                                                 where T4 : class
                                                 where T5 : class
                                                 where T6 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T3, T4, T5, T6, T1>(storedProcedure,
                                    (arg, t2, t3, t4, t5, t6) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        arg.GetType().GetProperty(typeof(T3).Name)?.SetValue(arg, t3);
                                        arg.GetType().GetProperty(typeof(T4).Name)?.SetValue(arg, t4);
                                        arg.GetType().GetProperty(typeof(T5).Name)?.SetValue(arg, t5);
                                        arg.GetType().GetProperty(typeof(T6).Name)?.SetValue(arg, t6);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5, T6, T7>(string storedProcedure,
                                                object? param = null,
                                                dynamic? outParam = null,
                                                NpgsqlTransaction? transaction = null,
                                                bool buffered = true,
                                                string splitOn = "",
                                                int? commandTimeout = null)
                                                where T1 : class
                                                where T2 : class
                                                where T3 : class
                                                where T4 : class
                                                where T5 : class
                                                where T6 : class
                                                where T7 : class
        {

            using (IDbConnection _db = new NpgsqlConnection(ConfigItems.ConnectionString))
            {
                return _db.Query<T1, T2, T3, T4, T5, T6, T7, T1>(storedProcedure,
                                    (arg, t2, t3, t4, t5, t6, t7) =>
                                    {
                                        arg.GetType().GetProperty(typeof(T2).Name)?.SetValue(arg, t2);
                                        arg.GetType().GetProperty(typeof(T3).Name)?.SetValue(arg, t3);
                                        arg.GetType().GetProperty(typeof(T4).Name)?.SetValue(arg, t4);
                                        arg.GetType().GetProperty(typeof(T5).Name)?.SetValue(arg, t5);
                                        arg.GetType().GetProperty(typeof(T6).Name)?.SetValue(arg, t6);
                                        arg.GetType().GetProperty(typeof(T7).Name)?.SetValue(arg, t7);
                                        return arg;
                                    },
                                    param: param,
                                    transaction: transaction,
                                    buffered: buffered,
                                    splitOn: splitOn,
                                    commandTimeout: (commandTimeout > 0 ? commandTimeout : defaultCommandTimeout),
                                    commandType: CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}
