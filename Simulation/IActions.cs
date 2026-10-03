using Simulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation
{
    interface IActions
    {

    }
}

//Actions - список действий, исполняемых перед стартом симуляции или на каждом ходу (детали ниже)
//Методы:

//nextTurn() - просимулировать и отрендерить один ход
//startSimulation() - запустить бесконечный цикл симуляции и рендеринга
//pauseSimulation() - приостановить бесконечный цикл симуляции и рендеринга