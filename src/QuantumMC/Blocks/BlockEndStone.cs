namespace QuantumMC.Blocks
{
    public class BlockEndstone : Block
    {
        public static int ID { get; internal set; }
        public override int RuntimeId => ID;

        public BlockEndstone() : base("minecraft:endstone") { }
    }
}
