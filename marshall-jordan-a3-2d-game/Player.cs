using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace MohawkGame2D
{
    public class Player
    {
        public Texture2D playerFrame1 = Graphics.LoadTexture("../../../../assets/graphics/robot character1.png");
        public Texture2D playerFrame2 = Graphics.LoadTexture("../../../../assets/graphics/robot character2.png");
        public Texture2D playerHurt = Graphics.LoadTexture("../../../../assets/graphics/robot character hurt1.png");
        public float mouseX;
        public float mouseY;
        public Vector2 playerPosition;
        public float collisionRadius = 30;

        public Player()
        {
            mouseX = Input.GetMouseX() - 28;
            mouseY = Input.GetMouseY() - 44;
            playerPosition = new Vector2(mouseX, mouseY);
        }
        public void PlayerLoad()
        {
            float mouseX = Input.GetMouseX() - 28;
            float mouseY = Input.GetMouseY() - 44;
            playerPosition = new Vector2(mouseX, mouseY);

            float playerLeft = playerPosition.X + 28;
            float playerRight = playerPosition.X - 56;
            float playerTop = playerPosition.Y - 44;
            float playerBottom = playerPosition.Y - 88;

            // Constrains play to the play space
            if (playerLeft < 28)
            {
                playerPosition.X = 0;
            }
            if (playerTop < -44)
            {
                playerPosition.Y = 0;
            }
            if (playerRight > 487)
            {
                playerPosition.X = 546;
            }
            if (playerBottom > 520)
            {
                playerPosition.Y = 606;
            }

            Graphics.Draw(playerFrame1, playerPosition); // Draws player graphic to the mouse cursor
        }
    }
}
