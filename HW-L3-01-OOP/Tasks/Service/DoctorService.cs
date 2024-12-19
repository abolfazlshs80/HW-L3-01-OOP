using HW_L3_01_OOP.Tasks.Factory_Method.Class;
using HW_L3_01_OOP.Tasks.Factory_Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_L3_01_OOP.Tools.ConsoleDesign;
using Question4;
using HW_L3_01_OOP.Tools;
using HW_L3_01_OOP.Tasks.Factory_Method.Class.Patient;
using HW_L3_01_OOP.Tasks.Strategy_Pattern;
using System.Xml.Linq;

namespace HW_L3_01_OOP.Tasks.Service
{
    public class DoctorService
    {
        private readonly PatientFactory _Patientfactory;
        private readonly DoctorFactory _factory;

        public DoctorService(DoctorFactory factory, PatientFactory Patientfactory)
        {
            _factory = factory;
            _Patientfactory = Patientfactory;
        }

        public void CreateDoctor()
        {
            IDoctorEntity Idoctor = _factory.CreateDoctorEntity();
            Console.Clear();
            ConsoleDesign.MenuForTable("Create New Doctor");
            bool status = true;
            string Id = RandomString.GenerateRandomString(10);
            string FirstName = (string)ConsoleDesign.InputValidation("Please Enter your  FirstName : ", false);
            string LastName = (string)ConsoleDesign.InputValidation("Please enter  your  LastName : ", false);
            int AgeTemp = int.Parse(ConsoleDesign.InputValidation("Please enter  your  Age : ", true).ToString());
            byte Age=0;
            string Specialization = (string)ConsoleDesign.InputValidation("please enter  your Specialization : ", false);
            while (status)
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    FirstName = (string)ConsoleDesign.InputValidation("Please Enter your  FirstName : ", false);
                }
                else if (string.IsNullOrEmpty(LastName))
                {
                    LastName = (string)ConsoleDesign.InputValidation("Please enter  your  LastName : ", false);
                }
                else if (AgeTemp > 120|| AgeTemp < 0||!byte.TryParse(AgeTemp.ToString(),out Age))
                
                {
                    AgeTemp=     int.Parse(ConsoleDesign.InputValidation("Please enter  your  Age : ", true).ToString());
                }
                else if (string.IsNullOrEmpty(Specialization))
                {
                    Specialization = (string)ConsoleDesign.InputValidation("Please enter  your  Specialization : ", false);
                }
                else
                {
                    Doctor doctor = Idoctor.Get(Id);
                    if (doctor != null)
                    {
                        Id = RandomString.GenerateRandomString(10);
                    }
                    else
                    {

                        status = false;
                    }
                }
              
            }
            
            Idoctor.Create(new Doctor(LastName,FirstName,Id,Specialization,Age));
           
            ConsoleDesign.MenuForTable("Created new Doctor", ConsoleColor.Green);
            Console.ReadKey();
           

        }

        public void Handel()
        {
            IDoctorEntity Idoctor = _factory.CreateDoctorEntity();
            IPatientEntity Ipatient = _Patientfactory.CreatePatientEntity();
            Console.Clear();
            ConsoleDesign.MenuForTable("Create New Doctor");
            bool status = true;
            string IdDocter = (string)ConsoleDesign.InputValidation("Please Enter your  IdDocter : ", false);
            string IdPatient = (string)ConsoleDesign.InputValidation("Please enter  your  IdPatient : ", false);

            while (status)
            {
                Doctor doctor = Idoctor.Get(IdDocter);
                Patient patient = Ipatient.Get(IdPatient);
                if (doctor==null)
                {
                    IdDocter = (string)ConsoleDesign.InputValidation("Please Enter your  IdDocter : ", false);
                }
               
                else if (patient==null)
                {
                     IdPatient = (string)ConsoleDesign.InputValidation("Please enter  your  IdPatient : ", false);
                }
                else
                {     
                    var doctorContext = new DoctorContext();

                    // بیمار با مشکلات قلبی
                    doctorContext.SetSpecializationStrategy(new CardiologyStrategy());
                    
                    status = false;
                    string desc = "defalt";
                    switch (doctor.Specialization)
                    {
                        case "Cardiology":
                            
                            doctorContext.SetSpecializationStrategy(new CardiologyStrategy());
                           
                            break;
                        case "Pediatrics":
                            doctorContext.SetSpecializationStrategy(new PediatricsStrategy());
                            break;
                        case "Surgeon":
                            doctorContext.SetSpecializationStrategy(new SurgeonStrategy());
                            break;
                        default:
                            doctorContext.SetSpecializationStrategy(null);
                            break;
                    }
                  
                  //  patient.AddToMedicalHistory(desc);
                    doctorContext.HandlePatient(patient.Name);
                    desc = doctorContext.Desc;
                    doctor.Diagnose(patient, desc);
                    Console.ReadKey();


                }
                
            }
        }

        public void ListDoctor()
        {
            IDoctorEntity doctor = _factory.CreateDoctorEntity();



            Console.Clear();
            ConsoleDesign.MenuForTable("List Of Doctor");
            Console.ResetColor();
            ConsoleDesign.ContentDoctorForTable();
            Console.ResetColor();
            foreach (var item in doctor.List())
            {
                Console.WriteLine(item);

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
