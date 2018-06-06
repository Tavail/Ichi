using UnityEngine;

namespace Assets.Scripts
{
    public class MyUnitySingleton : MonoBehaviour
    {
        private static MyUnitySingleton instanceMusic = null;
        private static MyUnitySingleton instanceSfx = null;
        public MyUnitySingleton InstanceMusic
        {
            get
            {
                return instanceMusic;
            }
        }
        public MyUnitySingleton InstanceSfx
        {
            get
            {
                return instanceSfx;
            }
        }

        private void Awake()
        {
            if (instanceMusic != null && instanceMusic != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else if (this.name.Contains("Music"))
            {
                instanceMusic = this;
            }
            else if (this.name.Contains("SFX"))
            {
                instanceSfx = this;
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
