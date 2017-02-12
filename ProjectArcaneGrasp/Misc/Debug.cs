using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Diag = System.Diagnostics;

namespace ProjectArcaneGrasp
{
    public class Debug
    {
        public static SpriteFont DebugFont;

        /// <summary>
        /// If true, displays debug text in-game
        /// </summary>
        public static bool DebugText = true;

        public static void Initialize()
        {

        }

        public static void LoadContent(ContentManager content)
        {
            DebugFont = content.Load<SpriteFont>("Fonts/Consolas");
        }
        
        public static void Log(string message)
        {        
            Diag.Debug.WriteLine(message);
        }

        public static void Assert(bool condition, string message = null, string detailMessage = null)
        {
            if (message != null && detailMessage == null)
                Diag.Debug.Assert(condition, message);
            else if (message != null && detailMessage != null)
                Diag.Debug.Assert(condition, message, detailMessage);
            else
                Diag.Debug.Assert(condition);
        }
    }
}
