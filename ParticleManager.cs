using GS = GameSettings;
using PS = ParticleSettings;

public static class ParticleManager {
    public static readonly List<Particle> Particles = new();

    public static void InitParticles() {
        Random random = new Random();
        for (int i = 0; i < PS.StartAmount; i++) {
            Particles.Add(new Particle(random.Next(GS.WindowWidth), random.Next(GS.WindowHeight)));
        }
    }

    public static void MoveParticles() {

    }
}