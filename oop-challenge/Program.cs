using System;


namespace OopChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			// LineRenderer lineRenderer = new DebugLineRenderer();
			// CircleRenderer circleRenderer = new DebugCircleRenderer();
			ConsoleColor[] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
			Console.Clear();

			Random rnd = new Random();

			for (int i = 0; i <= 20; i += 1) {
				LineRenderer lineRenderer = new ConsoleLineRenderer('*', colors[i % colors.Length]);
				Vector point1 = new Vector(rnd.NextDouble() * (Console.BufferWidth - 1), rnd.NextDouble() * (Console.BufferHeight - 1));
				Vector point2 = new Vector(rnd.NextDouble() * (Console.BufferWidth - 1), rnd.NextDouble() * (Console.BufferHeight - 1));

				lineRenderer.RenderLine(point1, point2 - point1);
			}


			Vector origin = new Vector(20.0, 20.0);
			for (int i = 0; i <= 30; i += 1) {
				CircleRenderer circleRenderer = new ConsoleCircleRenderer('*', colors[i % colors.Length]);
				Vector scale = new Vector(i / 2.0, i);
				double rotation = i * Math.PI / 12;

				Console.Clear();
				circleRenderer.RenderCircle(origin, scale, rotation);
			}

			Console.ResetColor();
			Console.SetCursorPosition(0, Console.BufferHeight - 1);
		}
	}
}
