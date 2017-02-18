using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectArcaneGrasp
{
    public class HexTile
    {
        #region Properties
        public int TextureId
        {
            get;
            set;
        }

        public CubeCoord Pos
        {
            get;
            private set;
        }

        public Point ScreenPos
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public int Top
        {
            get;
            private set;
        }

        public int StepY
        {
            get;
            private set;
        }

        public int OffsetY
        {
            get;
            private set;
        }

        public int Q
        {
            get
            {
                return Pos.Q;
            }
        }

        public int R
        {
            get
            {
                return Pos.R;
            }
        }

        public int S
        {
            get
            {
                return Pos.S;
            }
        }

        #endregion
        
        public HexTile(CubeCoord cube, int textureId, int width, int height, int top, int stepY, int offsetY)
        {
            Pos = cube;
            TextureId = textureId;
            Width = width;
            Height = height;
            Top = top;
            StepY = stepY;
            OffsetY = offsetY;
            ScreenPos = CalculateScreenPos();
        }

        private Point CalculateScreenPos()
        {
            OffsetCoord oc = CubeCoord.ConvertToOffset(Pos);
            int x = (((Width - Top) / 2) + Top) * oc.X;
            int y = Height * oc.Y + (StepY * (oc.X % 2)) - OffsetY - OffsetY * oc.Y;
            return new Point(x, y);
        }

        /* OBSOLETE
         * No longer calculating every frame for every tile.
         * It's only calculated when tile is created since their position should never change
        public Point ScreenPos()
        {
            OffsetCoord oc = CubeCoord.ConvertToOffset(Pos);

            //int x = Width * 3 / 2 * oc.X;
            int x = (((Width - Top) / 2) + Top) * oc.X;
            int y = Height * oc.Y + (StepY * (oc.X % 2)) - OffsetY - OffsetY * oc.Y;
            //int y = (int)(Height * (oc.Y + 0.5 * (oc.X & 1)));

            return new Point(x, y);
        }
        */
    }
}
