abstract class Dog : IDog 
{
    public string Name { get; set; } = "Buster";
    public int Age { get; set; } = 1;

    public abstract void Bark();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}\nAge: {Age}");
    }
}
