namespace ProgrammingCSharp.Classes_Objects
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name}");
        }
    }

    internal class Practice_2_M3
    {
        public static void Main(string[] args)
        {
            Person friend = new Person();
            friend.Name = "John";
            friend.Age = 25;

            Person collage = new Person();
            collage.Name = "Jane";
            collage.Age = 22;

            friend.Greet();
            collage.Greet();
        }
    }
}
