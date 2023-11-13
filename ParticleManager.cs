using GS = GameSettings;

public static class ParticleManager {
    public static readonly List<Particle> Particles = new();
    public static readonly bool[,] OccupationMap = new bool[GS.GameSize, GS.GameSize];

    public static void InitParticles() {
        Random random = new Random();
        for (int i = 0; i < 10; i++) {
            Particles.Add(new Particle(random.Next(GS.GameSize), random.Next(GS.GameSize)));
        }
    }

    public static void UpdateParticles() {
        Shuffle(Particles);
        foreach (Particle particle in Particles) {
            particle.Move();
        }
    }

    static Random random = new Random();  
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