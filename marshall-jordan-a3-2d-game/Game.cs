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
        Texture2D bg = Graphics.LoadTexture("../../../../assets/graphics/bg.png");
        Sound hurt = Audio.LoadSound("../../../../assets/audio/hurt.ogg");
        Sound portal = Audio.LoadSound("../../../../assets/audio/pop2.wav");
        Music menu = Audio.LoadMusic("../../../../assets/audio/Stage Select.ogg");
        Music level = Audio.LoadMusic("../../../../assets/audio/Stage 1.ogg");
        Font text = Text.LoadFont("../../../../assets/fonts/game font.ttf");


        int playerLives = 3;
        int score = 0;
        int count = 0;

        float randomSpawnTime = Random.Float(0, 5); // Random time between 0 and 5 seconds

        Color green = new Color(115, 128, 75);
        bool showStart = true;
        bool isGameOver = false;

        public void Setup()
        {
            Window.SetTitle("Robot Game");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
            Time.SecondsElapsed = 0;
            count = 0;
            Audio.Play(level);

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
                Text.Draw($"Lives: {playerLives}", 5, 760, text);
                Text.Draw($"Score: {score}", 250, 760, text);
            }
        }
        void Gameplay()
        {
            Window.ClearBackground(green);
            Graphics.Draw(bg, 0, 0);

            player.PlayerLoad();
            portals.PortalLoad();

            if (Time.SecondsElapsed > randomSpawnTime && count < enemies.Length) // spawns enemies
            {
                enemies[count] = new Enemy();
                count++;
                Audio.Play(portal);
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

                foreach (Enemy e in enemies) // checks collision for each enemy
                {
                    float distance = (e.enemyPosition - player.playerPosition).Length();
                    float collisionDistance = e.collisionRadius + player.collisionRadius;
                    if (distance < collisionDistance) // if player collides with an enemy
                    {
                        Graphics.Draw(player.playerHurt, player.playerPosition); // player hurt sprite
                        Audio.Play(hurt);
                        playerLives -= 1; // loses 1 life
                        Setup(); // resets the scene
                        if (playerLives <= 0) // game over
                        {
                            isGameOver = true;
                        }
                    }
                }
            }
        }

        void StartScreen()
        {
            Window.ClearBackground(green);
            Graphics.Draw(logo, 67, 200);
            Text.Draw("Click anywhere to start", 125, 500, text);            

            if (Input.IsMouseButtonDown(0))
            {
                showStart = false;
            }
        }

        void EndScreen()
        {
            Window.ClearBackground(green);
            Text.Draw("GAME OVER!", 225, 300, text);
            Text.Draw($"Your Score: {score}", 195, 350, text);
            Text.Draw("Click anywhere to play again", 80, 400, text);            

            if (Input.IsMouseButtonDown(0))
            {
                isGameOver = false;
                playerLives = 3;
                score = 0;
                Audio.Stop(level);
                Setup();
            }
        }
    }

}
