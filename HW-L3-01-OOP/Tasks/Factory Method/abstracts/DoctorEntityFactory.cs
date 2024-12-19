using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Factory_Method
{
    public abstract class DoctorEntityFactory
    {
        public abstract IDoctorEntity CreateDoctorEntity();

    }
}
