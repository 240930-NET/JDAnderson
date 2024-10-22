class Pit : Dog 
{
    public override void Bark()
    {
        Console.WriteLine("Boof boof!"); 
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("my name is {Name} I'm a cute Pit!");
    }
}