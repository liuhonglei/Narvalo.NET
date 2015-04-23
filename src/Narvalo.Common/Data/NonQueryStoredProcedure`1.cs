﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Data
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    public abstract partial class NonQueryStoredProcedure<TParameters>
    {
        private readonly string _connectionString;
        private readonly string _name;

        protected NonQueryStoredProcedure(string connectionString, string name)
        {
            Require.NotNullOrEmpty(connectionString, "connectionString");
            Require.NotNullOrEmpty(name, "name");

            _connectionString = connectionString;
            _name = name;
        }

        protected string ConnectionString
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                return _connectionString;
            }
        }

        protected string Name
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);

                return _name;
            }
        }

        public int Execute(TParameters values)
        {
            Contract.Requires(values != null);

            int retval;

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = CreateCommand_(connection))
                {
                    AddParameters(command.Parameters.AssumeNotNull(), values);

                    connection.Open();
                    retval = command.ExecuteNonQuery();
                }
            }

            return retval;
        }

        protected abstract void AddParameters(SqlParameterCollection parameters, TParameters values);

        [SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities",
            Justification = "[Intentionally] The Code Analysis error is real, but we expect the consumer of this class to use a named SQL procedure.")]
        private SqlCommand CreateCommand_(SqlConnection connection)
        {
            Promise.NotNull(connection, "Null guard for a private method call.");
            Contract.Ensures(Contract.Result<SqlCommand>() != null);

            SqlCommand tmpCmd = null;
            SqlCommand cmd = null;

            try
            {
                tmpCmd = new SqlCommand(Name, connection);
                tmpCmd.CommandType = CommandType.StoredProcedure;

                cmd = tmpCmd;
                tmpCmd = null;
            }
            finally
            {
                if (tmpCmd != null)
                {
                    tmpCmd.Dispose();
                }
            }

            return cmd;
        }
    }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

    [ContractClass(typeof(NonQueryStoredProcedureContract<>))]
    public abstract partial class NonQueryStoredProcedure<TParameters>
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(_connectionString != null);
            Contract.Invariant(_connectionString.Length != 0);
            Contract.Invariant(_name != null);
            Contract.Invariant(_name.Length != 0);
        }
    }

    [ContractClassFor(typeof(NonQueryStoredProcedure<>))]
    internal abstract class NonQueryStoredProcedureContract<TResult> : NonQueryStoredProcedure<TResult>
    {
        protected NonQueryStoredProcedureContract(string connectionString, string name)
            : base(connectionString, name) { }

        protected override void AddParameters(SqlParameterCollection parameters, TResult values)
        {
            Contract.Requires(parameters != null);
            Contract.Requires(values != null);
        }
    }

#endif
}
