using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectArcaneGrasp
{
    public class HexTileMap
    {
        int mapWidth;
        int mapHeight;
        List<HexTileMapLayer> layers;

        public HexTileMap(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            layers = new List<HexTileMapLayer>();
        }

    }
}
