using System;

namespace HF1_OOP_øvelser_med_nedarvning
{
    
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        
        public abstract int Attack();
    }

    
    public class Warrior : Character
    {
        public int Strength { get; set; }
        
        public Warrior(string name, int health, int strength)   
            : base(name, health)
        {
            Strength = strength;
        }

        public override int Attack()
        {
            return Strength * 2;
        }
    }

   
    public class Mage : Character
    {
        public int Mana { get; set; }

        public Mage(string name, int health, int mana)
            : base(name, health)
        {
            Mana = mana;
        }

        public override int Attack()
        {
            return Mana / 2;
        }
    }
}
