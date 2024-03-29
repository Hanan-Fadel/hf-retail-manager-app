﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace HFRetailManagerDataManagerClassLibrary.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        //To load data from database
        public List<T> LoadData<T, U> (string storedProcedure, U parameters, string connectionStringName)

        {
            string connectionString = GetConnectionString(connectionStringName);

           
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
               
                List<T> rows = connection.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;

            }

        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)

        {
            string connectionString = GetConnectionString(connectionStringName);


            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            }

        }

    }
}
