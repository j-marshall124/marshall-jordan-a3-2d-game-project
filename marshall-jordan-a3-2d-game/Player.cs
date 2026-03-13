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
        public void PlayerLoad()
        {
        float mouseX = Input.GetMouseX() - 28;
        float mouseY = Input.GetMouseY() - 44;
        float playerLeft = Input.GetMouseX() + 28;
        float playerRight = Input.GetMouseX() - 56;
        float playerTop = Input.GetMouseY() - 44;
        float playerBottom = Input.GetMouseY() - 88;

            // Constrains play to the play space
            if (playerLeft < 56)
            {
                mouseX = 0;
            }
            if (playerTop < 0)
            {
                mouseY = 0;
            }
            if (playerRight > 518)
            {
                mouseX = 546;
            }
            if (playerBottom > 562)
            {
                mouseY = 606;
            }

            Graphics.Draw(playerFrame1, mouseX, mouseY); // Draws player graphic to the mouse cursor
        }
    }
}
