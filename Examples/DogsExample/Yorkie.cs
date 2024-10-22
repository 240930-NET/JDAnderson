class Yorkie : Dog 
{
    public override void Bark()
    {
        Console.WriteLine("Yip yip!"); 
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"my name is {Name} I'm a tiny Yorkie!");
    }
}