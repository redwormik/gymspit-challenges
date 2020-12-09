using System;


namespace OopChallenge
{
	class Triangle: Shape
	{
		public double Transform { get; }


		public Transform(Transform transform = new Transform())
		{
			this.Transform = transform;
		}
	}
}
