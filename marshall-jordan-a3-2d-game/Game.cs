// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Xml.Serialization;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        Portals portals = new Portals();
        Enemy enemy = new Enemy();

        Color bg = new Color(115, 128, 75);
        bool isGameOver = false;

        public void Setup()
        {
            Window.SetTitle("Robot Game");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
        }

        public void Update()
        {
            Gameplay();
        }
        void Gameplay()
        {
            Window.ClearBackground(bg);

            player.PlayerLoad();
            portals.PortalLoad();
            enemy.EnemyLoad();
        }
        void EndScreen()
        {
            Window.ClearBackground(Color.Yellow);
            Text.Draw("YOU WIN!", 10, 10);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                Setup();
            }
        }
    }

}
