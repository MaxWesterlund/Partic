using System.Numerics;
using Raylib_cs;
using GS = GameSettings;
using PM = ParticleManager;

public class Particle {
    public Vector2 Position = new();
    Vector2 velocity = new();

    public Particle() { }

    public Particle(int x, int y) {
        Position.X = x;
        Position.Y = y;
    }

    public void Move() {
        ApplyGravity();
        PM.OccupationMap[(int)Position.X, (int)Position.Y] = false;

        int distance = (int)Vector2.Distance(Position, Position + velocity);
        for (int i = distance; i > -1; i--) {
            Vector2 nextPos = Position + velocity - Vector2.Normalize(velocity) * i;
            bool canMove = true;
            if ((int)nextPos.X < 0) {
                nextPos.X = 0;
                velocity.X = 0;
                canMove = false;
            }
            if ((int)nextPos.X > GS.GameSize - 1) {
                nextPos.X = GS.GameSize - 1;
                velocity.X = 0;
                canMove = false;
            }
            if ((int)nextPos.Y < 0) {
                nextPos.Y = 0;
                velocity.Y = 0;
                canMove = false;
            }
            if ((int)nextPos.Y > GS.GameSize - 1) {
                nextPos.Y = GS.GameSize - 1;
                velocity.Y = 0;
                canMove = false;
            }
            if (PM.OccupationMap[(int)nextPos.X, (int)nextPos.Y]) {
                velocity *= GS.GravityDirection;
                canMove = false;
            }

            if (canMove) {
                Position = nextPos;
                break;
            }
        }

        PM.OccupationMap[(int)Position.X, (int)Position.Y] = true;
    }

    void ApplyGravity() {
        velocity += GS.GravityConst * Raylib.GetFrameTime() * GS.GravityDirection;
    }
}