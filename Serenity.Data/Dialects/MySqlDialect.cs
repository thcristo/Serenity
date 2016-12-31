using System;

namespace Serenity.Data
{
    public class MySqlDialect : SqlDialect
    {
        public static readonly ISqlDialect Instance = new MySqlDialect();

        public override bool CanUseOffsetFetch
        {
            get
            {
                return true;
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
                return false;
            }
        }

        public override char CloseQuote
        {
            get
            {
                return '`';
            }
        }

        public override string ConcatOperator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string DateFormat
        {
            get
            {
                return "\\'yyyy-MM-dd\\'";
            }
        }

        public override string DateTimeFormat
        {
            get
            {
                return "\'yyyy-MM-dd HH:mm:ss.fff\'";
            }
        }

        public override bool IsLikeCaseSensitive
        {
            get
            {
                return false;
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
                return false;
            }
        }

        public override string OffsetFormat
        {
            get
            {
                return " OFFSET {0}";
            }
        }

        public override string OffsetFetchFormat
        {
            get
            {
                return " LIMIT {1} OFFSET {0}";
            }
        }

        public override char OpenQuote
        {
            get
            {
                return '`';
            }
        }

        public override string QuoteColumnAlias(string s)
        {
            return QuoteIdentifier(s);
        }

        public override string QuoteIdentifier(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (s.StartsWith("`") && s.EndsWith("`"))
                return s;

            return '`' + s + '`';
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
                return "LAST_INSERT_ID()";
            }
        }

        public override string SkipKeyword
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string TakeKeyword
        {
            get
            {
                return "LIMIT";
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
                return true;
            }
        }

        public override bool UseTakeAtEnd
        {
            get
            {
                return true;
            }
        }

        public override bool UseRowNum
        {
            get
            {
                return false;
            }
        }

        public override char ParameterPrefix
        {
            get
            {
                return '@';
            }
        }

        public override bool UseSequence
        {
            get
            {
                return false;
            }
        }

        public override string SelectSequenceExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanUseFieldAliasInSubquery
        {
            get
            {
                return true;
            }
        }

        public override string ServerType
        {
            get
            {
                return "MySql";
            }
        }
    }
}