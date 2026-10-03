using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Map
{
    class Map
    {
        private static Dictionary<Coordinates, Creature> creature = new Dictionary<>();
        public Map() { }

       
    }
}

//Карта, содержит в себе коллекцию для хранения существ и их расположения.
//Советую не спешить использовать двумерный массив или список списков, а подумать какие ещё коллекции могут подойти.