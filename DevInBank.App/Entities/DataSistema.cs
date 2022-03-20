using DevInBank.App.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class DataSistema
    {
        public static DateTime Data { get; private set; } = DateTime.Now;

        public static DateTime GetData()
        {
            return Data;
        }
        public static void SetData()
        {
            Data = DateTime.Now.AddMonths(36);
        }
    }
}
