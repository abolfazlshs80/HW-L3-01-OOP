// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using HW_L3_01_OOP.Tasks.Exception;
using HW_L3_01_OOP.Tasks.Factory_Method;
using HW_L3_01_OOP.Tasks.Factory_Method.Class;
using HW_L3_01_OOP.Tasks.Factory_Method.Class.Patient;
using HW_L3_01_OOP.Tasks.Service;
using HW_L3_01_OOP.Tasks.Strategy_Pattern;
using HW_L3_01_OOP.Tools;
using HW_L3_01_OOP.Tools.ConsoleDesign;
using Microsoft.Extensions.DependencyInjection;
using Question4;







#region Question 1



//Library library = new Library();
//MessageMenu();

//string input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);

//while (input != "5")
//{
//    switch (input)
//    {
//        case "1":
//            GetBooks();
//            ClearApp(ref input);
//            break;

//        case "2":
//            ChangeBook();
//            ClearApp(ref input, false);
//            break;
//        case "3":
//            FindBook();
//            ClearApp(ref input, false);
//            break;
//        case "4":
//            AddBook();
//            ClearApp(ref input, false);
//            break;
//        default:
//            ClearApp(ref input);
//            break;
//    }

//}

//void GetBooks()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForTable("List Of Book");
//    Console.ResetColor();
//    ConsoleDesign.ContentForTable();
//    Console.ResetColor();
//    foreach (var item in library.GetBooks())
//    {
//        Console.WriteLine(item);

//    }
//    Console.WriteLine();
//    Console.WriteLine();
//    Console.ReadKey();
//}

//void ClearApp(ref string input, bool dontMessage = false)
//{
//    MessageMenu();
//    input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);
//}
//void MessageMenu()
//{
//    Console.Clear();
//    ConsoleDesign.Menu();


//}



//void ChangeBook()
//{
//    var newbook = GetBook();
//    library.BorrowBook(newbook.Title);
//    ConsoleDesign.MenuForTable("Change IsAvailable the  Book", ConsoleColor.Green);
//    Console.ReadKey();

//}

//Library.Book GetBook(bool statusRepeat = true, string input = "")
//{
//    string title = input == "" ? (string)ConsoleDesign.InputValidation(" please enter  your book title", false) : input;
//    bool StatusBooks = false;
//    if (!string.IsNullOrEmpty(title))
//    {
//        var book = library.ReturnBook(title, ref StatusBooks);
//        if (statusRepeat)
//        {
//            while (book == null)
//            {
//                ConsoleDesign.MenuForTable("Not Found", ConsoleColor.DarkRed);
//                title = (string)ConsoleDesign.InputValidation(" please enter  your book title", false);
//                StatusBooks = false;
//                book = library.ReturnBook(title, ref StatusBooks);
//            }
//        }
//        if (StatusBooks)
//            return book;
//    }

//    return null;
//}


//void FindBook()
//{
//    Library.Book item = GetBook();
//    Console.Clear();
//    ConsoleDesign.MenuForTable("List Of Book");
//    Console.ResetColor();
//    ConsoleDesign.ContentForTable();
//    Console.ResetColor();

//    Console.WriteLine(item);


//    Console.WriteLine();
//    Console.WriteLine();
//    Console.ReadKey();
//    //  Console.WriteLine($"Author = {item.Author},ISBN = {item.ISBN},IsAvailable = {item.IsAvailable},Title ={item.Title} ");
//}
//void AddBook()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForTable("Create New Book");
//    bool status = true;
//    string title = (string)ConsoleDesign.InputValidation("Please Enter your book title : ",false);
//    string ISBN = (string)ConsoleDesign.InputValidation("Please enter  your book ISBN : ", false);
//    string Author = (string)ConsoleDesign.InputValidation("please enter  your book Author : ", false);
//    while (status)
//    {
//        if (string.IsNullOrEmpty(title))
//        {
//             title = (string)ConsoleDesign.InputValidation("Please Enter your book title : ", false);
//        }
//        else if (string.IsNullOrEmpty(ISBN))
//        {
//             ISBN = (string)ConsoleDesign.InputValidation("Please enter  your book ISBN : ", false);
//        }
//        else if (string.IsNullOrEmpty(Author))
//        {
//             Author = (string)ConsoleDesign.InputValidation("please enter  your book Author : ", false);
//        }
//        else
//        {
//            Library.Book item = GetBook(false, input: title);
//            if (item != null)
//            {
//                title = (string)ConsoleDesign.InputValidation("Please Enter your book title : ", false);
//            }
//            else
//            {
//                status = false;
//            }
//        }

//    }

//    library.AddBook(new Library.Book() { IsAvailable = true, Title = title, ISBN = ISBN, Author = Author });
//    ConsoleDesign.MenuForTable("Created new Book", ConsoleColor.Green);
//    Console.ReadKey();
//    MessageMenu();
//}
#endregion

#region Question 2

using HW_L3_01_OOP.Tools;
using HW_L3_01_OOP.Tools.ConsoleDesign;
using System.Text;
using static Library;

List<Person> person = new List<Person>();
var lstProfessor = new List<Person>
{
    new Professor { Name = "Professor1", Age = 50, ProfessorId = 11, Subject = "Physics" },
    new Professor { Name = "Professor2", Age = 51, ProfessorId = 12, Subject = "Mathematics" },
    new Professor { Name = "Professor3", Age = 52, ProfessorId = 13, Subject = "Chemistry" },
    new Professor { Name = "Professor4", Age = 53, ProfessorId = 14, Subject = "Biology" },
    new Professor { Name = "Professor5", Age = 54, ProfessorId = 15, Subject = "Engineering" },
    new Professor { Name = "Professor6", Age = 55, ProfessorId = 16, Subject = "Computer Science" },
    new Professor { Name = "Professor7", Age = 56, ProfessorId = 17, Subject = "Economics" },
    new Professor { Name = "Professor8", Age = 57, ProfessorId = 18, Subject = "History" },
    new Professor { Name = "Professor9", Age = 58, ProfessorId = 19, Subject = "Philosophy" },
    new Professor { Name = "Professor10", Age = 59, ProfessorId = 20, Subject = "Arts" }
};

var lstStudent = new List<Person>
{
    new Student { Name = "Student1", Age = 18, StudentID = 1, Major = "Physics" },
    new Student { Name = "Student2", Age = 19, StudentID = 2, Major = "Mathematics" },
    new Student { Name = "Student3", Age = 20, StudentID = 3, Major = "Chemistry" },
    new Student { Name = "Student4", Age = 21, StudentID = 4, Major = "Biology" },
    new Student { Name = "Student5", Age = 22, StudentID = 5, Major = "Engineering" },
    new Student { Name = "Student6", Age = 23, StudentID = 6, Major = "Computer Science" },
    new Student { Name = "Student7", Age = 24, StudentID = 7, Major = "Economics" },
    new Student { Name = "Student8", Age = 25, StudentID = 8, Major = "History" },
    new Student { Name = "Student9", Age = 26, StudentID = 9, Major = "Philosophy" },
    new Student { Name = "Student10", Age = 27, StudentID = 10, Major = "Arts" }
};
person.AddRange(lstProfessor);

person.AddRange(lstStudent);

foreach (var item in person)
{
    Console.WriteLine(item.GetDetails());

}
#endregion

#region Question 3



//List<Product> product = new List<Product>();

//product.Add(new Clothing() { ID = "1", Name = "Clothing 1", Price = 2000, Material = "Material 1", Size = "L" });
//product.Add(new Clothing() { ID = RandomString.GenerateRandomString(10), Name = "Clothing 2", Price = 3000, Material = "Material 2", Size = "M" });
//product.Add(new Clothing() { ID = RandomString.GenerateRandomString(10), Name = "Clothing 3", Price = 4000, Material = "Material 3", Size = "S" });
//product.Add(new Clothing() { ID = RandomString.GenerateRandomString(10), Name = "Clothing 4", Price = 5000, Material = "Material 4", Size = "XXL" });
//product.Add(new Electronic() { ID = RandomString.GenerateRandomString(10), Name = "Electronic 1", Price = 2500, WarrantyPeriod = "2024" });
//product.Add(new Electronic() { ID = RandomString.GenerateRandomString(10), Name = "Electronic 2", Price = 2800, WarrantyPeriod = "2025" });
//product.Add(new Electronic() { ID = "2", Name = "Electronic 3", Price = 2900, WarrantyPeriod = "2026" });
//MessageMenuForProduct();

//string input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);

//while (input != "5")
//{
//    switch (input)
//    {
//        case "1":
//            GetProducts();
//            ClearApp(ref input);
//            break;

//        case "2":

//            InsertProductElectronic();
//            ClearApp(ref input, false);
//            break;
//        case "3":
//            InsertProductClothing();
//            ClearApp(ref input, false);
//            break;
//        case "4":
//            ApplyDiscount();
//            ClearApp(ref input, false);
//            break;
//        default:
//            ClearApp(ref input);
//            break;
//    }

//}

//void ClearApp(ref string input, bool dontMessage = false)
//{
//    MessageMenuForProduct();
//    input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);
//}


//void MessageMenuForProduct()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForProduct();
//}

//void GetProducts()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForTable("List Of Product");
//    Console.ResetColor();
//    ConsoleDesign.ContentForTableInProduct();
//    Console.ResetColor();
//    foreach (var item in product)
//    {
//        Console.WriteLine(item);

//    }
//    Console.WriteLine();
//    Console.WriteLine();
//    Console.ReadKey();
//}

//void InsertProductElectronic()
//{


//    Console.Clear();
//    ConsoleDesign.MenuForTable("Create New Product Electronic");
//    bool status = true;
//    string Id = RandomString.GenerateRandomString(10);
//    string Name = (string)ConsoleDesign.InputValidation("Please Enter your Product Name : ", false);
//    decimal Price = (int)ConsoleDesign.InputValidation("Please Enter your Product Price : ", true);
//    string WarrantyPeriod = (string)ConsoleDesign.InputValidation("Please Enter your Product WarrantyPeriod : ", false);

//    while (status)
//    {
//        if (string.IsNullOrEmpty(Name))
//        {
//            Name = (string)ConsoleDesign.InputValidation("Please Enter your Product Name : ", false);
//        }


//        else if (string.IsNullOrEmpty(WarrantyPeriod))
//        {
//          WarrantyPeriod=  (string)ConsoleDesign.InputValidation("Please Enter your Product WarrantyPeriod : ", false);
//        }
//        else
//        {
//            Product item = GetProduct(false, input: Id);
//            if (item != null)
//            {
//                Id = RandomString.GenerateRandomString(10);
//            }
//            else
//            {
//                status = false;
//            }
//        }

//    }

//    product.Add(new Electronic() { ID = Id, Name = Name, Price = Price, WarrantyPeriod = WarrantyPeriod });
//    ConsoleDesign.MenuForTable("Created new Product Electronic", ConsoleColor.Green);
//    Console.ReadKey();
//    MessageMenuForProduct();
//}
//void InsertProductClothing()
//{


//    Console.Clear();
//    ConsoleDesign.MenuForTable("Create New Product Clothing");
//    bool status = true;
//    string Id = RandomString.GenerateRandomString(10);
//    string Name = (string)ConsoleDesign.InputValidation("Please Enter your Product Name : ", false);
//    decimal Price = (int)ConsoleDesign.InputValidation("Please Enter your Product Price : ", true);
//    string Size = (string)ConsoleDesign.InputValidation("Please Enter your Product Size : ", false);
//    string Material = (string)ConsoleDesign.InputValidation("Please Enter your Product Material : ", false);

//    while (status)
//    {
//        if (string.IsNullOrEmpty(Name))
//        {
//            Name = (string)ConsoleDesign.InputValidation("Please Enter your Product Name : ", false);
//        }


//        else if (string.IsNullOrEmpty(Size))
//        {
//            Size = (string)ConsoleDesign.InputValidation("Please Enter your Product Size : ", false);
//        }

//        else if (string.IsNullOrEmpty(Material))
//        {
//            Material = (string)ConsoleDesign.InputValidation("Please Enter your Product Material : ", false);
//        }
//        else
//        {
//            Product item = GetProduct(false, input: Id);
//            if (item != null)
//            {
//                Id = RandomString.GenerateRandomString(10);
//            }
//            else
//            {
//                status = false;
//            }
//        }

//    }

//    product.Add(new Clothing() { ID = Id, Name = Name, Price = Price, Size = Size, Material = Material });
//    ConsoleDesign.MenuForTable("Created new Product Clothing", ConsoleColor.Green);
//    Console.ReadKey();
//    MessageMenuForProduct();
//}



//Product GetProduct(bool statusRepeat = true, string input = "")
//{

//    string Id = input == "" ? RandomString.GenerateRandomString(10) : input;
//    bool StatusBooks = false;
//    if (!string.IsNullOrEmpty(Id))
//    {
//        var book = ReturnProduct(Id, ref StatusBooks);
//        if (statusRepeat)
//        {
//            while (book == null)
//            {
//                ConsoleDesign.MenuForTable("Not Found", ConsoleColor.DarkRed);
//                Id = RandomString.GenerateRandomString(10);
//                StatusBooks = false;
//                book = ReturnProduct(Id, ref StatusBooks);
//            }
//        }
//        if (StatusBooks)
//            return book;
//    }

//    return null;
//}



//Product ReturnProduct(string ID, ref bool statusFindBook)
//{
//    foreach (var item in product)
//    {
//        if (item.ID.Equals(ID))
//        {

//            statusFindBook = true;
//            return item;
//        }
//    }

//    return null;
//}

//void ApplyDiscount()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForTable("Create New Product Electronic");
//    bool status = true;
//    string Id = (string)ConsoleDesign.InputValidation("Please Enter your Product Id : ", false);



//    Electronic item = GetProduct(false, input: Id) as Electronic;
//    if (item != null)
//    {
//        decimal Price = (int)ConsoleDesign.InputValidation("Please Enter your Product Price with OFFPrice : ", true);
//        if (Price < 0)
//        {
//            while (status)
//            {
//                Price = (int)ConsoleDesign.InputValidation("Please Enter your Product Price with OFFPrice : ", true);
//                if (Price > 0)
//                    status = false;
//            }
//        }
//        foreach (var p in product)
//        {
//            if (p.ID.Equals(Id))
//            {
//                item.ApplyDiscount(Price);

//            }
//        }

//    }
//    else
//    {
//        status = false;
//        ConsoleDesign.MenuForTable("Cant Set Off Price For Clothing", ConsoleColor.Red);
//    }


//    Console.ReadKey();
//}

#endregion


#region Question 4
//var serviceProvider = new ServiceCollection()
//    .AddTransient<DoctorService>()
//    .AddTransient<RoomSerive>()
//    .AddTransient<DoctorFactory, DoctorFactory>() 
//    .AddTransient<PatientService>() 
//    .AddTransient<PatientFactory, PatientFactory>() 
//    .BuildServiceProvider();

//var doctorService = serviceProvider.GetService<DoctorService>();
//var patientService = serviceProvider.GetService<PatientService>();
//var roomService = serviceProvider.GetService<RoomSerive>();






//Hospital hospitalManager = Hospital.Instance;
////hospitalManager.DischargePatient()
//Organ OrganManager = Organ.Instance;

//MessageMenu();

//string input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);

//while (input != "9")
//{
//    switch (input)
//    {
//        case "1":
//            //List Of Patient 
//            patientService.ListPatient();

//            ClearApp(ref input);
//            break;

//        case "2":
//            //List Of Docter    
//            doctorService.ListDoctor();

//            ClearApp(ref input);
//            break;

//        case "3":
//            //List Of Room
//            roomService.ListRoom();

//            ClearApp(ref input);
//            break;

//        case "4":
//            // Create a new Petient

//            patientService.CreatePatient();
//            ClearApp(ref input);
//            break;

//        case "5":
//            // Create a new Doctor
//            doctorService.CreateDoctor();
//            ClearApp(ref input);
//            break;

//        case "6":
//            Console.WriteLine("Dont Implement Method");
//            Console.ReadKey();
//            ClearApp(ref input);
//            break;

//        case "7":
//            doctorService.Handel();
//            ClearApp(ref input);
//            break;

//        case "8":
//            roomService.DeletePatientFromRoom();
//            ClearApp(ref input);
//            break;
//        default:
//            ClearApp(ref input);
//            break;
//    }

//}


//void ClearApp(ref string input, bool dontMessage = false)
//{
//    MessageMenu();
//    input = (string)ConsoleDesign.InputValidation("Please enter digit for menu : ", false);
//}
//void MessageMenu()
//{
//    Console.Clear();
//    ConsoleDesign.MenuForHospital();


//}






















/////اطمینان از Singleton بودن
Hospital anotherInstance = Hospital.Instance;
//Console.WriteLine(ReferenceEquals(bookManager, anotherInstance));

#endregion






