using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Exception
{
  

    public class RoomFullException : System.Exception
    {
        // سازنده پیش‌فرض
        public RoomFullException()
            : base("The room does not have enough capacity.")
        {
        }

        // سازنده برای پیام سفارشی
        public RoomFullException(string message)
            : base(message)
        {
        }

        //// سازنده برای پیام و استثنای داخلی
        //public RoomFullException(string message, System.Exception innerException)
        //    : base(message, innerException)
        //{
        //}
    }
}
