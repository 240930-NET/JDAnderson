class Beagle : Dog 
{
    public override void Bark()
    {
        Console.WriteLine("Arf arf!"); 
    }

    public override void PrintInfo()
{
    base.PrintInfo();
    Console.WriteLine($"My name is {Name} and I'm a playful Beagle!");
}
}