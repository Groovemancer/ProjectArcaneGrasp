using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArcaneGrasp
{
    public class CubeCoord
    {
        public static readonly CubeCoord[] directions =
        {
            new CubeCoord(1, -1, 0), new CubeCoord(1, 0, -1), new CubeCoord(0, 1, -1),
            new CubeCoord(-1, 1, 0), new CubeCoord(-1, 0, 1), new CubeCoord(0, -1, 1)
        };

        public int Q
        {
            get;
            private set;
        }

        public int R
        {
            get;
            private set;
        }

        public int S
        {
            get;
            private set;
        }

        public CubeCoord(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
            Debug.Assert(q + r + s == 0, "Invalid Cube Coordinates");
        }

        #region Operators

        public static bool operator ==(CubeCoord a, CubeCoord b)
        {
            return (a.Q == b.Q) && (a.R == b.R) && (a.S == b.S);
        }

        public static bool operator !=(CubeCoord a, CubeCoord b)
        {
            return !(a == b);
        }

        public static CubeCoord operator +(CubeCoord a, CubeCoord b)
        {
            return new CubeCoord(a.Q + b.Q, a.R + b.R, a.S + b.S);
        }

        public static CubeCoord operator -(CubeCoord a, CubeCoord b)
        {
            return new CubeCoord(a.Q - b.Q, a.R - b.R, a.S - b.S);
        }

        public static CubeCoord operator *(CubeCoord a, CubeCoord b)
        {
            return new CubeCoord(a.Q * b.Q, a.R * b.R, a.S * b.S);
        }
        #endregion

        public static AxialCoord ConvertToAxial(CubeCoord cube)
        {
            return new AxialCoord(cube.Q, cube.R, cube.S);
        }

        public static OffsetCoord ConvertToOffset(CubeCoord cube)
        {
            int x = cube.Q;
            int y = cube.R + (cube.Q - (cube.Q & 1)) / 2;
            return new OffsetCoord(x, y);
        }

        public static CubeCoord Neighbor(CubeCoord hex, int direction)
        {
            CubeCoord dir = directions[direction];
            return new CubeCoord(hex.Q + dir.Q, hex.R + dir.R, hex.S + dir.S);
        }

        public static int Distance(CubeCoord a, CubeCoord b)
        {
            return (Math.Abs(a.Q - b.Q) + Math.Abs(a.R - b.R) + Math.Abs(a.S - b.S)) / 2;
        }
    }

    public class AxialCoord
    {
        public static readonly AxialCoord[] directions =
        {
            new AxialCoord(1, 0), new AxialCoord(1, -1), new AxialCoord(0, -1),
            new AxialCoord(-1, 0), new AxialCoord(-1, 1), new AxialCoord(0, 1)
        };

        public int Q
        {
            get;
            private set;
        }

        public int R
        {
            get;
            private set;
        }

        public int S
        {
            get
            {
                return -Q - R;
            }
        }

        public AxialCoord(int q, int r, int s)
        {
            Q = q;
            R = r;
            Debug.Assert(q + r + S == 0, "Invalid Axial Coordinates");
        }

        public AxialCoord(int q, int r)
        {
            Q = q;
            R = r;
            Debug.Assert(q + r + S == 0, "Invalid Axial Coordinates");
        }

        #region Operators

        public static bool operator ==(AxialCoord a, AxialCoord b)
        {
            return (a.Q == b.Q) && (a.R == b.R) && (a.S == b.S);
        }

        public static bool operator !=(AxialCoord a, AxialCoord b)
        {
            return !(a == b);
        }

        public static AxialCoord operator +(AxialCoord a, AxialCoord b)
        {
            return new AxialCoord(a.Q + b.Q, a.R + b.R, a.S + b.S);
        }

        public static AxialCoord operator -(AxialCoord a, AxialCoord b)
        {
            return new AxialCoord(a.Q - b.Q, a.R - b.R, a.S - b.S);
        }

        public static AxialCoord operator *(AxialCoord a, AxialCoord b)
        {
            return new AxialCoord(a.Q * b.Q, a.R * b.R, a.S * b.S);
        }
        #endregion

        public static CubeCoord ConvertToCube(AxialCoord axial)
        {
            return new CubeCoord(axial.Q, axial.R, axial.S);
        }

        public static OffsetCoord ConvertToOffset(AxialCoord axial)
        {
            int x = axial.Q;
            int y = axial.R + (axial.Q - (axial.Q & 1)) / 2;
            return new OffsetCoord(x, y);
        }

        public static AxialCoord Neighbor(AxialCoord hex, int direction)
        {
            AxialCoord dir = directions[direction];
            return new AxialCoord(hex.Q + dir.Q, hex.R + dir.R);
        }

        public static int Distance(AxialCoord a, AxialCoord b)
        {
            CubeCoord ac = ConvertToCube(a);
            CubeCoord bc = ConvertToCube(b);
            return CubeCoord.Distance(ac, bc);
        }
    }

    public class OffsetCoord
    {
        public static readonly OffsetCoord[,] directions =
        {
            {
                new OffsetCoord(1, 0), new OffsetCoord(1, -1), new OffsetCoord(0, -1),
                new OffsetCoord(-1, -1), new OffsetCoord(-1, 0), new OffsetCoord(0, 1)
            },
            {
                new OffsetCoord(1, 0), new OffsetCoord(1, -1), new OffsetCoord(0, -1),
                new OffsetCoord(-1, -1), new OffsetCoord(-1, 0), new OffsetCoord(0, 1)
            }
        };

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public OffsetCoord(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region Operators
        public static bool operator ==(OffsetCoord a, OffsetCoord b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }

        public static bool operator !=(OffsetCoord a, OffsetCoord b)
        {
            return !(a == b);
        }

        public static OffsetCoord operator +(OffsetCoord a, OffsetCoord b)
        {
            return new OffsetCoord(a.X + b.X, a.Y + b.Y);
        }

        public static OffsetCoord operator -(OffsetCoord a, OffsetCoord b)
        {
            return new OffsetCoord(a.X - b.X, a.Y - b.Y);
        }

        public static OffsetCoord operator *(OffsetCoord a, OffsetCoord b)
        {
            return new OffsetCoord(a.X * b.X, a.Y * b.Y);
        }
        #endregion

        public static CubeCoord ConvertToCube(OffsetCoord offset)
        {
            int q = offset.X;
            int r = offset.Y - (offset.X - (offset.X & 1)) / 2;
            int s = -q - r;
            return new CubeCoord(q, r, s);
        }

        public static AxialCoord ConvertToAxial(OffsetCoord offset)
        {
            int q = offset.X;
            int r = offset.Y - (offset.X - (offset.X & 1)) / 2;
            int s = -q - r;
            return new AxialCoord(q, r, s);
        }

        public static OffsetCoord Neighbor(OffsetCoord hex, int direction)
        {
            int parity = hex.X & 1;
            OffsetCoord dir = directions[parity, direction];
            return new OffsetCoord(hex.X + dir.X, hex.Y + dir.Y);
        }

        public static int Distance(OffsetCoord a, OffsetCoord b)
        {
            CubeCoord ac = ConvertToCube(a);
            CubeCoord bc = ConvertToCube(b);
            return CubeCoord.Distance(ac, bc);
        }
    }
}
