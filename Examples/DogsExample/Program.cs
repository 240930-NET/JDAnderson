namespace DogsExample;

class Program
{
    static void Main(string[] args)
    {
        
        // make array of Dogs 
        Dog[] DogTypes = new Dog[] { 
            new Pit { Name="Lucy", Age =10}, 
            new Yorkie { Name = "Wrigley", Age = 13},
            new Beagle {Name = "Snoopy", Age=50}
        }; 

        foreach(Dog dog in DogTypes) {
            dog.Bark(); 
            dog.PrintInfo(); 
            Console.WriteLine(); 
        }
        
    }
}
