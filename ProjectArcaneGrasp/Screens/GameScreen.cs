using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectArcaneGrasp
{
    public class GameScreen
    {        
        protected ContentManager content;
        
        public string backgroundTexturePath;
        protected Texture2D backgroundTexture;

        public GameScreen()
        {
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");
            if (!String.IsNullOrEmpty(backgroundTexturePath))
                backgroundTexture = content.Load<Texture2D>(backgroundTexturePath);
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (backgroundTexture != null)
                spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
        }
    }
}
