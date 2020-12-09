using System;


namespace OopChallenge
{
	class DebugLineRenderer: LineRenderer
	{
		public void RenderLine(Vector origin, Vector scale)
		{
			Console.WriteLine("Rendering line from {0} to {1}", origin, origin + scale);
		}
	}
}
