namespace QuantumMC.API.World
{
    public interface IWorld
    {
        string Name { get; }
        string Dimension { get; }   // "overworld" | "nether" | "end"
        int PlayerCount { get; }
    }
}
