using Raylib_cs;
using System.Numerics;
using GS = GameSettings;
using PM = ParticleManager;

static class Game {
    public static float Delta;

    public static void Loop() {
        PM.InitParticles();

        Raylib.InitWindow(GS.WindowSize, GS.WindowSize, "Partic");
        Raylib.SetTargetFPS(144);
        while (!Raylib.WindowShouldClose()) {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
                GS.GravityDirection = new Vector2(0, -1);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
                GS.GravityDirection = new Vector2(0, 1);
            }

            Delta = Raylib.GetFrameTime();
            PM.UpdateParticles();
            Draw();
        }
        Raylib.CloseWindow();
    }

    static void Draw() {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(new Color(255, 255, 255, 255));

        DrawParticles();

        Raylib.EndDrawing();
    }

    static void DrawParticles() {
        foreach (Particle particle in PM.Particles) {
            Raylib.DrawRectangle((int)particle.Position.X * GS.GameScale, (int)particle.Position.Y * GS.GameScale, GS.GameScale, GS.GameScale, new Color(0, 0, 0, 255));
        }
        Raylib.DrawFPS(10, 10);
    }
}