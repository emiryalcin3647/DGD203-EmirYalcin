using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Car myCar = new Car();

        
        myCar.Engine.Start();

        
        myCar.FuelTank.Consume(10);

        
        Console.WriteLine($"Brand/Model: {myCar.Brand} {myCar.Model} ({myCar.Year})");
        Console.WriteLine($"Body Type: {myCar.BodyType}, Seats: {myCar.SeatCount}");
        Console.WriteLine($"Engine: {myCar.Engine.HorsePower} HP, {myCar.Engine.Size} litre, Fuel Type: {myCar.Engine.FuelType}");
        Console.WriteLine($"Remaining fuel: {myCar.FuelTank.CurrentLevel} litre");
        Console.WriteLine($"Tyre size: Front: {myCar.Wheels[0].Size}, Rear: {myCar.Wheels[2].Size}");
    }
}

class Car
{
    public string Brand { get; private set; } = "BMW";
    public string Model { get; private set; } = "E92 M3";
    public int Year { get; private set; } = 2011;
    public string BodyType { get; private set; } = "Coupe"; 
    public int SeatCount { get; private set; } = 4; 
    public Engine Engine { get; private set; } = new Engine(420, 4.0f, "Atmospheric");
    
    
    public List<Wheel> Wheels { get; private set; } = new List<Wheel>
    {
        new Wheel("Front Left", "245/40/19"), 
        new Wheel("Front Right", "245/40/19"),
        new Wheel("Rear Left", "265/35/19"), 
        new Wheel("Rear Right", "265/35/19")
    };
    
    public FuelTank FuelTank { get; private set; } = new FuelTank(64);

    public Car() { }
}

class Engine
{
    public int HorsePower { get; private set; }
    public float Size { get; private set; }
    public string FuelType { get; private set; }
    public bool IsRunning { get; private set; }

    public Engine(int horsePower, float size, string fuelType)
    {
        HorsePower = horsePower;
        Size = size;
        FuelType = fuelType;
    }

    public void Start()
    {
        IsRunning = true;
        Console.WriteLine($"Engine is running. ({HorsePower} HP, {Size} liter, Fuel Type: {FuelType})");
    }

    public void Stop()
    {
        IsRunning = false;
        Console.WriteLine("Engine shut down.");
    }
}

class Wheel
{
    public string Position { get; private set; } 
    public string Size { get; private set; }     

    public Wheel(string position, string size)
    {
        Position = position;
        Size = size;
    }
}

class FuelTank
{
    public float Capacity { get; private set; }
    public float CurrentLevel { get; private set; }

    public FuelTank(float capacity)
    {
        Capacity = capacity;
        CurrentLevel = capacity; 
    }

    public void Consume(float amount)
    {
        if (CurrentLevel >= amount)
        {
            CurrentLevel -= amount;
            Console.WriteLine($"{amount} Liters of fuel consumed.");
        }
        else
        {
            Console.WriteLine("Not enough fuel!");
        }
    }
}
