using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation
{
    class Predator : Creature//хищник
    { 
        public Predator(int speed, int hp, int attackPower, int x, int y) : base(speed, hp, x, y) {

            AttackPower = attackPower;
        }
        public int AttackPower { get; private set; }
        public override void TakeDamage(Map map, int attackPower)//нанести урон
        {
            if (Hp <= 0) return; // Dead predators don't hunt

            // 1. Find the nearest herbivore
            Herbivore herbivore = map.FindNearestHerbivore(this.X, this.Y);

            if (herbivore != null)
            {
                // 2. Check if we can attack (on the same tile)
                if (InOneCellField(herbivore))
                {
                    Console.WriteLine($"{this} is attacking {herbivore}!");
                    herbivore.TakeDamage(this.AttackPower);
                }
                else
                {
                    // 3. If not on the same tile, move closer to the prey
                    MoveToward(herbivore.X, herbivore.Y, map);
                }
            }
            else
            {
                Console.WriteLine($"{this} is patrolling, no prey found.");
            }
        }

        // Helper for the predator to move toward a target X, Y
        private void MakeMove(Map map, int targetX, int targetY) {//Двигаться навстречу

            int deltaX = 0;
            int deltaY = 0;

            // Calculate movement direction and amount

            // Update position
            X += deltaX;
            Y += deltaY;

            Console.WriteLine($"{this} moved to ({X},{Y}) towards.");
        }
    }
}

//Хищник, наследуется от Creature. В дополнение к полям класса Creature, имеет силу атаки. На что может потратить ход хищник:

//Переместиться(чтобы приблизиться к жертве - травоядному)
//Атаковать травоядное. При этом количество HP травоядного уменьшается на силу атаки хищника.
//Если значение HP жертвы опускается до 0, травоядное исчезает