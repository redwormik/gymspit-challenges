using System;


namespace OopChallenge
{
	class ConsoleLineRenderer: LineRenderer
	{
		private readonly char character;

		private readonly ConsoleColor color;


		public ConsoleLineRenderer(char character = '*', ConsoleColor color = ConsoleColor.White)
		{
			this.character = character;
			this.color = color;
		}


		public void RenderLine(Vector origin, Vector scale)
		{
			if (scale.X == 0.0 && scale.Y == 0.0) {
				return;
			}

			bool horizontal = Math.Abs(scale.X) >= Math.Abs(scale.Y);
			double d = horizontal ? scale.Y / scale.X : scale.X / scale.Y;

			double from = horizontal ? origin.X : origin.Y;
			double to = horizontal ? origin.X + scale.X : origin.Y + scale.Y;
			int min = (int) Math.Round(Math.Min(from, to));
			int max = (int) Math.Round(Math.Max(from, to));

			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = color;

			for (int i = min; i <= max; i += 1) {
				int x = horizontal ? i : (int) Math.Round(origin.X + (i - origin.Y) * d);
				int y = horizontal ? (int) Math.Round(origin.Y + (i - origin.X) * d) : i;

				if (x < 0 || x >= Console.BufferWidth || y < 0 || y >= Console.BufferWidth) {
					continue;
				}

				Console.SetCursorPosition(x, y);
				Console.Write(character);
			}

			Console.ForegroundColor = oldColor;
		}
	}
}
