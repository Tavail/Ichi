namespace Assets.Lobby.Scripts.Lobby
{
    public struct LanConnectionInfo
    {
        public string FromAddress;
        public string Data;
        
        public LanConnectionInfo(string fromAddress, string data)
        {
            FromAddress = fromAddress;
            Data = data;
        }
    }
}
