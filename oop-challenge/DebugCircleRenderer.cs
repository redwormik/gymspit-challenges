using System;


namespace OopChallenge
{
	class DebugCircleRenderer: CircleRenderer
	{
		public void RenderCircle(Vector origin, Vector scale, double rotation)
		{
			Console.WriteLine("Rendering circle from {0} scaled by {1}, rotated by {2}", origin, scale, rotation);
		}
	}
}
