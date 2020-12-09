using System;


namespace OopChallenge
{
	abstract class Shape
	{
		public Transform Transform { get; }


		public Transform(Transform transform = new Transform())
		{
			this.Transform = transform;
		}
	}
}
