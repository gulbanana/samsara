using Samsara.State;

namespace Samsara;

static partial class Lives
{
    public static void Dog(Game state)
    {
        state.LifeText = new(@"You are a dog, <span class=""trait"">loyal</span> and <span class=""trait"">swift</span>.");
        state.LifeSpan = TimeSpan.FromSeconds(60);
        state.LifeActions = new Act[] { new("WORK", state.DoDie), new("PLAY", state.DoDie) };
    }
}