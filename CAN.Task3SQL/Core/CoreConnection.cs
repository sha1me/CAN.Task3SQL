using CAN.Task3SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CAN.Task3SQL.Core
{
    internal class CoreConnection
    {
        public static Task3SQLEntities db = new Task3SQLEntities();
        public static Frame CoreFrame { get; set; }
    }
}
