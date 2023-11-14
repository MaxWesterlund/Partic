using Raylib_cs;
using GS = GameSettings;

public static class ParticleManager {
    public static readonly List<Particle> Particles = new();
    public static readonly bool[,] OccupationMap = new bool[GS.GameSize, GS.GameSize];

    static float nextSpawnTime = 0;
    static Random random = new();

    public static void UpdateParticles() {
        float curTime = (float)Raylib.GetTime();
        if (curTime > nextSpawnTime) {
            nextSpawnTime = curTime + 0.3f;
            Particles.Add(new Particle(random.Next(GS.GameSize), random.Next(GS.GameSize)));
        }
        Shuffle(Particles);
        foreach (Particle particle in Particles) {
            particle.Move();
        }
    }

    static void Shuffle<T>(IList<T> list) {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
}