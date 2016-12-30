using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.Data.Settings
{
    public class TablePrefixSettings
    {
        public Dictionary<string, string> ModulePrefixes { get; set; }

        public string PrefixTable(string tableName, string moduleName)
        {
            if (this.ModulePrefixes == null || string.IsNullOrWhiteSpace(moduleName) || string.IsNullOrWhiteSpace(tableName)
                || !this.ModulePrefixes.ContainsKey(moduleName))
            {
                return tableName;
            }
            else
            {
                var prefix = this.ModulePrefixes[moduleName];
                if (string.IsNullOrWhiteSpace(prefix))
                {
                    return tableName;
                }
                else
                {
                    var start = prefix + "_";

                    if (tableName.StartsWith(start, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return tableName;
                    }
                    else
                    {
                        return start + tableName;
                    }
                }
            }
        }
    }
}
