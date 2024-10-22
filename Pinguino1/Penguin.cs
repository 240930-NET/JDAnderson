class Penguin {
    private string name = "Koawa";
   private int age = 24;
   public Penguin(string N, int A){
    name = N; 
    age = A; 
   }
   public void printPenguin() {
    Console.WriteLine($"Name: {name}\n Age: {age}");
   }
}