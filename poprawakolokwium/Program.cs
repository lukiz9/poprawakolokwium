using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            KlasaTest klasa = new KlasaTest(4);
            Console.WriteLine(klasa.Druga());
            Console.WriteLine(klasa.TestMetoda(10));
            LinkedList<double> lista = new LinkedList<double>();
            lista.AddFirst(3);
            lista.AddAfter(lista.Find(3), 4);
            lista.AddAfter(lista.Find(4), 5);
            lista.AddAfter(lista.Find(3), 3.5);
            lista.AddAfter(lista.Find(4), 4.5);
            foreach (var d in lista)
            {
                Console.WriteLine(d);
            }
            List<Bohater> postacie = new List<Bohater>();
            postacie.Add(new Bohater(10));
            postacie.Add(new Bohater(8));
            postacie.Add(new Elf(15, "fireball"));
            postacie.Add(new Elf(20, "frostlance"));
            postacie.Add(new Ork(40, 60));
            postacie.Add(new Ork(20, 50));
            postacie.Sort();
            postacie.Reverse();
            foreach (var item in postacie)
            {
                Console.WriteLine(item.ToString());
            }
            Sport sport = Sport.Utworz("Kosz");
            try
            {
                int hp = Convert.ToInt32(Console.ReadLine());
                Bohater uzytkownik = new Bohater(hp);
            }
            catch
            {
                Console.WriteLine("Hp musi byc typu int");
            }

            Dictionary<string, List<int>> aa = new Dictionary<string, List<int>>();

            Console.ReadKey();
        }

        public interface IAaa
        {
            string TestMetoda(int Parametr);
        }

        public interface IBbb : IAaa
        {
            int Druga();
        }

        public class KlasaTest : IBbb
        {
            private int numer;

            internal KlasaTest(int numer)
            {
                this.numer = numer;
            }

            public string TestMetoda(int Parametr)
            {
                return Parametr.ToString();
            }

            public int Druga()
            {
                return numer;
            }
        }

        public class Bohater : IComparable
        {
            private int hp;

            public Bohater(int hp)
            {
                this.hp = hp;
            }

            public override string ToString()
            {
                return hp.ToString();
            }
            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Bohater otherBohater = obj as Bohater;
                if (otherBohater != null)
                    return this.hp.CompareTo(otherBohater.hp);
                else
                    throw new ArgumentException("Object is not a Temperature");
            }

            public virtual bool ZadajCios(int obrazenia)
            {
                if (obrazenia < 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class Elf : Bohater
        {
            private string magia;

            public Elf(int hp, string magia)
                : base(hp)
            {
                this.magia = magia;
            }

            public override bool ZadajCios(int obrazenia)
            {
                if (obrazenia > 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class Ork : Bohater
        {
            private int walka;

            public Ork(int hp, int walka)
                : base(hp)
            {
                this.walka = walka;
            }

            public override bool ZadajCios(int obrazenia)
            {
                if (obrazenia > 15)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class Sport
        {
            private string nazwa;

            private Sport(string nazwa)
            {
                this.nazwa = nazwa;
            }

            public static Sport Utworz(string nazwa)
            {
                return new Sport(nazwa);
            }
        }
    }
}
