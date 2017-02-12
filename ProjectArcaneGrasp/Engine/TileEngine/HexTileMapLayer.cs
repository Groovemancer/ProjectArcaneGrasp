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
                    int id = 1;
                    //if (q == 2 && r == -1 && s == -1) id = 1;
                    if (q == 3 && r == 1 && s == -4) id = 2;
                    if (q == 4 && r == 0 && s == -4) id = 5;
                    layer.Add(new HexTile(cube, id, 100, 100, 48, 32, 35));
                    hexTiles.Add(cube, new HexTile(cube, id, 100, 100, 48, 32, 35));
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
                spriteBatch.Draw(tilesetTexture, new Vector2(p.X, p.Y), GetSourceRectangle(hex.TextureId, hex.Width, hex.Height), Color.White);

                if (Debug.DebugText)
                {
                    int x = p.X + 28;
                    int y = p.Y + 35 + hex.OffsetY;
                    string text = hex.Q + "," + hex.R + "," + hex.S;
                    spriteBatch.DrawString(Debug.DebugFont, text, new Vector2(x, y), Color.White);
                }
            }
            /*
            for (int q = minQ; q < maxQ; q++)
            {
                for (int r = minR; r < maxR; r++)
                {
                    for (int s = minS; s < maxS; s++)
                    {
                        HexTile h = GetHexTile(q, r, s);
                        if (h == null)
                            continue;
                        Point p = h.ScreenPos();
                        int id = h.TextureId;
                        spriteBatch.Draw(tilesetTexture, new Vector2(p.X, p.Y), GetSourceRectangle(id, h.Width, h.Height), Color.White);
                    }
                }
            }
            */

            /*

            for (int q = 0; q < layerWidth; q++)
            {
                int qOffset = q >> 1;
                for (int r = -qOffset; r < layerHeight - qOffset; r++)
                {
                    int s = -q - r;
                    HexTile h = GetHexTile(q, r, s);
                    Point p = h.ScreenPos();
                    int id = h.TextureId;
                    spriteBatch.Draw(tilesetTexture, new Vector2(p.X, p.Y), GetSourceRectangle(id, h.Width, h.Height), Color.White);                    
                }
            }
            */
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
