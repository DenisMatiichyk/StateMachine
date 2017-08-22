using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testState
{
    class Program
    {
        class GameState 
        {
            public IGameState State { get; set; }
            public GameState(IGameState gameState)
            {
                State = gameState;

            }

            public void NewGame(GameState gameState)
            {
                State.NewGame(this);
            }

            public void Start(GameState gameState)
            {
                State.Start(this);
            }

            public void TakeCard(GameState gameState)
            {
                State.TakeCard(this);
            }
        }

        interface IGameState
        {
            void NewGame(GameState gameState);
            void Start(GameState gameState);
            void TakeCard(GameState gameState);
            
        }

        class NewGame : IGameState
        {
            public void Start(GameState gameState)
            {
                
            }

            public void TakeCard(GameState gameState)
            {
                throw new NotImplementedException();
            }

            void IGameState.NewGame(GameState gameState)
            {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            Console.Read();
        }
    }

    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }


        public void Heat()
        {
            State.Heat(this);
        }

        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем лед в жидкость Transform ice to liquid");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Продолжаем заморозку льда Continue frost ice");
        }
    }

    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в пар Transform liquid to gas");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лед Transform liquid to ice");
            water.State = new SolidWaterState();
        }
    }

    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Повышаем температуру водяного пара Raising temperature water gas");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем водяной пар в жидкость Trasform water gas to liquid");
            water.State = new LiquidWaterState();
        }
    }
}