using HW_L3_01_OOP.Tools.ConsoleDesign;
using System.Drawing;
using static Library;

public class Product
{
    public Product()
    {
        
    }

    public Product(string id, string name, decimal price)
    {
        ID = id;
        Name = name;
        Price = price;
    }
    public string ID { get; set; } 
    public string Name { get; set; }
    public decimal Price { get; set; }

    public virtual string GetProductDetails()
    {
        return $"Name : {Name} ---- Price :   {Price} ";
    }


}

public class Electronic : Product, Idiscountable
{
    public string WarrantyPeriod { get; set; }

    public override string ToString()
    {
        return $"{ID,-5} | {Name,-20} | {Price,-15} | {WarrantyPeriod,-10:C} | {"",-6}";
    }

    public void ApplyDiscount(decimal MainPrice)
    {
        if (MainPrice<Price &MainPrice>0)
        {
            Price = MainPrice;
            ConsoleDesign.MenuForTable("Set  OffPrice For Product successFully", ConsoleColor.Green);
        }
        else
        {
            ConsoleDesign.MenuForTable("Cant Set Off Price For Clothing", ConsoleColor.Red);
        }
    }
}

public class Clothing : Product
{
    public string Size { get; set; }
    public string Material { get; set; }

    public override string ToString()
    {
        return $"{ID,-5} | {Name,-20} | {Price,-15} | {Size,-10:C} | {Material,-6}";
    }
}

public interface Idiscountable
{

    void ApplyDiscount(decimal MainPrice);
}