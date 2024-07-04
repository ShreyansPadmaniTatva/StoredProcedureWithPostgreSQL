using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDemo.Data
{
    public interface IDapperService
    {
        object ExecuteScalar(string commandText,
                           object? param = null,
                           NpgsqlTransaction? transaction = null,
                           int? commandTimeout = null);

        int Execute(string commandText,
                           object? param = null,
                           NpgsqlTransaction? transaction = null,
                           int? commandTimeout = null,
                           bool IsSP = false);

        IEnumerable<TEntity> Query<TEntity>(string commandText,
                                                    object? param = null) where TEntity : class;

        Task<IEnumerable<TEntity>> QuerySPAsync<TEntity>(string storedProcedure,
            dynamic? param = null,
            dynamic? outParam = null,
            NpgsqlTransaction? transaction = null,
            int? commandTimeout = null) where TEntity : class;

        IEnumerable<T1> QueryOneToMany<T1, T2>(string storedProcedure,
                                                    System.Func<T1, T2, T1> map,
                                                    object? param = null,
                                                    dynamic? outParam = null,
                                                    NpgsqlTransaction? transaction = null,
                                                    bool buffered = true,
                                                    string splitOn = "",
                                                    int? commandTimeout = null)
                                                    where T1 : class
                                                    where T2 : class;

        IEnumerable<TEntity> QuerySP<TEntity>(string storedProcedure,
                                                  dynamic? param = null,
                                                  dynamic? outParam = null,
                                                  NpgsqlTransaction? transaction = null,
                                                  bool buffered = true,
                                                  int? commandTimeout = null) where TEntity : class;

        IEnumerable<T1> QuerySP<T1, T2>(string storedProcedure,
                                                     object? param = null,
                                                     dynamic? outParam = null,
                                                     NpgsqlTransaction? transaction = null,
                                                     bool buffered = true,
                                                     string splitOn = "",
                                                     int? commandTimeout = null)
                                                     where T1 : class
                                                     where T2 : class;

        IEnumerable<T1> QuerySP<T1, T2, T3>(string storedProcedure,
                                                   object? param = null,
                                                   dynamic? outParam = null,
                                                   NpgsqlTransaction? transaction = null,
                                                   bool buffered = true,
                                                   string splitOn = "",
                                                   int? commandTimeout = null)
                                                   where T1 : class
                                                   where T2 : class
                                                   where T3 : class;

        IEnumerable<T1> QuerySP<T1, T2, T3, T4>(string storedProcedure,
                                                 object? param = null,
                                                 dynamic? outParam = null,
                                                 NpgsqlTransaction? transaction = null,
                                                 bool buffered = true,
                                                 string splitOn = "",
                                                 int? commandTimeout = null)
                                                 where T1 : class
                                                 where T2 : class
                                                 where T3 : class
                                                 where T4 : class;

        IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5>(string storedProcedure,
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
                                                  where T5 : class;

        IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5, T6>(string storedProcedure,
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
                                                 where T6 : class;

        IEnumerable<T1> QuerySP<T1, T2, T3, T4, T5, T6, T7>(string storedProcedure,
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
                                                where T7 : class;
    }
}
