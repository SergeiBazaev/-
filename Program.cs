using System;
using SFML.Learning;
using SFML.Graphics;
using SFML.Window;


namespace ConsoleApp1 
{
    internal class Program : Game
    {

        static string newCount = LoadSound("knopka-schelchok-dalekii-nejnyii-myagkii1.wav");
        static string fall = LoadSound("__raclure__wrong.wav");
       

        static void Main(string[] args)
        {

            

            InitWindow(800, 600, "Color");
            
            SetFont("timesbd.ttf");

            Random rnd = new Random();

            int currentColor = 0;
            int currentText;

            int playerDirection = -1;

            int count = 0;
            int record = 0;
            bool isGame = false;
            int timer = 2500;
            


            Color[] colors = new Color[] { Color.Blue, Color.Cyan, Color.Red, Color.Green };


            string[] strColor = new string[] { "Синий", "Голубой", "Красный", "Зеленый" };

            

            while (true)
            {

                DispatchEvents();



                if (isGame == true)
                {

                    Console.WriteLine("rrr");

                    if (GetKeyDown(Keyboard.Key.C))
                    {


                        playerDirection = 0;
                        //break;
                    }
                    if (GetKeyDown(Keyboard.Key.U))
                    {


                        playerDirection = 1;
                        //break;
                    }
                    if (GetKeyDown(Keyboard.Key.R))
                    {


                        playerDirection = 2;
                        // break;
                    }
                    if (GetKeyDown(Keyboard.Key.P))
                    {


                        playerDirection = 3;
                        // break;
                    }


                    Console.WriteLine(playerDirection);
                    Console.WriteLine(currentColor);
                    if (currentColor == playerDirection)
                    {
                        count++;

                        PlaySound(newCount);
                    }
                    else
                    {


                        PlaySound(fall);
                        isGame = false;

                    }

                }
                

                
                if (isGame == false)
                {
                    
                    if (count > record)
                    {
                        record = count;
                        
                        
                    }
                    
                    count = 0;
                    timer = 2500;
                    isGame = true;
                    
                }
                playerDirection = -1;
                currentColor = rnd.Next(0, 4);
                currentText = rnd.Next(0, 4);

                ClearWindow();

                

                SetFillColor(250, 250, 250);
                DrawText(5, 5, "Инструкция", 24);
                DrawText(25, 30, "Укажите правильный цвет надписи.", 24);
                DrawText(25, 70, "На обдумывание хода дается 2,5 секунды.", 18);
                DrawText(25, 100, "Как только текущий результат станет равен 10, ", 18);
                DrawText(25, 130, "на обдумывание будет дано только 1,5 секунды.", 18);

                DrawText(5, 170, "Клавиши: ", 24);

                DrawText(25, 195, "Синий      :    С", 24);
                DrawText(25, 220, "Голубой   :    Г ", 24);
                DrawText(25, 245, "Красный :    К", 24);
                DrawText(25, 270, "Зеленый  :    З", 24);

                DrawText(100, 395, "Текущий результат:     ", 24);
                DrawText(350, 350,count.ToString(), 70);

                SetFillColor(colors[currentColor]);
                DrawText(200, 430, strColor[currentText], 100);

                SetFillColor(250, 250, 250);
                DrawText(5, 560, "Максимальный результат:     " + record.ToString(), 24);

                

                DisplayWindow();
                if (count >= 10) timer = 1500;
                Console.WriteLine(timer);
                Console.WriteLine(count);
                Delay(timer);

               

            }
            Console.ReadLine();
        }
    }
}
