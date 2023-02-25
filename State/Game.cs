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
    public IReadOnlyList<Act> LifeActions { get; set; }
    public IReadOnlyList<Res> LifeResources { get; set; }

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
            LifeText = new(@"You are a mayfly, <span class=""trait"">brief</span> and <span class=""trait"">desperate</span>.");
            LifeSpan = TimeSpan.FromSeconds(20);

            var eggs = new Res("Eggs");

            LifeResources = new Res[] { eggs };

            void DoMate()
            {
                Karma++;
                eggs.Value += Random.Shared.Next(500, 3000);
            }

            LifeActions = new Act[] { new("MATE", DoMate), new("DIE", DoDie) };            
        }
        else
        {
            LifeText = new(@"You are a dog, <span class=""trait"">loyal</span> and <span class=""trait"">swift</span>.");
            LifeSpan = TimeSpan.FromSeconds(60);
            LifeActions = new Act[] { new("WORK", DoDie), new("PLAY", DoDie) };
        }

        LifeLeft = LifeSpan;

        Karma = 0;
    }

    public void DoDie()
    {
        Alive = false;
    }
}