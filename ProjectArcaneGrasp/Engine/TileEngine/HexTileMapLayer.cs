using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectArcaneGrasp
{
    public class HexTileMapLayer
    {
        int layerWidth;
        int layerHeight;
        List<HexTile> layer;
        Dictionary<CubeCoord, HexTile> hexTiles = new Dictionary<CubeCoord, HexTile>();
        Texture2D tilesetTexture;
        
        public HexTileMapLayer(Texture2D tileset, int width, int height)
        {
            layer = new List<HexTile>();
            tilesetTexture = tileset;
            layerWidth = width;
            layerHeight = height;
            
            for (int q = 0; q < layerWidth; q++)
            {
                int qOffset = q >> 1;
                for (int r = -qOffset; r < layerHeight - qOffset; r++)
                {
                    int s = -q - r;
                    CubeCoord cube = new CubeCoord(q, r, s);
                    int id = 0;
                    //if (q == 2 && r == -1 && s == -1) id = 1;
                    if (q == 3 && r == 1 && s == -4) id = 2;
                    if (q == 4 && r == 0 && s == -4) id = 5;
                    //layer.Add(new HexTile(cube, id, 100, 100, 48, 32, 35));
                    //hexTiles.Add(cube, new HexTile(cube, id, 100, 100, 48, 32, 35));
                    layer.Add(new HexTile(cube, id, 160, 160, 77, 52, 56));
                    hexTiles.Add(cube, new HexTile(cube, id, 160, 160, 77, 52, 56));
                }
            }
        }

        public Rectangle GetSourceRectangle(int tileIndex, int tileWidth, int tileHeight)
        {
            int tileY = tileIndex / (tilesetTexture.Width / tileWidth);
            int tileX = tileIndex % (tilesetTexture.Width / tileHeight);

            return new Rectangle(tileX * tileWidth, tileY * tileHeight, tileWidth, tileHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (HexTile hex in layer)
            {
                Point p = hex.ScreenPos();
                float depth = 1f / Math.Max(p.Y + hex.OffsetY, 1.1f);
                spriteBatch.Draw(tilesetTexture, new Vector2(p.X, p.Y), GetSourceRectangle(hex.TextureId, hex.Width, hex.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, depth);

                if (Debug.DebugText)
                {
                    int x = p.X + (hex.Width / 4) + 6;
                    int y = p.Y + ((hex.Height - hex.OffsetY) / 2) + hex.OffsetY - 4;
                    string text = hex.Q + "," + hex.R + "," + hex.S;
                    spriteBatch.DrawString(Debug.DebugFont, text, new Vector2(x, y), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }
        }

        public HexTile GetHexTile(int q, int r, int s)
        {
            HexTile result = null;
            foreach (HexTile hexTile in layer)
            {
                if (hexTile.Q != q)
                    continue;
                if (hexTile.R != r)
                    continue;
                if (hexTile.S != s)
                    continue;
                result = hexTile;
            }

            return result;
        }

        public void PrintLayer()
        {
            foreach (HexTile hexTile in layer)
            {
                Debug.Log("Hex: " + hexTile.Q + ", " + hexTile.R + ", " + hexTile.S);
            }
            Debug.Log("Total Hexes: " + layer.Count);
        }

        public void PrintScreenLayer()
        {
            foreach (HexTile hexTile in layer)
            {
                Point p = hexTile.ScreenPos();
                Debug.Log("Hex: " + p.X + ", " + p.Y);
            }
        }
    }
}
