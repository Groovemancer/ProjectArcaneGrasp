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
    public class SplashScreen : GameScreen
    {
        float fadeTimer;
        float fadeTime = 3f;
        int currentSplash = 0;

        [XmlElement("BackgroundPaths")]
        public List<string> splashTexturePaths;
        List<Texture2D> splashTextures = new List<Texture2D>();

        public SplashScreen()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();

            foreach (string path in splashTexturePaths)
            {
                splashTextures.Add(content.Load<Texture2D>(path));
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            fadeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (fadeTimer >= fadeTime)
            {
                fadeTimer = 0;
                if (currentSplash < splashTextures.Count - 1)
                    currentSplash++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(splashTextures[currentSplash], Vector2.Zero, Color.White);
        }
    }
}
