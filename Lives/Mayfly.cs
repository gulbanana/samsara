using Samsara.State;

namespace Samsara;

static partial class Lives
{
    public static void Mayfly(Game state)
    {
        state.LifeText = new(@"You are a mayfly, <span class=""trait"">brief</span> and <span class=""trait"">desperate</span>.");
        state.LifeSpan = TimeSpan.FromSeconds(20);

        var eggs = new Res("Eggs");

        state.LifeResources = new Res[] { eggs };

        void DoMate()
        {
            state.Karma++;
            eggs.Value += Random.Shared.Next(500, 3000);
        }

        state.LifeActions = new Act[] { new("MATE", DoMate), new("DIE", state.DoDie) };
    }
}