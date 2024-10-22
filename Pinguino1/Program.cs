using System.ComponentModel;

namespace Pinguino1;

class Program
{
    static void Main(string[] args)
    {
        Penguin Emporer = new Penguin("larry", 5);
        Emporer.printPenguin(); 
        Penguin Adele = new Penguin("Pesto", 2);
        Adele.printPenguin();
    }
}
