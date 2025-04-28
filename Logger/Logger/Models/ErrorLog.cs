using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Models
{
    internal class ErrorLog : Log
    {
        public ErrorLog(string fileName) : base(fileName)
        {
        }

        public override void Write(string message)
        {
            base.Write("[ERROR] " + message);
        }
    }
}
