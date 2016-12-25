using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.Data
{
    public class SqlDataTypeInfo
    {
        public string DataType { get; set; }
        public string SpecificDataType { get; set; }
        public bool IsNonUpdatable { get; set; }
    }
}
