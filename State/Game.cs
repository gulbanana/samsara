namespace Samsara.State;

public class Game
{
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Alive { get; set; }
    public TimeSpan LifeSpan { get; set; }
    public int Karma { get; set; }
    public int Rebirths { get; set; } = -1;
    public int Eggs { get; set; }

    public void Tick(TimeSpan elapsed)
    {
        if (Alive)
        {
            LifeSpan -= elapsed;

            if (LifeSpan <= TimeSpan.Zero)
            {
                Alive = false;
            }
        }
    }

    public void DoLive()
    {
        Rebirths++;
        Alive = true;
        LifeSpan = TimeSpan.FromSeconds(20);
    }

    public void DoMate()
    {
        Karma++;
        Eggs += Random.Shared.Next(500, 3000);
    }

    public void DoDie()
    {
        Alive = false;
        LifeSpan = TimeSpan.Zero;
        Eggs = 0;
    }
}