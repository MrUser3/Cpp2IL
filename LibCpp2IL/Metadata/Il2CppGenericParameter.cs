namespace LibCpp2IL.Metadata
{
    public class Il2CppGenericParameter
    {
        public int ownerIndex; /* Type or method this parameter was defined in. */
        public int nameIndex;
        public short constraintsStart;
        public short constraintsCount;
        public ushort num;
        public ushort flags;

        public string? Name => LibCpp2IlMain.TheMetadata?.GetStringFromIndex(nameIndex);
        
        public int Index { get; internal set; }
    }
}