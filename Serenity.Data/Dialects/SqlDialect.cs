using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.Data
{
    public abstract class SqlDialect : ISqlDialect
    {
        public abstract bool CanUseFieldAliasInSubquery { get; }
        public abstract bool CanUseOffsetFetch { get; }
        public abstract bool CanUseRowNumber { get; }
        public abstract bool CanUseSkipKeyword { get; }
        public abstract char CloseQuote { get; }
        public abstract string ConcatOperator { get; }
        public abstract string DateFormat { get; }
        public abstract string DateTimeFormat { get; }
        public abstract bool IsLikeCaseSensitive { get; }
        public abstract bool MultipleResultsets { get; }
        public abstract bool NeedsExecuteBlockStatement { get; }
        public abstract string OffsetFetchFormat { get; }
        public abstract string OffsetFormat { get; }
        public abstract char OpenQuote { get; }
        public abstract char ParameterPrefix { get; }
        public abstract string ScopeIdentityExpression { get; }
        public abstract string SelectSequenceExpression { get; }
        public abstract string SkipKeyword { get; }
        public abstract string TakeKeyword { get; }
        public abstract string TimeFormat { get; }
        public abstract bool UseDateTime2 { get; }
        public abstract bool UseReturningIdentity { get; }
        public abstract bool UseReturningIntoVar { get; }
        public abstract bool UseRowNum { get; }
        public abstract bool UseScopeIdentity { get; }
        public abstract bool UseSequence { get; }
        public abstract bool UseTakeAtEnd { get; }

        public abstract string QuoteColumnAlias(string s);
        public abstract string QuoteIdentifier(string s);
        public abstract string QuoteUnicodeString(string s);
        public virtual SqlDataTypeInfo SqlTypeNameToDataType(string sqlTypeName, int size)
        {
            var result = new SqlDataTypeInfo();

            if (sqlTypeName == SqlDataTypes.SqlNVarChar || sqlTypeName == SqlDataTypes.SqlNText || sqlTypeName == SqlDataTypes.SqlText || sqlTypeName == SqlDataTypes.SqlNChar ||
                sqlTypeName == SqlDataTypes.SqlVarChar || sqlTypeName == SqlDataTypes.SqlChar || sqlTypeName == SqlDataTypes.SqlBlobSubType1)
                result.DataType = "String";
            else if (sqlTypeName == SqlDataTypes.SqlInt || sqlTypeName == SqlDataTypes.SqlInteger || sqlTypeName == SqlDataTypes.SqlInt4)
                result.DataType = "Int32";
            else if (sqlTypeName == SqlDataTypes.SqlBigInt || sqlTypeName == SqlDataTypes.SqlInt8)
                result.DataType = "Int64";
            else if (sqlTypeName == SqlDataTypes.SqlMoney || sqlTypeName == SqlDataTypes.SqlDecimal || sqlTypeName == SqlDataTypes.SqlNumeric)
                result.DataType = "Decimal";
            else if (sqlTypeName == SqlDataTypes.SqlDateTime || sqlTypeName == SqlDataTypes.SqlDateTime2 || sqlTypeName == SqlDataTypes.SqlDate || sqlTypeName == SqlDataTypes.SqlSmallDateTime)
                result.DataType = "DateTime";
            else if (sqlTypeName == SqlDataTypes.SqlDateTimeOffset)
                result.DataType = "DateTimeOffset";
            else if (sqlTypeName == SqlDataTypes.SqlTime)
                result.DataType = "TimeSpan";
            else if (sqlTypeName == SqlDataTypes.SqlBit)
                result.DataType = "Boolean";
            else if (sqlTypeName == SqlDataTypes.SqlReal)
                result.DataType = "Single";
            else if (sqlTypeName == SqlDataTypes.SqlFloat || sqlTypeName == SqlDataTypes.SqlDouble || sqlTypeName == SqlDataTypes.SqlDoublePrecision)
                result.DataType = "Double";
            else if (sqlTypeName == SqlDataTypes.SqlSmallInt || sqlTypeName == SqlDataTypes.SqlTinyInt)
                result.DataType = "Int16";
            else if (sqlTypeName == SqlDataTypes.SqlUniqueIdentifier)
                result.DataType = "Guid";
            else if (sqlTypeName == SqlDataTypes.SqlVarBinary)
            {
                if (size == 0 || size > 256)
                    result.DataType = "Stream";
                else
                {
                    result.SpecificDataType = "byte[]";
                    result.DataType = "ByteArray";
                }
            }
            else if (sqlTypeName == SqlDataTypes.SqlTimestamp || sqlTypeName == SqlDataTypes.SqlRowVersion)
            {
                result.SpecificDataType = "byte[]";
                result.DataType = "ByteArray";
                result.IsNonUpdatable = true;
            }
            else
                result.DataType = "Stream";

            return result;
        }
    }
}
