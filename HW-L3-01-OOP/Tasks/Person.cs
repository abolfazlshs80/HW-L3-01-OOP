public class Person
{
    public Person(string name, byte age)
    {
        Name = name;
        Age = age;
    }

    public Person()
    {
        
    }
    public string Name { get; set; }
    public byte Age { get; set; }

    public virtual string GetDetails()
    {
        return $"Name : {Name} And Age : {Age}";
    }
}

public class Professor : Person
{
    public int ProfessorId { get; set; }
    public string Subject { get; set; }
    public override string GetDetails()
    {
        return $"ID-{ProfessorId} Name : {Name} And Age : {Age} And  Subject : {Subject} ";
    }

    public Professor()
    {
        
    }

    public Professor(int professorId, string subject ,string name, byte age) : base(name, age)
    {
        ProfessorId = professorId;
        Subject = subject;
    }
}

public class Student : Person
{
    public Student()
    {
        
    }

    public Student(int studentId, string major, string name, byte age) :base(name,age)
    {
        StudentID = studentId;
        Major = major;
    }
    public int StudentID { get; set; }
    public string Major { get; set; }
    public override string GetDetails()
    {
        return $"ID-{StudentID} Name : {Name} And Age : {Age} And  Major : {Major} ";
    }
}