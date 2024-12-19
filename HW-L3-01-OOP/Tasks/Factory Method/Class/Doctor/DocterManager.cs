using Question4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Factory_Method.Class
{
    public class DocterManager:IDoctorEntity
    {
        private Hospital HospitalManager;
        private Organ OrganManager;
        public DocterManager()
        {
            HospitalManager = Hospital.Instance;
            OrganManager = Organ.Instance;
        }
        public void Create(Doctor doctor)
        {
            HospitalManager.Doctors.Add(doctor);
        }

        public List<Doctor> List()
        {
            return HospitalManager.Doctors ?? new List<Doctor>();
        }

        public Doctor Get(string DoctorId)
        {
            Question4.Doctor LstDoctor = new Question4.Doctor();

            foreach (var doctor in HospitalManager.Doctors ?? new List<Doctor>())
            {
               
                    if (DoctorId == doctor.DoctorId)
                    {

                        return doctor;
                    }
                
            }

            return null;
        }


        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
