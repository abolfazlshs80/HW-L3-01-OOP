using Question4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Factory_Method.Class.Patient
{
    internal class PatientManager : IPatientEntity
    {
        private Hospital HospitalManager;
        private Organ OrganManager;
        public PatientManager()
        {
            HospitalManager = Hospital.Instance;
            OrganManager = Organ.Instance;
        }
        public void Create()
        {
            Console.WriteLine("created Patient");
        }

        public void Create(Question4.Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Question4.Patient> List()
        {
            Question4.Patient p = new Question4.Patient();
            

            List<Question4.Patient>LstPatient=new List<Question4.Patient>();

            foreach (var room in HospitalManager.Rooms??new List<Room>())
            {
                foreach (var patient in room.Patients)
                {
                    patient.Room=room;
                }
                LstPatient.AddRange(room.Patients);

            }

            return LstPatient;
        }

        public Question4.Patient Get(string PatientId)
        {
          Question4.Patient LstPatient = new Question4.Patient();

            foreach (var room in HospitalManager.Rooms ?? new List<Room>())
            {
                foreach (var patient in room.Patients)
                {
                    if (PatientId ==patient.PatientId)
                    {

                        return patient;
                    }
                    patient.Room = room;
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
