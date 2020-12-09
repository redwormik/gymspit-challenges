using System;


namespace OopChallenge
{
	class Vector: IEquatable<Vector>
	{
		public double X { get; }

		public double Y { get; }


		public Vector(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}


		public Vector Add(Vector a)
		{
			return new Vector(this.X + a.X, this.Y + a.Y);
		}


		public Vector Scale(double a)
		{
			return new Vector(this.X * a, this.Y * a);
		}


		public Vector Scale(Vector a)
		{
			return new Vector(this.X * a.X, this.Y * a.Y);
		}


		public Vector Rotate(double a)
		{
			return new Vector(this.X * Math.Cos(a) + this.Y * Math.Sin(a), this.Y * Math.Cos(a) - this.X * Math.Sin(a));
		}


		public bool Equals(Vector other)
		{
			if (other == null) {
				return false;
			}

			return this.X == other.X && this.Y == other.Y;
		}


		public override bool Equals(Object other)
		{
			return Equals(other as Vector);
		}


		public override int GetHashCode() {
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}


		public override string ToString()
		{
			return $"({this.X}, {this.Y})";
		}


		public static Vector operator +(Vector a)
		{
			return a;
		}


		public static Vector operator -(Vector a)
		{
			return a.Scale(-1.0);
		}


		public static Vector operator +(Vector a, Vector b)
		{
			return a.Add(b);
		}


		public static Vector operator -(Vector a, Vector b)
		{
			return a.Add(-b);
		}


		public static Vector operator *(double a, Vector b)
		{
			return b.Scale(a);
		}


		public static Vector operator *(Vector a, double b)
		{
			return a.Scale(b);
		}


		public static Vector operator /(Vector a, double b)
		{
			return a.Scale(1.0 / b);
		}


		public static bool operator ==(Vector a, Vector b)
		{
			if ((object) a == null || (object) b == null) {
				return Object.Equals(a, b);
			}

			return a.Equals(b);
		}


		public static bool operator !=(Vector a, Vector b)
		{
			if ((object) a == null || (object) b == null) {
				return !Object.Equals(a, b);
			}

			return !a.Equals(b);
		}
	}
}
