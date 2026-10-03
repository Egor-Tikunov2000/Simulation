using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Map
{
    public class MapSetttings
    {
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 50;
    
    }
}
//Проверка границ: всякий раз, когда ваше моделирование перемещает объект, напишите вспомогательный метод:
//csharp
//private bool IsWithinBounds(int x, int y)
//{
//    return x >= 0 && x < Width && y >= 0 && y < Height;
//}
//Это предотвращает печально известную ошибку IndexOutOfRangeException.