using Raylib_cs;

namespace MyGame
{
    internal static class Program
    {
        private static void Main()
        {
            Raylib.InitWindow(800, 480, "My Android Game");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);
                Raylib.DrawText("Hello Android!", 190, 200, 40, Color.LightGray);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
