using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question4;

namespace HW_L3_01_OOP.Tasks.Factory_Method
{
    public interface IDoctorEntity
    {
        void Create( Doctor doctor);
        List<Doctor> List();
        Doctor Get(string DoctorId);
        void Delete();
    }
}
