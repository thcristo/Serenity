using System;

namespace Serenity.Data
{
    public class FirebirdDialect : SqlDialect
    {
        public static readonly FirebirdDialect Instance = new FirebirdDialect();

        public override bool CanUseOffsetFetch
        {
            get
            {
                return false;
            }
        }

        public override bool CanUseRowNumber
        {
            get
            {
                return false;
            }
        }

        public override bool CanUseSkipKeyword
        {
            get
            {
                return true;
            }
        }

        public override char CloseQuote
        {
            get
            {
                return '"';
            }
        }

        public override string ConcatOperator
        {
            get
            {
                return " || ";
            }
        }

        public override string DateFormat
        {
            get
            {
                return "\\'yyyy'-'MM'-'dd\\'";
            }
        }

        public override string DateTimeFormat
        {
            get
            {
                return "\\'yyyy'-'MM'-'dd HH':'mm':'ss'.'fff\\'";
            }
        }

        public override bool IsLikeCaseSensitive
        {
            get
            {
                return true;
            }
        }

        public override bool MultipleResultsets
        {
            get
            {
                return false;
            }
        }

        public override bool NeedsExecuteBlockStatement
        {
            get
            {
                return true;
            }
        }

        public override string OffsetFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string OffsetFetchFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char OpenQuote
        {
            get
            {
                return '"';
            }
        }

        public override string QuoteColumnAlias(string s)
        {
            return QuoteIdentifier(s);
        }

        public override string QuoteIdentifier(string s)
        {
            /*
            if (string.IsNullOrEmpty(s))
                return s;

            if (s.StartsWith("\"") && s.EndsWith("\""))
                return s;

            return '"' + s + '"';
            */
            return s;
        }

        public override string QuoteUnicodeString(string s)
        {
            if (s.IndexOf('\'') >= 0)
                return "'" + s.Replace("'", "''") + "'";

            return "'" + s + "'";
        }

        public override string ScopeIdentityExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string SkipKeyword
        {
            get
            {
                return "SKIP";
            }
        }

        public override string TakeKeyword
        {
            get
            {
                return "FIRST";
            }
        }

        public override string TimeFormat
        {
            get
            {
                return "\\'HH':'mm':'ss\\'";
            }
        }

        public override bool UseDateTime2
        {
            get
            {
                return false;
            }
        }

        public override bool UseReturningIdentity
        {
            get
            {
                return false;
            }
        }

        public override bool UseReturningIntoVar
        {
            get
            {
                return false;
            }
        }

        public override bool UseScopeIdentity
        {
            get
            {
                return false;
            }
        }

        public override bool UseTakeAtEnd
        {
            get
            {
                return false;
            }
        }

        public override bool UseRowNum
        {
            get
            {
                return false;
            }
        }

        public override char ParameterPrefix { get { return '@'; } }

        public override bool UseSequence
        {
            get
            {
                return true;
            }
        }

        public override string SelectSequenceExpression
        {
            get
            {
                return "SELECT GEN_ID({0},1) FROM RDB$DATABASE";
            }
        }

        public override bool CanUseFieldAliasInSubquery
        {
            get
            {
                return false;
            }
        }

        public override SqlDataTypeInfo SqlTypeNameToDataType(string sqlTypeName, int size)
        {
            if (sqlTypeName == SqlDataTypes.SqlTimestamp)
            {
                return new SqlDataTypeInfo
                {
                    DataType = "DateTime"
                };
            }
            else
            {
                return base.SqlTypeNameToDataType(sqlTypeName, size);
            }
        }

        public override string ServerType
        {
            get
            {
                return "Firebird";
            }
        }
    }
}