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
        Enemy[] enemies = new Enemy[14];
        Texture2D logo = Graphics.LoadTexture("../../../../assets/graphics/game logo.png");

        int playerLives = 3;
        int score = 0;
        int count = 0;

        float randomSpawnTime = Random.Float(0, 7); // Random time between 0 and 7 seconds

        Color bg = new Color(115, 128, 75);
        bool showStart = true;
        bool isGameOver = false;

        public void Setup()
        {
            Window.SetTitle("Robot Game");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
            Time.SecondsElapsed = 0;

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy();
            }
        }

        public void Update()
        {
            if (showStart == true)
            {
                StartScreen();
            }
            else if (isGameOver == true)
            {
                EndScreen();
            }
            else
            {
                Gameplay();
                Text.Draw($"Lives: {playerLives}", 4, 763);
                Text.Draw($"Score: {score}", 250, 763);
            }
        }
        void Gameplay()
        {
            Window.ClearBackground(bg);

            player.PlayerLoad();
            portals.PortalLoad();

            if (Time.SecondsElapsed > randomSpawnTime && count < enemies.Length) // spawns enemies
            {
                enemies[count] = new Enemy();
                count++;
                Time.SecondsElapsed = 0;
            }

            if (count > enemies.Length)
            {
                count = enemies.Length;
            }

            for (int i = 0; i < count; i++)
            {
                // Pull one item out of array
                Enemy enemy = enemies[i];
                enemy.MoveEnemy();
                enemy.EnemyLoad();
                if (enemy.enemyPosition.Y < -100) // If enemy is off the top of the screen
                {
                    score += 5; // increase score
                    enemy.EnemyRespwn();
                }

                if (score >= 100) // increases enemy max speed
                {
                    enemy.gravity.Y = -250;
                }
                else if (score >= 200)
                {
                    enemy.gravity.Y = -300;
                }
                else if (score >= 300)
                {
                    enemy.gravity.Y = -350;
                }
                else if (score >= 400)
                {
                    enemy.gravity.Y = -400;
                }

                foreach (Enemy e in enemies)
                {
                    float distance = (e.enemyPosition - player.playerPosition).Length();
                    float collisionDistance = e.collisionRadius + player.collisionRadius;
                    if (distance < collisionDistance)
                    {
                        playerLives -= 1;
                    }
                }
            }
        }

        void StartScreen()
        {
            Window.ClearBackground(bg);
            Graphics.Draw(logo, 67, 200);
            Text.Draw("Click anywhere to start", 100, 500);
            if (Input.IsMouseButtonDown(0))
            {
                showStart = false;
            }
        }

        void EndScreen()
        {
            Window.ClearBackground(bg);
            Text.Draw("GAME OVER!", 200, 300);
            Text.Draw($"Your Score: {score}", 170, 350);
            Text.Draw("Click anywhere to play again", 50, 400);

            if (Input.IsMouseButtonDown(0))
            {
                isGameOver = false;
                Setup();
            }
        }
    }

}
