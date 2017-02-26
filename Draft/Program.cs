using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Draft.ConsoleRenderer;
using static Draft.ConsoleRenderer.Engine;

namespace Draft

{
    public class UsersManager : IUsersManager

    {

        public string RequestUserName(IRenderer renderer)

        {

            renderer.RenderUsernameRequest();

            string userName = Console.ReadLine();



            return userName;

        }

    }
    public static class StatsCalculator

    {

        private static int score = -50;

        private static int eatenFoodCounter = -1;

        private static int level = 1;

        private static int levelUpCounter = 2000;



        public static int Score

        {

            get

            {

                return score;

            }

        }



        public static int EatenFoodcounter

        {

            get

            {

                return eatenFoodCounter;

            }

        }



        public static int Level

        {

            get

            {

                return level;

            }

        }



        public static void CalculateEatenFoodScore()

        {

            score += 50;

        }



        public static void CalculateEatenFoodCount()

        {

            eatenFoodCounter += 1;

        }



        public static void CalculateLevel()

        {

            levelUpCounter--;



            if (levelUpCounter % 200 == 0)

            {

                level++;

            }

        }



        public static void FinalizeScore(string userName)

        {

            int lineToEdit = 1;



            List<string> fileLines = FileOperator.ReadHighScoreFile();



            foreach (var line in fileLines)

            {

                string[] parts = line.Split(' ');



                int lastBestScore = int.Parse(parts[0]);



                if (lastBestScore < score)

                {

                    break;

                }



                lineToEdit++;

            }



            string scoreInfo = string.Format("{0,-4} {1}", score, userName);



            for (int currentLine = 0; currentLine < fileLines.Count; currentLine++)

            {

                if (currentLine + 1 == lineToEdit)

                {

                    fileLines.Insert(currentLine, scoreInfo);

                    fileLines.RemoveAt(3);

                }

            }



            FileOperator.WriteHighScoreFile(fileLines);

        }

    }
    public class SnakeMain

    {

        /// <summary>

        /// Defines the entry point of the application.

        /// </summary>

        public static void Main()

        {

            // Game settings

            const int gameFieldHeight = 20;

            const int gameFieldWidth = 30;

            const int creatureLength = 5;

            const int foodAmountOnScreen = 1;



            // Initialize the game engine

            IUserController controller = new KeyboardController();

            IEngine gameEngine = new Engine(new ConsoleRenderer(new GameFieldCoords(gameFieldHeight, gameFieldWidth)),

                                            new Snake(creatureLength),

                                            new List<IEatable>(foodAmountOnScreen),

                                            new CollisionHandler(),

                                            new UsersManager(),

                                            controller);



            controller.OnUpPressed += (sender, eventInfo) =>

            {

                gameEngine.CreatureDirectionChange("up");

            };



            controller.OnRightPressed += (sender, eventInfo) =>

            {

                gameEngine.CreatureDirectionChange("right");

            };



            controller.OnDownPressed += (sender, eventInfo) =>

            {

                gameEngine.CreatureDirectionChange("down");

            };



            controller.OnLeftPressed += (sender, eventInfo) =>

            {

                gameEngine.CreatureDirectionChange("left");

            };



            gameEngine.RunGame();

        }

    }
    public class Snake : IHungryCreature

    {

        // Initialize data types

        private readonly char renderingSymbol = '*';



        private Queue<GameFieldCoords> snakeElements = new Queue<GameFieldCoords>();

        private KeyboardController keyboard = new KeyboardController();



        private string currentDirection = "up";

        private bool isDestroyed = false;

        private bool isGettingBigger = false;



        // Snake's constructor

        public Snake(int length)

        {

            this.InitializeSnake(length);

        }



        public char RenderingSymbol

        {

            get

            {

                return this.renderingSymbol;

            }

        }



        public bool IsDestroyed

        {

            get

            {

                return this.isDestroyed;

            }



            set

            {

                this.isDestroyed = value;

            }

        }



        public void Update()

        {

            // Get new head position

            GameFieldCoords newHeadPosition;



            if (this.currentDirection == "up")

            {

                newHeadPosition = new GameFieldCoords(this.snakeElements.Last().Row - 1, this.snakeElements.Last().Col);

            }

            else if (this.currentDirection == "right")

            {

                newHeadPosition = new GameFieldCoords(this.snakeElements.Last().Row, this.snakeElements.Last().Col + 1);

            }

            else if (this.currentDirection == "down")

            {

                newHeadPosition = new GameFieldCoords(this.snakeElements.Last().Row + 1, this.snakeElements.Last().Col);

            }

            else

            {

                newHeadPosition = new GameFieldCoords(this.snakeElements.Last().Row, this.snakeElements.Last().Col - 1);

            }



            // Add new snake element to the new position

            this.snakeElements.Enqueue(newHeadPosition);



            if (!this.isGettingBigger)

            {

                // Remove the last element if the snake is not getting bigger

                this.snakeElements.Dequeue();

            }



            this.isGettingBigger = false;

        }



        public void ChangeDirection(string newDirection)

        {

            // Change snake's moving direction

            if (!(this.currentDirection == "up" && newDirection == "down")

                && !(this.currentDirection == "right" && newDirection == "left")

                && !(this.currentDirection == "down" && newDirection == "up")

                && !(this.currentDirection == "left" && newDirection == "right"))

            {

                this.currentDirection = newDirection;

            }

        }



        public void GetBigger()

        {

            this.isGettingBigger = true;

        }



        public List<GameFieldCoords> GetPosition()

        {

            List<GameFieldCoords> currentPosition = new List<GameFieldCoords>();



            foreach (GameFieldCoords position in this.snakeElements)

            {

                currentPosition.Add(position);

            }



            return currentPosition;

        }



        private void InitializeSnake(int length)

        {

            int horizontalOffset = 13;

            int verticalOffset = 18;



            int creatureTailPositionRow;

            int creatureTailPositionCol = verticalOffset;



            for (int counter = length; counter > 0; counter--)

            {

                creatureTailPositionRow = counter + horizontalOffset;



                this.snakeElements.Enqueue(new GameFieldCoords(creatureTailPositionRow, creatureTailPositionCol));

            }

        }

    }
    public class KeyboardController : IUserController

    {

        // Direction events

        public event EventHandler OnUpPressed;



        public event EventHandler OnRightPressed;



        public event EventHandler OnDownPressed;



        public event EventHandler OnLeftPressed;



        public void ProcessInput()

        {

            if (Console.KeyAvailable)

            {

                var keyInfo = Console.ReadKey();



                if (keyInfo.Key == ConsoleKey.UpArrow)

                {

                    if (this.OnUpPressed != null)

                    {

                        this.OnUpPressed(this, new EventArgs());

                    }

                }

                else if (keyInfo.Key == ConsoleKey.RightArrow)

                {

                    if (this.OnRightPressed != null)

                    {

                        this.OnRightPressed(this, new EventArgs());

                    }

                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)

                {

                    if (this.OnDownPressed != null)

                    {

                        this.OnDownPressed(this, new EventArgs());

                    }

                }

                else if (keyInfo.Key == ConsoleKey.LeftArrow)

                {

                    if (this.OnLeftPressed != null)

                    {

                        this.OnLeftPressed(this, new EventArgs());

                    }

                }

            }

        }

    }
    public interface IUsersManager

    {

        string RequestUserName(IRenderer renderer);

    }
    public interface IUserController

    {

        event EventHandler OnUpPressed;



        event EventHandler OnRightPressed;



        event EventHandler OnDownPressed;



        event EventHandler OnLeftPressed;



        void ProcessInput();

    }
    public interface IRenderer

    {

        GameFieldCoords GameFieldSize { get; }

        void EnqueueForRendering(IRenderable objForRendering);

        void RenderScores();

        void RenderAll();

        void RenderEndGame();

        void RenderUsernameRequest();

        void ClearConsole();

    }
    public interface IRenderable

    {

        char RenderingSymbol { get; }



        List<GameFieldCoords> GetPosition();

    }

    public interface IHungryCreature : IRenderable

    {

        void ChangeDirection(string newDirection);

        void GetBigger();

        bool IsDestroyed { get; set; }

        void Update();

    }
    public interface IEngine

    {

        void GameOver();

        void RunGame();

        void CreatureDirectionChange(string newDirection);

    }
    public interface IEatable : IRenderable

    {

        List<GameFieldCoords> GetPosition();

        bool IsEaten { get; }

        char RenderingSymbol { get; }

        void RespondToEating();

    }
    public interface ICollisionHandler

    {

        void HandleCollisions(IHungryCreature creature, System.Collections.Generic.IList<IEatable> foodList, IRenderer renderer);

    }
    public class GameSettings

    {

        private int gameFieldHeight;



        public GameSettings(int gameFieldHeight, int gameFieldWidth, int creatureLength, int foodAmountOnScreen)

        {



        }



        public int GameFieldHeight

        {

            get

            {

                return this.gameFieldHeight;

            }

            private set

            {

                if (value >= 19)

                {

                    this.gameFieldHeight = value;

                }

                else

                {

                    this.gameFieldHeight = 19;

                }

            }

        }

    }
    public class GameFieldCoords

    {

        public GameFieldCoords(int row, int col)

        {

            this.Row = row;

            this.Col = col;

        }



        public int Row { get; set; }



        public int Col { get; set; }

    }
    public class Food : IEatable

    {

        private readonly char renderingSymbol = '@';



        private GameFieldCoords foodCoords;



        public Food(GameFieldCoords position)

        {

            this.foodCoords = new GameFieldCoords(position.Row, position.Col);

        }



        public char RenderingSymbol

        {

            get

            {

                return this.renderingSymbol;

            }

        }



        public bool IsEaten { get; private set; }



        public void RespondToEating()

        {

            this.IsEaten = true;

        }



        public List<GameFieldCoords> GetPosition()

        {

            List<GameFieldCoords> foodPosition = new List<GameFieldCoords>();



            foodPosition.Add(this.foodCoords);



            return foodPosition;

        }

    }

    public class CollisionHandler : ICollisionHandler

    {

        public void HandleCollisions(IHungryCreature creature, IList<IEatable> foodList, IRenderer renderer)

        {

            HandleEating(creature, foodList);

            HandleCollision(creature, renderer);

        }



        private void HandleEating(IHungryCreature snake, IList<IEatable> listOfEatables)

        {

            foreach (IEatable eatable in listOfEatables)

            {

                foreach (GameFieldCoords snakeElementPosition in snake.GetPosition())

                {

                    if (eatable.GetPosition()[0].Row == snakeElementPosition.Row

                        && eatable.GetPosition()[0].Col == snakeElementPosition.Col)

                    {

                        snake.GetBigger();

                        eatable.RespondToEating();

                    }

                }

            }

        }



        private void HandleCollision(IHungryCreature creature, IRenderer renderer)

        {

            List<GameFieldCoords> creatureElements = new List<GameFieldCoords>();



            foreach (GameFieldCoords element in creature.GetPosition())

            {

                creatureElements.Add(element);

            }



            foreach (GameFieldCoords element in creatureElements)

            {

                if (element.Row >= renderer.GameFieldSize.Row || element.Row < 0

                    || element.Col >= renderer.GameFieldSize.Col || element.Col < 0)

                {

                    creature.IsDestroyed = true;

                }

            }



            for (int element = 0; element < creatureElements.Count - 1; element++)

            {

                if (creatureElements.Last().Row == creatureElements[element].Row

                    && creatureElements.Last().Col == creatureElements[element].Col)

                {

                    creature.IsDestroyed = true;

                }

            }

        }

    }
    public class ConsoleRenderer : IRenderer

    {

        // Initialize data types

        private char[,] gameField;



        private GameFieldCoords gameFieldSize;

        private GameFieldCoords consoleSize;



        private List<string> highScores;



        private CursorPosition levelInfoPosition;

        private CursorPosition scoreInfoPosition;

        private CursorPosition foodInfoPosition;

        private CursorPosition gameOverInfoPosition;

        private CursorPosition finalPosition;

        private CursorPosition highScoreTitlePosition;

        private CursorPosition firstPlaceScorePosition;

        private CursorPosition secondPlaceScorePosition;

        private CursorPosition thirdPlaceScorePosition;



        // Console Renderer's constructor

        public ConsoleRenderer(GameFieldCoords size)

        {

            this.InitializeGameField(size);

            this.gameFieldSize = size;



            this.consoleSize = new GameFieldCoords(this.gameFieldSize.Row + 2, this.gameFieldSize.Col + 21);



            this.highScores = FileOperator.ReadHighScoreFile();



            Console.CursorVisible = false;



            Console.WindowHeight = this.consoleSize.Row;

            Console.BufferHeight = Console.WindowHeight;



            Console.WindowWidth = this.consoleSize.Col;

            Console.BufferWidth = Console.WindowWidth;



            this.InitializeCursorPostions();

        }



        public GameFieldCoords GameFieldSize

        {

            get

            {

                return this.gameFieldSize;

            }

        }



        public void EnqueueForRendering(IRenderable objForRendering)

        {

            List<GameFieldCoords> objPosition = objForRendering.GetPosition();



            foreach (GameFieldCoords position in objPosition)

            {

                this.gameField[position.Row, position.Col] = objForRendering.RenderingSymbol;

            }

        }



        public void RenderAll()

        {

            Console.SetCursorPosition(0, 0);



            // Render upper border

            Console.Write(" ");

            for (int borderCounter = 0; borderCounter < this.gameFieldSize.Col + 2; borderCounter++)

            {

                Console.Write("-");

            }



            Console.WriteLine();



            for (int row = 0; row < this.gameField.GetLength(0); row++)

            {

                // Render left border

                Console.Write(" |");



                // Render game field

                for (int col = 0; col < this.gameField.GetLength(1); col++)

                {

                    Console.Write(this.gameField[row, col]);

                    this.gameField[row, col] = ' ';

                }



                // Render right border

                Console.Write("|");



                Console.WriteLine();

            }



            // Render bottom border

            Console.Write(" ");

            for (int borderCounter = 0; borderCounter < this.gameFieldSize.Col + 2; borderCounter++)

            {

                Console.Write("-");

            }



            this.RenderScores();

        }



        public void RenderScores()

        {

            // Render level text

            Console.SetCursorPosition(this.levelInfoPosition.Col, this.levelInfoPosition.Row);

            Console.Write("LEVEL {0}", StatsCalculator.Level);



            // Render score text

            Console.SetCursorPosition(this.scoreInfoPosition.Col, this.scoreInfoPosition.Row);

            Console.Write("Score: {0}", StatsCalculator.Score);



            // Render food eaten text

            Console.SetCursorPosition(this.foodInfoPosition.Col, this.foodInfoPosition.Row);

            Console.Write("Food eaten: {0}", StatsCalculator.EatenFoodcounter);



            // Render high score text

            Console.SetCursorPosition(this.highScoreTitlePosition.Col, this.highScoreTitlePosition.Row);

            Console.Write("High Score:");

            Console.SetCursorPosition(this.firstPlaceScorePosition.Col, this.firstPlaceScorePosition.Row);

            Console.Write("{0}", this.highScores[0]);

            Console.SetCursorPosition(this.secondPlaceScorePosition.Col, this.secondPlaceScorePosition.Row);

            Console.Write("{0}", this.highScores[1]);

            Console.SetCursorPosition(this.thirdPlaceScorePosition.Col, this.thirdPlaceScorePosition.Row);

            Console.Write("{0}", this.highScores[2]);

        }



        public void RenderEndGame()

        {

            this.RenderScores();



            // Render game over text

            Console.SetCursorPosition(this.gameOverInfoPosition.Col, this.gameOverInfoPosition.Row);

            Console.WriteLine("GAME OVER!");

            Console.SetCursorPosition(this.finalPosition.Col, this.finalPosition.Row);

        }



        public void RenderUsernameRequest()

        {

            // Render username request text

            Console.WriteLine("Welcome to Snake by N. Donchev\n");

            Console.Write("Plese enter your User Name: ");

        }



        public void ClearConsole()

        {

            Console.Clear();

        }



        private void InitializeGameField(GameFieldCoords size)

        {

            Console.Title = "Snake Game";



            this.gameField = new char[size.Row, size.Col];



            for (int row = 0; row < this.gameField.GetLength(0); row++)

            {

                for (int col = 0; col < this.gameField.GetLength(1); col++)

                {

                    this.gameField[row, col] = ' ';

                }

            }

        }



        private struct CursorPosition

        {

            public int Row;

            public int Col;

        }



        private void InitializeCursorPostions()

        {

            this.levelInfoPosition.Col = Console.WindowWidth - 17;

            this.levelInfoPosition.Row = Console.WindowHeight - 21;



            this.scoreInfoPosition.Col = Console.WindowWidth - 17;

            this.scoreInfoPosition.Row = Console.WindowHeight - 17;



            this.foodInfoPosition.Col = Console.WindowWidth - 17;

            this.foodInfoPosition.Row = Console.WindowHeight - 15;



            this.gameOverInfoPosition.Col = Console.WindowWidth - 17;

            this.gameOverInfoPosition.Row = Console.WindowHeight - 11;



            this.highScoreTitlePosition.Col = Console.WindowWidth - 17;

            this.highScoreTitlePosition.Row = Console.WindowHeight - 7;



            this.firstPlaceScorePosition.Col = Console.WindowWidth - 17;

            this.firstPlaceScorePosition.Row = Console.WindowHeight - 5;



            this.secondPlaceScorePosition.Col = Console.WindowWidth - 17;

            this.secondPlaceScorePosition.Row = Console.WindowHeight - 4;



            this.thirdPlaceScorePosition.Col = Console.WindowWidth - 17;

            this.thirdPlaceScorePosition.Row = Console.WindowHeight - 3;



            this.finalPosition.Col = 0;

            this.finalPosition.Row = Console.WindowHeight - 1;

        }
        public class Engine : IEngine

        {

            // Initializing data types

            private int foodAmount;

            private bool gameRunning = true;

            private decimal gameSpeed = 75;

            private string userName;

            private IRenderer renderer;

            private IUserController controller;

            private IHungryCreature creature;

            private List<IEatable> eatables;

            private ICollisionHandler collisionHandler;



            private Random foodPositionGenerator = new Random();



            // Engine constructor

            public Engine(IRenderer renderer,

                          IHungryCreature creature,

                          List<IEatable> eatables,

                          ICollisionHandler collisionHandler,

                          IUsersManager usersManager,

                          IUserController controller)

            {

                this.userName = usersManager.RequestUserName(renderer);

                this.foodAmount = eatables.Capacity;

                this.renderer = renderer;

                this.controller = controller;

                this.eatables = eatables;

                this.creature = creature;

                this.collisionHandler = collisionHandler;



                // Clear the console so the username won't be stuck on the scores screen

                renderer.ClearConsole();



                for (int counter = 0; counter < foodAmount; counter++)

                {

                    this.AddFood();

                }

            }



            public void RunGame()

            {

                // Game loop

                while (this.gameRunning)

                {

                    // Process user's input

                    this.controller.ProcessInput();



                    // Update creature's position and size

                    this.creature.Update();



                    // Handle collisions

                    collisionHandler.HandleCollisions(this.creature, this.eatables, this.renderer);



                    // Game over if creature is dead (stops the loop)

                    if (this.creature.IsDestroyed)

                    {

                        this.GameOver();

                        continue;

                    }



                    // Enqueue the creature for rendering

                    this.renderer.EnqueueForRendering(this.creature);



                    // If there is a eatable eated - add new one

                    if (this.eatables.Any(food => food.IsEaten))

                    {

                        this.AddFood();

                    }



                    // Remove eaten eatables

                    this.eatables.RemoveAll(food => food.IsEaten);



                    // Enqueue eatables for rendering

                    for (int food = 0; food < this.eatables.Count; food++)

                    {

                        this.renderer.EnqueueForRendering(this.eatables[food]);

                    }



                    // Render all objects

                    this.renderer.RenderAll();



                    if (this.gameSpeed > 1)

                    {

                        this.gameSpeed -= 0.1M;

                    }



                    StatsCalculator.CalculateLevel();



                    // Slow down the game loop so it is playable

                    Thread.Sleep((int)this.gameSpeed);

                }



                // Sleep on Game over so the user won't accidently close the game screen

                Thread.Sleep(2000);

                Console.Write("Press any key to exit");



                while (Console.KeyAvailable)

                {

                    Console.ReadKey(false);

                }



                Console.ReadKey();

            }



            public void CreatureDirectionChange(string newDirection)

            {

                this.creature.ChangeDirection(newDirection);

            }



            public void GameOver()

            {

                this.gameRunning = false;



                StatsCalculator.FinalizeScore(this.userName);



                this.renderer.RenderEndGame();

            }



            private void AddFood()

            {

                // Initialize data types

                int foodPlaceRow;

                int foodPlaceCol;

                bool invalidFoodPosition;



                // Update scores

                StatsCalculator.CalculateEatenFoodScore();

                StatsCalculator.CalculateEatenFoodCount();



                do

                {

                    invalidFoodPosition = false;



                    // Get random position for new eatable

                    foodPlaceRow = this.foodPositionGenerator.Next(0, this.renderer.GameFieldSize.Row - 1);

                    foodPlaceCol = this.foodPositionGenerator.Next(0, this.renderer.GameFieldSize.Col - 1);



                    // Check if the position isn't occupied

                    for (int element = 0; element < this.creature.GetPosition().Count; element++)

                    {

                        if (foodPlaceRow == this.creature.GetPosition()[element].Row

                            && foodPlaceCol == this.creature.GetPosition()[element].Col)

                        {

                            invalidFoodPosition = true;

                        }

                    }

                }

                // While the current postion is invalid, get new position

                while (invalidFoodPosition);



                // Add the eatable to the position

                this.eatables.Add(new Food(new GameFieldCoords(foodPlaceRow, foodPlaceCol)));

            }



            private void ProcessUserInput()

            {

                // Process Up direction

                this.controller.OnUpPressed += (sender, eventInfo) =>

                {

                    creature.ChangeDirection("up");

                };



                // Process Right direction

                this.controller.OnRightPressed += (sender, eventInfo) =>

                {

                    creature.ChangeDirection("right");

                };



                // Process Down direction

                this.controller.OnDownPressed += (sender, eventInfo) =>

                {

                    creature.ChangeDirection("down");

                };



                // Process Left direction

                this.controller.OnLeftPressed += (sender, eventInfo) =>

                {

                    creature.ChangeDirection("left");

                };

            }
            public static class FileOperator

            {

                private static List<string> fileLines = new List<string>();



                public static List<string> ReadHighScoreFile()

                {

                    StreamReader fileReader;



                    fileLines.Clear();



                    fileReader = new StreamReader(@"C:\Users\Нурсултан Алмаханов\Documents\visual studio 2015\Projects\Lab_Works\Draft\bin\Debug\HighScores\high_scores.txt");



                    using (fileReader)

                    {

                        for (int counter = 0; counter < 3; counter++)

                        {

                            fileLines.Add(fileReader.ReadLine());

                        }

                    }



                    return fileLines;

                }



                public static void WriteHighScoreFile(List<string> scoreInfo)

                {

                    using (StreamWriter fileWriter = new StreamWriter(@"C:\Users\Нурсултан Алмаханов\Documents\visual studio 2015\Projects\Lab_Works\Draft\bin\Debug\HighScores\high_scores.txt"))

                    {

                        foreach (string line in scoreInfo)

                        {

                            fileWriter.WriteLine(line);

                        }

                    }

                }

            }

        }

    }

}