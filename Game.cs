using Raylib_cs;
using GS = GameSettings;

static class Game {
    public static void Loop() {
        ParticleManager.InitParticles();

        Raylib.InitWindow(GS.WindowWidth, GS.WindowHeight, "Partic");
        while (!Raylib.WindowShouldClose()) {
            Draw();
        }
        Raylib.CloseWindow();
    }

    static void Draw() {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(new Color(0, 0, 0, 255));

        DrawParticles();

        Raylib.EndDrawing();
    }

    static void DrawParticles() {

    }
}