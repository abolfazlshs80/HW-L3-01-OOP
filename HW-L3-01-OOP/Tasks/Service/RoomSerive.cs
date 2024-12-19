using HW_L3_01_OOP.Tasks.Factory_Method.Class;
using HW_L3_01_OOP.Tasks.Factory_Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_L3_01_OOP.Tools.ConsoleDesign;
using Question4;

namespace HW_L3_01_OOP.Tasks.Service
{
    public class RoomSerive
    {
   
        Hospital hospitalManager = Hospital.Instance;

        Organ OrganManager = Organ.Instance;

        private PatientService patientService;

        public RoomSerive(PatientService patientService)
        {
            this.patientService = patientService;
        }
        public void CreateDoctor()
        {
            
            // Patient.Create();
            // doctor.Create();

        }

        public void ListRoom()
        {
            



            Console.Clear();
            ConsoleDesign.MenuForTable("List Of Doctor");
            Console.ResetColor();
            ConsoleDesign.ContentRoomForTable();
            Console.ResetColor();
            foreach (var item in hospitalManager.Rooms)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        public void DeletePatientFromRoom()
        {
            Console.Clear();
            ConsoleDesign.MenuForTable("Delete Patient Form hospital");
            Console.ResetColor();
         
            string patientId = (string)ConsoleDesign.InputValidation("Please Enter your  patientId : ", false);
            var patient = patientService.GetPatient(patientId);
            if (patient!=null)
            {
                hospitalManager.DischargePatient(patient);

                ConsoleDesign.Message("Deleted Patient From Hospital successfulyy",ConsoleColor.DarkGreen);
            
            }
            else
            {
                ConsoleDesign.Message("Deleted Patient From Hospital successfulyy", ConsoleColor.Red);
            }
          
          //  hospitalManager.DischargePatient();



        
       
            Console.ReadKey();
            
        }
    }
}
