namespace QuantumMC.Blocks
{
    public class BlockEndCrystal : Block
    {
        public static int ID { get; internal set; }
        public override int RuntimeId => ID;

        public BlockEndCrystal() : base("minecraft:end_crystal") { }
    }
}
