using System.Numerics;

public static class GameSettings {
    public static int WindowSize = 800;
    public static int GameScale = 4;
    public static int GameSize = WindowSize / GameScale;

    public static Vector2 GravityDirection = new Vector2(0, 1);
    public static float GravityConst = 0.982f;
}