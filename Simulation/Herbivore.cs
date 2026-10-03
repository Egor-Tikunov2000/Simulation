using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation
{
    class Herbivore : Creature//травоядное
    {
        protected Herbivore(int speed, int hp, int x, int y) : base(speed, hp, x, y) {
        
        }
        public override void MakeMove(Map map, int targetX, int targetY)
        {
            if (Hp <= 0) return; // Dead creatures don't move

            // In a real game, this would involve pathfinding.
            // For this example, we'll simplify it: find the nearest grass.
            var nearestGrass = map.FindNearestGrass(this.X, this.Y);

            if (nearestGrass != null)
            {
                if (DistanceTo(nearestGrass) <= Speed) 
                {

                    Console.WriteLine($"{this} is moving to ({nearestGrass.X},{nearestGrass.Y}) and eating grass.");

                    Hp += 5;
                    map.RemoveGrass(nearestGrass); 
                }
                else
                {
                    // Move toward it
                    MoveToward(nearestGrass.X, nearestGrass.Y, map);
                }
            }
            else
            {
                Console.WriteLine($"{this} is wandering, looking for food.");
            }
        }

        private void MoveToward(int targetX, int targetY, Map map)///просчёт дистанции по алгоритму a*
        {
            int deltaX = 0;
            int deltaY = 0;

            if (targetX > X) deltaX = Math.Min(Speed, targetX - X);
            else if (targetX < X) deltaX = -Math.Min(Speed, X - targetX);

            if (targetY > Y) deltaY = Math.Min(Speed, targetY - Y);
            else if (targetY < Y) deltaY = -Math.Min(Speed, Y - targetY);

            // Clamp movement to Speed
            int totalMove = Math.Abs(deltaX) + Math.Abs(deltaY);
            if (totalMove > Speed)
            {
                // This is a basic form of "Manhattan distance" movement.
                // More complex pathfinding would be needed for true grid movement.
                if (deltaX != 0) deltaX = (deltaX / Math.Abs(deltaX)) * Math.Min(Speed, Math.Abs(deltaX));
                if (deltaY != 0) deltaY = (deltaY / Math.Abs(deltaY)) * Math.Min(Speed, Math.Abs(deltaY));
            }

            // Update position (assuming map allows movement)
            X += deltaX;
            Y += deltaY;

            Console.WriteLine($"{this} moved to ({X},{Y}).");
        }
        public override void TakeDamage(Map map, int amountDamage)//совершить движение
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
                    herbivore.TakeDamage(this.AttackPoint);
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

        public void FindNearestGrass() {

            return;
        }

        public void EatGrass() {

            return;
        }
    }
}

//Травоядное, наследуется от Creature. 
//Стремятся найти ресурс (траву), может потратить свой ход на движение в сторону травы, либо на её поглощение.