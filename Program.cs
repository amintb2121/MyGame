using System.Numerics;
using Raylib_cs;

class Program
{
    static void Main()
    {
        // اندازه صفحه نمایش سازگار با موبایل
        Raylib.InitWindow(480, 800, "Mobile Touch Game");
        Raylib.SetTargetFPS(60);

        Vector2 ballPosition = new Vector2(240, 400);
        float ballSpeed = 6.0f;

        while (!Raylib.WindowShouldClose())
        {
            // ۱. حرکت با کیبورد (برای تست روی ویندوز)
            if (Raylib.IsKeyDown(KeyboardKey.Right)  Raylib.IsKeyDown(KeyboardKey.D)) ballPosition.X += ballSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Left)  Raylib.IsKeyDown(KeyboardKey.A)) ballPosition.X -= ballSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Up)  Raylib.IsKeyDown(KeyboardKey.W)) ballPosition.Y -= ballSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Down)  Raylib.IsKeyDown(KeyboardKey.S)) ballPosition.Y += ballSpeed;

            // ۲. حرکت با لمس صفحه (برای روی گوشی اندروید)
            if (Raylib.IsMouseButtonDown(MouseButton.Left) || Raylib.GetTouchPointCount() > 0)
            {
                // گرفتن مختصات محل لمس انگشت یا موس
                Vector2 touchPos = Raylib.GetMousePosition();
                if (Raylib.GetTouchPointCount() > 0)
                {
                    touchPos = Raylib.GetTouchPosition(0);
                }
                
                // حرکت نرم توپ به سمت محل لمس شده
                ballPosition = Vector2.Lerp(ballPosition, touchPos, 0.1f);
            }

            // محدود کردن توپ درون کادر صفحه
            if (ballPosition.X < 35) ballPosition.X = 35;
            if (ballPosition.X > 445) ballPosition.X = 445;
            if (ballPosition.Y < 35) ballPosition.Y = 35;
            if (ballPosition.Y > 765) ballPosition.Y = 765;

            // رسم گرافیک
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            Raylib.DrawText("صفحه را لمس کنید یا با کلیدها حرکت دهید", 20, 40, 16, Color.DarkGray);
            Raylib.DrawCircleV(ballPosition, 35, Color.Red);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}