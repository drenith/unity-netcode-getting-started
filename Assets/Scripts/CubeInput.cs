using Unity.NetCode;

public struct CubeInput : ICommandData
{
    public uint Tick {get; set;}
    public int horizontal;
    public int vertical;

    public int up;

    public bool reset;
}
