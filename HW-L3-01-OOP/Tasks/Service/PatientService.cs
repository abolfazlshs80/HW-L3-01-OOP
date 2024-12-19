using HW_L3_01_OOP.Tasks.Factory_Method.Class;
using HW_L3_01_OOP.Tasks.Factory_Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_L3_01_OOP.Tasks.Factory_Method.Class.Patient;
using HW_L3_01_OOP.Tools.ConsoleDesign;
using HW_L3_01_OOP.Tools;
using Question4;

namespace HW_L3_01_OOP.Tasks.Service
{
    public class PatientService
    {
        private readonly PatientFactory _factory;
        private readonly Hospital hospitalManager = Hospital.Instance;

        public PatientService(PatientFactory factory)
        {
            _factory = factory;

        }

        public void CreatePatient()
        {
            //IPatientEntity Patient = _factory.CreatePatientEntity();

            IPatientEntity IPatient = _factory.CreatePatientEntity();
            Console.Clear();
            ConsoleDesign.MenuForTable("Create New Patient");
            bool status = true;
            string PatientId = RandomString.GenerateRandomString(10);
            string NationalId = (string)ConsoleDesign.InputValidation("Please Enter your  NationalId : ", false);
            string Name = (string)ConsoleDesign.InputValidation("Please enter  your  Name : ", false);
            string MedicalHistory = (string)ConsoleDesign.InputValidation("please enter  your MedicalHistory : ", false);
            while (status)
            {
                if (string.IsNullOrEmpty(NationalId))
                {
                    NationalId = (string)ConsoleDesign.InputValidation("Please Enter your  NationalId : ", false);
                }
                else if (string.IsNullOrEmpty(Name))
                {
                    Name = (string)ConsoleDesign.InputValidation("Please enter  your  Name : ", false);
                }
                else if (string.IsNullOrEmpty(MedicalHistory))
                {
                    MedicalHistory = (string)ConsoleDesign.InputValidation("please enter  your MedicalHistory Line name1-name2-name3 : ", false);
                }
                else
                {
                    Patient Patient = IPatient.Get(PatientId);
                    if (Patient != null)
                    {
                        PatientId = RandomString.GenerateRandomString(10);
                    }
                    else
                    {

                        status = false;
                    }
                }

            }
            hospitalManager.AdmitPatient(new Patient(PatientId, MedicalHistory, Name, NationalId));
            //hospitalManager.AdmitPatient(new Patient());


            ConsoleDesign.MenuForTable("Created new Patient", ConsoleColor.Green);
            Console.ReadKey();
            // Patient.Create();

        }
        public void ListPatient()
        {
            IPatientEntity Patient = _factory.CreatePatientEntity();
           
     //    hospitalManager.DischargePatient(Patient.List().FirstOrDefault());
            Console.Clear();
           
            ConsoleDesign.MenuForTable("List Of Patient");
            Console.ResetColor();
            ConsoleDesign.ContentPatientForTable();
            Console.ResetColor();
            foreach (var item in Patient.List())
            {
                Console.WriteLine(item);

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
            // Patient.Create();

        }

        public Patient GetPatient(string Id)
        {
            IPatientEntity Patient = _factory.CreatePatientEntity();

            foreach (var item in Patient.List())
            {
                if (item.PatientId.Equals(Id))
                {
                    return item;
                }

            }

            return null;
        }
    }
}
