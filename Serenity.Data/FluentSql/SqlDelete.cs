﻿namespace Serenity.Data
{
    using Settings;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Dictionary = System.Collections.Generic.Dictionary<string, object>;

    /// <summary>
    ///   Class to generate queries of form <c>DELETE FROM tablename WHERE [conditions]</c>.</summary>
    public sealed class SqlDelete : QueryWithParams, IFilterableQuery
    {
        private string _tableName;
        private StringBuilder _where;

        private void Initialize(string tableName)
        {
            if (tableName == null)
                throw new ArgumentNullException("tableName");

            _tableName = tableName;
            _where = new StringBuilder();
        }

        /// <summary>
        /// <param name="dialect"></param>
        ///   Creates a new SqlDelete query.</summary>
        /// <param name="tableName">
        ///   Table to delete records from (required).</param>
        ///   <param name="moduleName"></param>
        public SqlDelete(ISqlDialect dialect, string tableName, string moduleName) : base(dialect)
        {
            Initialize(Config.Get<TablePrefixSettings>().PrefixTable(tableName, moduleName));
        }

        /// <summary>
        ///   Adds a new condition to the WHERE part of the query with an "AND" between.</summary>
        /// <param name="condition">
        ///   Condition.</param>
        /// <returns>
        ///   SqlDelete object itself.</returns>
        public SqlDelete Where(string condition)
        {
            if (condition == null || condition.Length == 0)
                throw new ArgumentNullException("condition");

            condition = SqlUpdate.RemoveT0Reference(condition);

            if (_where.Length > 0)
                _where.Append(SqlKeywords.And);

            _where.Append(condition);

            return this;
        }

        /// <summary>
        ///   Adds a new condition to the WHERE part of the query with an "AND" between.</summary>
        /// <param name="condition">
        ///   Condition.</param>
        /// <returns>
        ///   SqlDelete object itself.</returns>
        void IFilterableQuery.Where(string condition)
        {
            Where(condition);
        }

        /// <summary>
        ///   Adds new conditions to the WHERE part of the query with an "AND" between.</summary>
        /// <param name="conditions">
        ///   Conditions.</param>
        /// <returns>
        ///   SqlDelete object itself.</returns>
        public SqlDelete Where(params string[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
                throw new ArgumentNullException("conditions");

            foreach (var condition in conditions)
                Where(condition);

            return this;
        }

        /// <summary>
        ///   Gets string representation of the query.</summary>
        /// <returns>
        ///   String representation of the query.</returns>
        public override string ToString()
        {
            return Format(_tableName, _where.ToString());
        }

        /// <summary>
        ///   Formats a DELETE query.</summary>
        /// <param name="tableName">
        ///   Tablename.</param>
        /// <param name="where">
        ///   Where part of the query.</param>
        /// <returns>
        ///   Formatted query.</returns>
        public static string Format(string tableName, string where)
        {
            if (tableName == null || tableName.Length == 0)
                throw new ArgumentNullException(tableName);

            StringBuilder sb = new StringBuilder("DELETE FROM ", 24 + where.Length);
            sb.Append(tableName);

            if (!String.IsNullOrEmpty(where))
            {
                sb.Append(" WHERE ");
                sb.Append(where);
            }
            return sb.ToString();
        }
    }
}