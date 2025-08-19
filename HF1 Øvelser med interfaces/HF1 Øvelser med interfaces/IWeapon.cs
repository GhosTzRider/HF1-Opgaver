using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_interfaces
{
    internal interface IWeapon
    {
        public int Attack();
    }

    public class Sword : IWeapon
    {
        public int Attack()
        {
            int SwordDamage = 10;
            Console.WriteLine($"Swinging the sword!");
            return SwordDamage;
        }
    }

    public class Bow : IWeapon
    {
        public int Attack()
        {
            Random random = new Random();
            Console.WriteLine("Shooting an arrow with the bow!");

            int attackDamage = random.Next(5, 15);
            return attackDamage;

        }
    }



    public class Staff : IWeapon
    {
        public int Attack()
        {
            int MagicPower = 20;
            Console.WriteLine($"Casting a spell with the staff!");
            return MagicPower;

        }
    }
}
