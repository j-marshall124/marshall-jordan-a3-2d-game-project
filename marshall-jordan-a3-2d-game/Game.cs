// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        Portals portals = new Portals();
        Enemies enemies = new Enemies();

        Color bg = new Color(115, 128, 75);

        public void Setup()
        {
            Window.SetTitle("Robot Game");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
        }

        public void Update()
        {
            Window.ClearBackground(bg);

            player.PlayerLoad();
            portals.PortalLoad();
            enemies.EnemyLoad();
        }
    }

}
