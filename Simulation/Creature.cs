using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation
{
    abstract class Creature : Entity
    {
        protected Creature(int speed, int hp)
        {
            Speed = speed;
            Hp = hp;
           /* X = x;
            Y = y;*/
        }
        public int Speed {get; protected set;}
        public int Hp {get; protected set;}
        //public int X { get; protected set; }
        //public int Y { get; protected set; }
        //
        // Вспомогательная функция для проверки, находятся ли два существа на одной клетке
        //public bool InOneCellField(Creature creature)
        //{
        //    return this.X == creature.X && this.Y == creature.Y;
        //
        //}
        // Helper to calculate distance between two creatures
        //public int DistanceTo(Creature other)//
        //{
        //    return Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y);
        //}
        //public override string ToString()
        //{
        //    return $"{this.GetType().Name} at ({X},{Y}) - HP: {Hp}";
        //}
        public abstract void MakeMove(Map map);//сделать ход
    }
}

//Абстрактный класс, наследуется от Entity.
//Существо, имеет скорость (сколько клеток может пройти за 1 ход), количество HP.
//Имеет метод makeMove() - сделать ход.