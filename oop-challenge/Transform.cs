using System;


namespace OopChallenge
{
	class Transform: IEquatable<Transform>
	{
		public Vector Scale { get; }

		public double Rotation { get; }

		public Vector Translation { get; }


		public Transform(Vector scale = new Vector(1.0, 1.0), double rotation = 0.0, Vector translation = new Vector(0.0, 0.0))
		{
			this.Scale = scale;
			this.Rotation = rotation % (2 * Math.PI) + (rotation < 0 ? 2 * Math.PI : 0);
			this.Translation = translation;
		}


		public Vector Apply(Vector a)
		{
			return a.Scale(Scale).Rotate(Rotation).Add(Translation);
		}


		public bool Equals(Transform other)
		{
			if (other == null) {
				return false;
			}

			return this.Scale == other.Scale && this.Rotation == other.Rotation && this.Translation == other.Translation;
		}


		public override bool Equals(Object other)
		{
			return Equals(other as Transform);
		}


		public override int GetHashCode() {
			return this.Scale.GetHashCode() ^ this.Rotation.GetHashCode() ^ this.Translation.GetHashCode();
		}


		public override string ToString()
		{
			return $"Transform({this.Scale.X},{this.Scale.Y}; {this.Rotation}; {this.Translation.X},{this.Translation.Y})";
		}


		public static bool operator ==(Transform a, Transform b)
		{
			if ((object) a == null || (object) b == null) {
				return Object.Equals(a, b);
			}

			return a.Equals(b);
		}


		public static bool operator !=(Transform a, Transform b)
		{
			if ((object) a == null || (object) b == null) {
				return !Object.Equals(a, b);
			}

			return !a.Equals(b);
		}
	}
}
