namespace TwitchChatConnect.Data
{
    [System.Serializable]
    public class TwitchUser
    {
        public string Username { get; private set; }
        public string Id { get; private set; }
        public bool IsSub { get; set; }
        public bool IsFounder { get; set; }

        private string displayName;

        public string DisplayName
        {
            get => displayName ?? Username;
            private set => displayName = value;
        }

        public TwitchUser(string username)
        {
            Username = username;
        }

        public void SetData(string id, string displayName, bool isSub)
        {
            this.displayName = displayName;
            IsSub = isSub;
            Id = id;
        }
        public void SetData(string id, string displayName, bool isSub, bool isFounder)
        {
            this.displayName = displayName;
            IsSub = isSub;
            Id = id;
            IsFounder = isFounder;

            if(isFounder)
                IsSub = true;
        }
        
        
    }
}