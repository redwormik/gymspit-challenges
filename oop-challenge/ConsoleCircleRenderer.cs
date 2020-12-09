using System;


namespace OopChallenge
{
	class ConsoleCircleRenderer: CircleRenderer
	{
		private readonly char character;

		private readonly ConsoleColor color;


		public ConsoleCircleRenderer(char character = '*', ConsoleColor color = ConsoleColor.White)
		{
			this.character = character;
			this.color = color;
		}


		public void RenderCircle(Vector origin, Vector scale, double rotation)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = color;

			double maxSize = Math.Max(scale.X, scale.Y);

			int minX = Math.Max(0, (int) Math.Ceiling(origin.X - maxSize));
			int maxX = Math.Min((int) Math.Floor(origin.X + maxSize), Console.BufferWidth - 1);

			int minY = Math.Max(0, (int) Math.Ceiling(origin.Y - maxSize));
			int maxY = Math.Min((int) Math.Floor(origin.Y + maxSize), Console.BufferHeight - 1);

			for (int y = minY; y <= maxY; y += 1) {
				for (int x = minX; x <= maxX; x += 1) {
					double value = CircleEquation(x, y, origin, scale, rotation);

					if (value > 1.0) {
						continue;
					}

					double topValue = CircleEquation(x, y - 1, origin, scale, rotation);
					double bottomValue = CircleEquation(x, y + 1, origin, scale, rotation);
					if ((topValue > value && topValue <= 1.0) || (bottomValue > value && bottomValue <= 1.0)) {
						double leftValue = CircleEquation(x - 1, y, origin, scale, rotation);
						double rightValue = CircleEquation(x + 1, y, origin, scale, rotation);
						if ((leftValue > value && leftValue <= 1.0) || (rightValue > value && rightValue <= 1.0)) {
							continue;
						}
					}

					Console.SetCursorPosition(x, y);
					Console.Write(character);
				}
			}

			Console.ForegroundColor = oldColor;
		}


		private static double CircleEquation(int consoleX, int consoleY, Vector origin, Vector scale, double rotation)
		{
			Vector normalized = (new Vector(consoleX, consoleY)).Add(-origin).Rotate(-rotation);
			double x = normalized.X / scale.X;
			double y = normalized.Y / scale.Y;

			return x * x + y * y;
		}
	}
}
