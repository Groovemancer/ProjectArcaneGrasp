using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ProjectArcaneGrasp
{
    public class Hex
    {
        /*
        q = q
        r = r
        s = -q-r

        q = q
        r = -s-q
        s = s

        q = -s-r
        r = r
        s = s
        */
        public int Q, R, S;

        public static readonly List<Hex> Directions = new List<Hex>()
        {
            new Hex(1, 0, -1), new Hex(1, -1, 0), new Hex(0, -1, 1),
            new Hex(-1, 0, 1), new Hex(-1, 1, 0), new Hex(0, 1, -1)
        };

        public Hex(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
            Debug.Assert(q + r + s == 0, "Invalid Hex Coordinates");
        }

        public static bool operator == (Hex a, Hex b)
        {
            return (a.Q == b.Q) && (a.R == b.R) && (a.S == b.S);
        }

        public static bool operator !=(Hex a, Hex b)
        {
            return !(a == b);
        }

        public static Hex operator + (Hex a, Hex b)
        {
            return new Hex(a.Q + b.Q, a.R + b.R, a.S + b.S);
        }

        public static Hex operator - (Hex a, Hex b)
        {
            return new Hex(a.Q - b.Q, a.R - b.R, a.S - b.S);
        }

        public static Hex operator * (Hex a, Hex b)
        {
            return new Hex(a.Q * b.Q, a.R * b.R, a.S * b.S);
        }

        public static int Length(Hex hex)
        {
            return (Math.Abs(hex.Q) + Math.Abs(hex.R) + Math.Abs(hex.S)) / 2;
        }

        public static int Distance(Hex a, Hex b)
        {
            return Length(a - b);
        }

        public static Hex Direction(int direction /* 0 to 5 */)
        {
            Debug.Assert(0 <= direction && direction < 6, "Hex direction can only be 0 to 5");
            return Directions[direction];
        }

        public static Hex Neighbor(Hex hex, int direction)
        {
            return hex + Direction(direction);
        }

        public static List<Hex> Neighbors(Hex hex)
        {
            List<Hex> neighbors = new List<Hex>();
            for (int i = 0; i < 6; i++)
            {
                neighbors.Add(Neighbor(hex, i));
            }
            return neighbors;
        }

        public static Point OffsetFromHex(Hex hex)
        {
            int offset = -1;
            int col = hex.Q;
            int row = hex.R + (int)((hex.Q + offset * (hex.Q & 1)) / 2);
            return new Point(col, row);
        }

        public static Hex OffsetToHex(Point p)
        {
            int offset = -1;
            int q = p.X;
            int r = p.Y - (int)((p.X + offset * (p.X & 1)) / 2);
            int s = -q - r;
            return new Hex(q, r, s);
        }
    }
}
