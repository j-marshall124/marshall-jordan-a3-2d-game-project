// Include the namespaces (code libraries) you need below.
using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Timers;
using System.Xml.Serialization;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        Portal portals = new Portal();
        Enemy[] enemies = new Enemy[50];

        int playerLives = 3;
        int score = 0;
        int count = 0;

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
            Text.Draw($"Lives: ", 4, 763);
            Text.Draw($"Score: ", 250, 763);
        }
        void Gameplay()
        {
            Window.ClearBackground(bg);

            player.PlayerLoad();
            portals.PortalLoad();
            if (Input.IsKeyboardKeyPressed(KeyboardInput.A))
            {
                if (enemies.Length < 100)
                    enemies[count] = new Enemy();
                count++;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
            }

            for (int i = 0; i < count; i++)
            {
                // Pull one item out of array
                Enemy enemy = enemies[i];
                enemy.EnemyLoad();
                enemy.MoveEnemy();
            }

            // If enemy crosses top of screen, score increases

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
