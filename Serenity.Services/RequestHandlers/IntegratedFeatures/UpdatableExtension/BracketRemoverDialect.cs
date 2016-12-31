using Serenity.Data;
using System;

namespace Serenity.Services
{
    internal class BracketRemoverDialect : SqlDialect
    {
        public static readonly BracketRemoverDialect Instance = new BracketRemoverDialect();

        public override bool CanUseOffsetFetch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanUseRowNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanUseSkipKeyword
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char CloseQuote
        {
            get
            {
                return '\x1';
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
                throw new NotImplementedException();
            }
        }

        public override string DateTimeFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsLikeCaseSensitive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool MultipleResultsets
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool NeedsExecuteBlockStatement
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

        public override string OffsetFormat
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
                return '\x1';
            }
        }

        public override char ParameterPrefix
        {
            get
            {
                throw new NotImplementedException();
            }
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
                throw new NotImplementedException();
            }
        }

        public override string TakeKeyword
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string TimeFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseDateTime2
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseReturningIdentity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseReturningIntoVar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseRowNum
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseScopeIdentity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool UseTakeAtEnd
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string QuoteColumnAlias(string s)
        {
            return s;
        }

        public override string QuoteIdentifier(string s)
        {
            return s;
        }

        public override string QuoteUnicodeString(string s)
        {
            throw new NotImplementedException();
        }

        public override bool UseSequence
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public override string ServerType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}