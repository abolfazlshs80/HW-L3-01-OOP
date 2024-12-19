using HW_L3_01_OOP.Tasks.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HW_L3_01_OOP.Tools.ConsoleDesign;

namespace Question4
{

    public class Organ
    {
        private static readonly Lazy<Organ> _instance =
            new Lazy<Organ>(() => new Organ());


        public static Organ Instance => _instance.Value;

        public List<Person> Peaple = new List<Person>();
        private Organ()
        {
            Peaple.AddRange(new List<Person>()
            {
                new Person { Name = "Alice", NationalId = "ID001", Age = 30 },
                new Person { Name = "Bob", NationalId = "ID002", Age = 25 },
                new Person { Name = "Charlie", NationalId = "ID003", Age = 35 },
                new Person { Name = "Diana", NationalId = "ID004", Age = 28 },
                new Person { Name = "Eve", NationalId = "ID005", Age = 40 },
                new Person { Name = "Frank", NationalId = "ID006", Age = 33 },
                new Person { Name = "Grace", NationalId = "ID007", Age = 22 },
                new Person { Name = "Hank", NationalId = "ID008", Age = 45 },
                new Person { Name = "Ivy", NationalId = "ID009", Age = 27 },
                new Person { Name = "Jack", NationalId = "ID010", Age = 36 }
            });
            Peaple.AddRange(new List<Patient>
            {
                new Patient { Name = "Alice", NationalId = "ID001", Age = 30, PatientId = "P001", MedicalHistory = new List<string>(){ "Flu, Cold"} },
                new Patient { Name = "Bob", NationalId = "ID002", Age = 25, PatientId = "P002", MedicalHistory = new List<string>(){"Asthma" }},
                new Patient { Name = "Charlie", NationalId = "ID003", Age = 35, PatientId = "P003", MedicalHistory =new List<string>(){ "Diabetes" }},
                new Patient { Name = "Diana", NationalId = "ID004", Age = 28, PatientId = "P004", MedicalHistory = new List<string>(){"Hypertension,Migraine" }},
                new Patient { Name = "Eve", NationalId = "ID005", Age = 40, PatientId = "P005", MedicalHistory = new List<string>(){"Arthritis" }},
                new Patient { Name = "Frank", NationalId = "ID006", Age = 33, PatientId = "P006", MedicalHistory =new List<string>(){ "Migraine" }},
                new Patient { Name = "Grace", NationalId = "ID007", Age = 22, PatientId = "P007", MedicalHistory =new List<string>(){ "Anemia,Diabetes,Fracture" }},
                new Patient { Name = "Hank", NationalId = "ID008", Age = 45, PatientId = "P008", MedicalHistory =new List<string>(){ "Allergy" }},
                new Patient { Name = "Ivy", NationalId = "ID009", Age = 27, PatientId = "P009", MedicalHistory =new List<string>(){ "Fracture" }},
                new Patient { Name = "Jack", NationalId = "ID010", Age = 36, PatientId = "P010", MedicalHistory =new List<string>(){ "Ulcer" }}
            });


        }

        public List<Person> GetAll()
        {
            return Peaple;
        }



    }
    public class Person
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public byte Age { get; set; }

        public string GetDetails()
        {
            return "NationalId : " + NationalId + "Name : " + Name + "Age :  " + Age;
        }
    }

    public class Patient : Person
    {
        public string PatientId { get; set; }


     //  لیستی از بیماری های گذشته بیمار
        public List<string>MedicalHistory { get; set; }

        public void AddToMedicalHistory(string _medicalHistory)
        {
            MedicalHistory.Add(_medicalHistory);

        }
        public Room Room { get; set; }
        public override string ToString()
        {

            return $"{NationalId,-5} | {Name,-20} | {Room.RoomNumber,-15} | {PatientId,-10:C} | {string.Join(" ",MedicalHistory),-6}";
        }

        public Patient()
        {
            MedicalHistory=new List<string>();
        }
        public Patient(string patientId, string medicalHistory,string name,string nationalId)
        {
            PatientId = patientId;
            MedicalHistory = new List<string>();
            MedicalHistory.AddRange(medicalHistory.Split('-'));
            //Room = room;
            Name    =name;
            NationalId=nationalId;
        }
    }

    public class Doctor : Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DoctorId { get; set; }
        //تخصص
        public string Specialization { get; set; }

        public void Diagnose(Patient patient, string diagnosis)
        {
            patient.AddToMedicalHistory(diagnosis);
        }

        public Doctor(string lastName, string firstName, string doctorId, string specialization,byte age)
        {
            LastName = lastName;
            FirstName = firstName;
            DoctorId = doctorId;
            Specialization = specialization;
            Age = age;
        }
   

        public Doctor()
        {
            
        }
        public override string ToString()
        {

            return $"{DoctorId,-5} | {FirstName +" "+ LastName,-20} | {Age,-5} | {DoctorId,-10:C} | {Specialization,-6}";
        }
    }

    public class Room
    {

        //ظرفیت
        public int Capacity { get; set; }
        public int RoomNumber { get; set; }

        public List<Patient> Patients { get; set; }

        public void AssignPatient(Patient patient, out bool AddStatePatient)
        {
            try
            {

                if (Capacity <= 0)
                {
                    throw new RoomFullException($"The room {RoomNumber} does not have enough capacity.");
                }
                else
                {
                    Capacity--;

                    Patients.Add(patient);
                    AddStatePatient = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AddStatePatient = false;
            }

         
        }


        public void DeletePatient(Patient patient)
        {
            if (patient!=null)
            {
                Patients.Remove(patient);
                Capacity++;
            }

        }

        public override string ToString()
        {

            return $"{Capacity,-5} | {RoomNumber,-20} ";
        }
    }

    public class Hospital
    {
        private static readonly Lazy<Hospital> _instance =
            new Lazy<Hospital>(() => new Hospital());


        public static Hospital Instance => _instance.Value;


        private Hospital()
        {
            InitDataDoctor();
            InitDataRoom();

        }

        private void InitDataRoom()
        {
            Rooms = new List<Room>()
            {
               
                new Room { RoomNumber = 102, Capacity = 1  ,Patients = new List<Patient>()
                {   new Patient { NationalId = "002", Name = "Jane Smith", Age = 25, PatientId = "P002", MedicalHistory = new List<string>(){"Asthma" }},
                    new Patient { NationalId = "003", Name = "Sam Wilson", Age = 40, PatientId = "P003", MedicalHistory = new List<string>(){"Hypertension" }},
                    new Patient { NationalId = "004", Name = "Lucy Brown", Age = 35, PatientId = "P004", MedicalHistory = new List<string>(){"Arthritis" }},

                }
    },
                new Room { RoomNumber = 103, Capacity = 1 ,Patients = new List<Patient>()
                {   
                    new Patient { NationalId = "005", Name = "Mark Lee", Age = 50, PatientId = "P005", MedicalHistory =new List<string>(){ "Obesity" }},
                    new Patient { NationalId = "006", Name = "Emma Davis", Age = 29, PatientId = "P006", MedicalHistory = new List<string>() { "Anemia" }},
                    new Patient { NationalId = "007", Name = "Liam Johnson", Age = 60, PatientId = "P007", MedicalHistory = new List<string>() { "Heart","Disease" }},

                }},
                new Room { RoomNumber = 104, Capacity = 4,Patients = new List<Patient>()
                {        
                    new Patient { NationalId = "008", Name = "Sophia Martinez", Age = 45, PatientId = "P008", MedicalHistory = new List<string>(){"Cancer" }},
                    new Patient { NationalId = "009", Name = "Mason Garcia", Age = 38, PatientId = "P009", MedicalHistory =new List<string>(){ "Migraine" }},
                    new Patient { NationalId = "010", Name = "Olivia Rodriguez", Age = 22, PatientId = "P010", MedicalHistory = new List<string>(){"None" }},

                } },
                new Room { RoomNumber = 105, Capacity = 2,Patients = new List<Patient>()
                {      
                    new Patient { NationalId = "011", Name = "Ethan Baker", Age = 31, PatientId = "P011", MedicalHistory = new List<string>(){"Asthma" }},
                    new Patient { NationalId = "012", Name = "Ava Brooks", Age = 28, PatientId = "P012", MedicalHistory = new List<string>(){"None" }
                },
                    new Patient { NationalId = "013", Name = "William Moore", Age = 33, PatientId = "P013", MedicalHistory =new List<string>(){ "High","Cholesterol" }},

                } },
                new Room { RoomNumber = 106, Capacity = 3 ,Patients = new List<Patient>()
                {         
                    new Patient { NationalId = "028", Name = "Sophia Foster", Age = 26, PatientId = "P028", MedicalHistory =new List<string>(){ "None" }},
                    new Patient { NationalId = "029", Name = "Jack Reed", Age = 41, PatientId = "P029", MedicalHistory =new List<string>(){ "Asthma" }
                },
                    new Patient { NationalId = "030", Name = "Lily Ward", Age = 48, PatientId = "P030", MedicalHistory = new List<string>(){"Heart","Disease" }}

                }},
                new Room { RoomNumber = 107, Capacity = 1 ,Patients = new List<Patient>()

                {            new Patient { NationalId = "025", Name = "Lucas Murphy", Age = 44, PatientId = "P025", MedicalHistory = new List<string>(){"Diabetes" }},
                    new Patient { NationalId = "026", Name = "Ella Sanders", Age = 32, PatientId = "P026", MedicalHistory = new List<string>(){"Obesity" }
                },
                    new Patient { NationalId = "027", Name = "Henry Clark", Age = 53, PatientId = "P027", MedicalHistory = new List<string>(){"Cancer" }},

                }},
                new Room { RoomNumber = 108, Capacity = 5,Patients = new List<Patient>()
                {          
                    new Patient { NationalId = "023", Name = "Daniel Scott", Age = 37, PatientId = "P023", MedicalHistory =new List<string>(){ "Hypertension" }},
                    new Patient { NationalId = "024", Name = "Grace Morgan", Age = 29, PatientId = "P024", MedicalHistory = new List<string>(){"Migraine" }
                },

                } },
                new Room { RoomNumber = 109, Capacity = 2 ,Patients = new List<Patient>()
                {            new Patient { NationalId = "021", Name = "Benjamin Evans", Age = 24, PatientId = "P021", MedicalHistory = new List<string>(){"None" }},
                    new Patient { NationalId = "022", Name = "Amelia Turner", Age = 42, PatientId = "P022", MedicalHistory =new List<string>(){ "Asthma" }
                },

                }},
                new Room { RoomNumber = 110, Capacity = 3 ,Patients = new List<Patient>()
                {
                    new Patient { NationalId = "014", Name = "Isabella Cooper", Age = 27, PatientId = "P014", MedicalHistory = new List<string>(){"Anemia" }},
                    new Patient { NationalId = "015", Name = "James Kelly", Age = 36, PatientId = "P015", MedicalHistory =new List<string>(){ "Diabetes" }
                },
                    new Patient { NationalId = "016", Name = "Charlotte Bennett", Age = 43, PatientId = "P016", MedicalHistory = new List<string>(){"Hypertension" }},
                    new Patient { NationalId = "017", Name = "Michael Carter", Age = 47, PatientId = "P017", MedicalHistory = new List<string>(){"Heart","Disease" }},
                    new Patient { NationalId = "018", Name = "Mia Flores", Age = 34, PatientId = "P018", MedicalHistory = new List<string>(){"Thyroid" }},
                    new Patient { NationalId = "019", Name = "Alexander Lopez", Age = 39, PatientId = "P019", MedicalHistory = new List<string>(){"Kidney","Stones" }},
                    new Patient { NationalId = "020", Name = "Emily Harris", Age = 50, PatientId = "P020", MedicalHistory = new List<string>(){"Arthritis" }},

                }}
            };
        }
        private void InitDataDoctor()
        {
            Doctors = new List<Doctor>()
            {
                new Doctor { DoctorId = "D001", FirstName = "John", LastName = "Doe", Age = 45, Specialization = "Neurology" },
                new Doctor { DoctorId = "D002", FirstName = "Emily", LastName = "Smith", Age = 38, Specialization = "Cardiology" },
                new Doctor { DoctorId = "D003", FirstName = "Michael", LastName = "Brown", Age = 50, Specialization = "Orthopedics" },
                new Doctor { DoctorId = "D004", FirstName = "Sarah", LastName = "Davis", Age = 42, Specialization = "Dermatology" },
                new Doctor { DoctorId = "D005", FirstName = "David", LastName = "Wilson", Age = 35, Specialization = "Pediatrics" },
                new Doctor { DoctorId = "D006", FirstName = "Sophia", LastName = "Martinez", Age = 40, Specialization = "Ophthalmology" },
                new Doctor { DoctorId = "D007", FirstName = "James", LastName = "Anderson", Age = 55, Specialization = "Oncology" },
                new Doctor { DoctorId = "D008", FirstName = "Olivia", LastName = "Taylor", Age = 30, Specialization = "Gynecology" },
                new Doctor { DoctorId = "D009", FirstName = "William", LastName = "Thomas", Age = 48, Specialization = "Psychiatry" },
                new Doctor { DoctorId = "D010", FirstName = "Isabella", LastName = "Moore", Age = 37, Specialization = "Surgeon" }
            };
        }


        public Room GetRoom(string RoomId)
        {
            return Rooms.FirstOrDefault(a => a.RoomNumber.Equals(RoomId))??new Room();
        }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }

        public void AdmitPatient(Patient patient)
        {
            foreach (var room in Rooms ?? new List<Room>())
            {
                bool statusExitLoop = false;
                room.AssignPatient(patient, out statusExitLoop);
                if (statusExitLoop)
                    break;

            }
        }


        public void DischargePatient(Patient patient)
        {
            foreach (var room in Rooms)
            {
                try
                {
                    if (room.RoomNumber.Equals(patient.Room.RoomNumber))
                    {
                        // patient.Room.
                        room.DeletePatient(patient);

                        //     ConsoleDesign.MenuForHospital();
                        Console.WriteLine($"Patient {patient.Name} discharged from Room {room.RoomNumber}.");
                        return;
                    } 
                  
                    
                }
                catch { }
            }
            Console.WriteLine("Patient not found in any room.");
        }
    }
}
