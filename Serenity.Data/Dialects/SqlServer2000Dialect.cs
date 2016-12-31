using System;

namespace Serenity.Data
{
    public class SqlServer2000Dialect : SqlDialect
    {
        public static readonly ISqlDialect Instance = new SqlServer2000Dialect();

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
                return false;
            }
        }

        public override char CloseQuote
        {
            get
            {
                return '[';
            }
        }

        public override string ConcatOperator
        {
            get
            {
                return " + ";
            }
        }

        public override string DateFormat
        {
            get
            {
                return "\\'yyyyMMdd\\'";
            }
        }

        public override string DateTimeFormat
        {
            get
            {
                return "\\'yyyy'-'MM'-'ddTHH':'mm':'ss'.'fff\\'";
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
                return true;
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
                return '[';
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

            if (s.StartsWith("[") && s.EndsWith("]"))
                return s;

            return '[' + s + ']';
        }

        public override string QuoteUnicodeString(string s)
        {
            if (s.IndexOf('\'') >= 0)
                return "N'" + s.Replace("'", "''") + "'";

            return "N'" + s + "'";
        }

        public override string ScopeIdentityExpression
        {
            get
            {
                return "SCOPE_IDENTITY()";
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
                return "TOP";
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
                return "SqlServer";
            }
        }
    }
}