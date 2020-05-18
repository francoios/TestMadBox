
namespace MadBoxTest
{
    public class MenuManager : MadBoxMonobehaviour
    {

        #region Singleton

        private static MenuManager _instance;

        public static MenuManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(transform.gameObject);
                return;
            }

            DontDestroyOnLoad(transform.gameObject);
        }

        #endregion


        public override void Start()
        {
            base.Start();
        }

        public void SendPlayerScore()
        {
            
        }

        public void GetPlayersScores()
        {
            
        }

        public void TestConnectivity()
        {
            
        }

        public void ReturnToMenu()
        {
            
        }
        
        public void GoToPlayerScoresBoard()
        {
            
        }
        
    }
}