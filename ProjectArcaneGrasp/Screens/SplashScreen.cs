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
        float fadeTime = 1f;
        int currentSplash = 0;
        float transitionTimer = 0;
        float transitionTime = 1f;
        bool transition = false;

        Texture2D transitionTexture;

        [XmlElement("BackgroundPaths")]
        public List<string> splashTexturePaths;
        List<Texture2D> splashTextures = new List<Texture2D>();

        public SplashScreen()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();

            transitionTexture = content.Load<Texture2D>("Textures/Particles/BlackPixel");

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
            if (!transition)
            {
                fadeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (fadeTimer >= fadeTime)
                {
                    fadeTimer = 0;
                    if (currentSplash < splashTextures.Count - 1)
                    {
                        transition = true;
                        transitionTimer = transitionTime;
                        currentSplash++;
                    }
                    else
                    {
                        Debug.Log("Next Screen!");
                        ScreenManager.Instance.NextScreen();
                    }
                }
            }
            else
            {
                transitionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (transitionTimer <= 0)
                {
                    transitionTimer = 0;
                    transition = false;
                    
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            spriteBatch.Draw(splashTextures[currentSplash], Vector2.Zero, Color.White);

            if (transition)
                spriteBatch.Draw(transitionTexture,
                    new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y),
                    new Color(Color.White, transitionTimer / transitionTime));
        }
    }
}
