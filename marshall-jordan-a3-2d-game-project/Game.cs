// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Texture2D sword;
        Texture2D sword2;
        Texture2D sword3;
        Texture2D sword10;
        Texture2D back;

        public void Setup()
        {
            Window.SetTitle("Matching Game");
            Window.SetSize(800, 600);
            sword = Graphics.LoadTexture("C:/Users/Jordan/source/repos/marshall-jordan-a3-2d-game-project/assets/graphics/sword01.png");
            sword2 = Graphics.LoadTexture("C:/Users/Jordan/source/repos/marshall-jordan-a3-2d-game-project/assets/graphics/sword02.png");
            sword3 = Graphics.LoadTexture("C:/Users/Jordan/source/repos/marshall-jordan-a3-2d-game-project/assets/graphics/sword03.png");
            sword10 = Graphics.LoadTexture("C:/Users/Jordan/source/repos/marshall-jordan-a3-2d-game-project/assets/graphics/sword10.png");
            back = Graphics.LoadTexture("C:/Users/Jordan/source/repos/marshall-jordan-a3-2d-game-project/assets/graphics/back.png");
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Text.Draw("TIMER", 350, 25); // Timer
            Text.Draw($"POINTS: ", 600, 25); // Points
            Draw(back, 75, 75);
            Draw(back, 250, 75);
            Draw(back, 425, 75);
            Draw(back, 600, 75);

            Draw(back, 75, 250);
            Draw(back, 250, 250);
            Draw(back, 425, 250);
            Draw(back, 600, 250);

            Draw(back, 75, 425);
            Draw(back, 250, 425);
            Draw(back, 425, 425);
            Draw(back, 600, 425);

            if (Input.IsMouseButtonDown(0))
            {
                Draw(sword, 75, 75);
                Draw(sword2, 250, 75);
                Draw(sword3, 425, 75);
                Draw(sword10, 600, 75);
            }
        }

        public void Draw(Texture2D graphic, float x, float y)
        {
            Graphics.Draw(graphic, x, y);
        }
    }
}
