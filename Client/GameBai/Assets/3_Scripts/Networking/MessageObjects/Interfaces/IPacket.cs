namespace Assets.Scripts.Networking.MessageObjects.Interfaces
{
    public interface IPacket
    {
        int id { get; }
        int type { get; }
        int resultCode { get; set; }
        string debugMessage { get; set; }
        string Build();
    }
}
