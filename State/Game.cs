namespace Samsara.State;

public class Game
{
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Alive { get; set; }
    public TimeSpan? LifeSpan { get; set; }

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
        Alive = true;
        LifeSpan = TimeSpan.FromSeconds(10);
    }
}