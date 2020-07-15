namespace RobotGame.Shared
{
    public partial class ResourceManager
    {
        public static ResourceManager Instance { get; } = new ResourceManager();


        #region ResourceManager
        public int Wood { get; set; }
        public int Iron { get; set; }
        public int Scrap { get; set; }
        #endregion


    }
}

