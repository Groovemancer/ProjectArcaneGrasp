using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectArcaneGrasp
{
    public class GameplayScreen : GameScreen
    {
        /*
        TileMap myMap = new TileMap();
        int squaresAcross = 10;
        int squaresDown = 24;
        int baseOffsetX = -26;
        int baseOffsetY = -68;
        */
        HexTileMapLayer layer;

        public GameplayScreen()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            Texture2D tileset = content.Load<Texture2D>("Textures/TileSets/HexTiles2");
            layer = new HexTileMapLayer(tileset, 10, 10);
            layer.PrintLayer();
            layer.PrintScreenLayer();
            layer.PrintHashCodes();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            /*

            KeyboardState ks = Keyboard.GetState();
            int cameraSpeed = 5;
            if (ks.IsKeyDown(Keys.Left))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - cameraSpeed, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + cameraSpeed, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - cameraSpeed, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + cameraSpeed, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }
            */
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
            base.Draw(spriteBatch);

            layer.Draw(spriteBatch);

            /*

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            
            for (int y = 0; y < squaresDown; y++)
            {
                int rowOffset = 0;
                if ((firstY + y) % 2 == 1)
                    rowOffset = Tile.OddRowXOffset;
                
                for (int x = 0; x < squaresAcross; x++)
                {                    
                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles)
                    {
                        spriteBatch.Draw(
                            Tile.TilesetTexture,
                            new Rectangle(
                                (x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,
                                (y * Tile.TileStepY) - offsetY + baseOffsetY,
                                Tile.TileWidth, Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White);
                    }
                }
            }
            */
        }
    }
}
