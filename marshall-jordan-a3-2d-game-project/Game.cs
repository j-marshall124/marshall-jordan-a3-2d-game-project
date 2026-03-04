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
        Texture2D heart;
        Texture2D back;

        public void Setup()
        {
            Window.SetTitle("Matching Game");
            Window.SetSize(800, 600);
            sword = Graphics.LoadTexture("../../../../assets/graphics/sword.png");
            heart = Graphics.LoadTexture("../../../../assets/graphics/heart.png");
            back = Graphics.LoadTexture("../../../../assets/graphics/back.png");
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Draw(back, 300, 300);
            if (Input.IsMouseButtonDown(0))
            {
                Draw(sword, 300, 300);
            }
        }

        public void Draw(Texture2D graphic, float x, float y)
        {
            Graphics.Draw(graphic, x, y);
        }
    }
}
