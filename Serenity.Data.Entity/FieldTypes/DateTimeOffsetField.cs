﻿using System;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;

namespace Serenity.Data
{
    public sealed class DateTimeOffsetField : GenericValueField<DateTimeOffset>
    {
        public DateTimeOffsetField(ICollection<Field> collection, string name, LocalText caption = null, int size = 0, FieldFlags flags = FieldFlags.Default, 
            Func<Row, DateTimeOffset?> getValue = null, Action<Row, DateTimeOffset?> setValue = null)
            : base(collection, FieldType.DateTime, name, caption, size, flags, getValue, setValue)
        {
        }

        public static DateTimeOffsetField Factory(ICollection<Field> collection, string name, LocalText caption, int size, FieldFlags flags,
            Func<Row, DateTimeOffset?> getValue, Action<Row, DateTimeOffset?> setValue)
        {
            return new DateTimeOffsetField(collection, name, caption, size, flags, getValue, setValue);
        }

#if !SILVERLIGHT
        public override void GetFromReader(IDataReader reader, int index, Row row)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (reader.IsDBNull(index))
                _setValue(row, null);
            else
            {
                DateTimeOffset dto;
                var value = reader.GetValue(index);
                if (value is DateTime)
                    dto = (DateTimeOffset)(DateTime)value;
                else if (value is DateTimeOffset)
                    dto = (DateTimeOffset)value;
                else
                    dto = DateTimeOffset.Parse(value.ToString());

                _setValue(row, dto);
            }

            if (row.tracking)
                row.FieldAssignedValue(this);
        }
#endif

        public new DateTimeOffset? this[Row row]
        {
            get
            {
                CheckUnassignedRead(row);
                return _getValue(row);
            }
            set
            {
                if (value != null)
                    _setValue(row, value.Value);
                else
                    _setValue(row, value);
                if (row.tracking)
                    row.FieldAssignedValue(this);
            }
        }

        public override object AsObject(Row row)
        {
            CheckUnassignedRead(row);
            return _getValue(row);
        }

        public override void AsObject(Row row, object value)
        {
            if (value == null)
                _setValue(row, null);
            else
                _setValue(row, (DateTimeOffset)value);

            if (row.tracking)
                row.FieldAssignedValue(this);
        }

        public override void ValueToJson(JsonWriter writer, Row row, JsonSerializer serializer)
        {
            var value = _getValue(row);
            if (value.HasValue)
                writer.WriteValue(value.Value.ToString("o"));
            else
                writer.WriteNull();
        }

        public override void ValueFromJson(JsonReader reader, Row row, JsonSerializer serializer)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            switch (reader.TokenType)
            {
                case JsonToken.Null:
                case JsonToken.Undefined:
                    _setValue(row, null);
                    break;
                case JsonToken.Date:
                    var obj = reader.Value;
                    DateTimeOffset value;
                    if (obj is DateTime)
                        value = (DateTimeOffset)(DateTime)obj;
                    else if (obj is DateTimeOffset)
                        value = (DateTimeOffset)obj;
                    else
                        value = DateTimeOffset.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
                    _setValue(row, value);
                    break;
                case JsonToken.String:
                    var s = ((string)reader.Value).TrimToNull();
                    if (s == null)
                        _setValue(row, null);
                    else
                        _setValue(row, DateTimeOffset.Parse(s, CultureInfo.InvariantCulture));
                    break;
                default:
                    throw JsonUnexpectedToken(reader);
            }

            if (row.tracking)
                row.FieldAssignedValue(this);
        }
    }
}