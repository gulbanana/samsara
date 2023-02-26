using Microsoft.AspNetCore.Components;

namespace Samsara.State;

public class Game
{
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Alive { get; set; }
    public int Karma { get; set; }
    public int Rebirths { get; set; } = -1;
    public TimeSpan LifeSpan { get; set; }
    public TimeSpan LifeLeft { get; set; }
    public MarkupString LifeText { get; set; }
    public IReadOnlyList<Act> LifeActions { get; set; } = Array.Empty<Act>();
    public IReadOnlyList<Res> LifeResources { get; set; } = Array.Empty<Res>();

    public void Tick(TimeSpan elapsed)
    {
        if (Alive)
        {
            LifeLeft -= elapsed;

            if (LifeLeft <= TimeSpan.Zero)
            {
                Alive = false;
            }
        }
    }

    public void DoLive()
    {
        Rebirths++;
        Alive = true;

        if (Karma == 0)
        {
            Lives.Mayfly(this);            
        }
        else
        {
            Lives.Dog(this);
        }

        LifeLeft = LifeSpan;

        Karma = 0;
    }

    public void DoDie()
    {
        Alive = false;
    }
}