using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Feedback_Reminder
{  
        internal class Logger
        {
            internal static void Log(string message)
            {
                Console.WriteLine("[No_Feedback_Reminder] " + message);
            }
        }
}
