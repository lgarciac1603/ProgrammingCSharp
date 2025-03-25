namespace ProgrammingCSharp.Inheritance_Polymorphism
{
    internal class Practice_1_M3
    {

    }

    // Inheritancce
    public class Pool
    {
        public int chlorineLevel;
        public int waterLevel;

        public Pool(int chlorine, int water)
        {
            chlorineLevel = chlorine;
            waterLevel = water;
        }

        public void PoolInfo()
        {
            Console.WriteLine($"Pool: {this.chlorineLevel}, {this.waterLevel}");
        }
    }

    public class Spa : Pool
    {
        public int heatLevel;

        public Spa(int chlorine, int water, int heat) : base(chlorine, water)
        {
            heatLevel = heat;
        }

        public void SpaInfo()
        {
            Console.WriteLine($"Spa: {chlorineLevel}, {waterLevel}, {heatLevel}");
        }
    }

    // Polymorphism
    public class Instrument {
        public virtual void Play() {
            Console.WriteLine("Play with the instrument");
        }
    }

    public class Piano : Instrument {
        public override void Play()
        {
            Console.WriteLine("The piano is playing");
        }
    }

    public interface IPlayable {
        void Play();
    }

    public class Guitar : IPlayable {
        public void Play() {
            Console.WriteLine("Guitar is playing");
        }
    }
}
