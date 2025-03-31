namespace ProgrammingCSharp.Inheritance_Polymorphism
{
    interface IAnimal {
        void Eat();
    }

    internal class Assignment_1_Animals
    {
        class Animal : IAnimal {
            public void Eat() {
                Console.WriteLine("I S    E A T I N G !!");
            }

            public virtual void MakeSound() {
                Console.WriteLine("FUCKING NOISE");
            }
        }
        class Dog : Animal, IAnimal {
            public override void MakeSound() {
                Console.WriteLine("FUCKING DOG NOISE");
            }

            public void Eat() {
                Console.WriteLine("D O G    I S    E A T I N G !!");
            }
        }
        class Cat : Animal, IAnimal {
            public override void MakeSound() {
                Console.WriteLine("FUCKING CAT NOISE");
            }

            public void Eat()
            {
                Console.WriteLine("C A T    I S    E A T I N G !!");
            }
        }
    }
}
