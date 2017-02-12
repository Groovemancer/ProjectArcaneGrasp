using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectArcaneGrasp
{
    public static class Tile
    {
        public static Texture2D TilesetTexture;
        public static int TileWidth = 100;
        public static int TileHeight = 100;
        public static int TileStepX = 148;
        public static int TileStepY = 32;
        public static int OddRowXOffset = 74;

        public static Vector2 originPoint = new Vector2(48, 106);

        public static Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TilesetTexture.Width / TileWidth);
            int tileX = tileIndex % (TilesetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}
