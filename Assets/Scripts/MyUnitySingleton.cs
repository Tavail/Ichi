using UnityEngine;

namespace Assets.Scripts
{
    public class MyUnitySingleton : MonoBehaviour
    {
        private static MyUnitySingleton instance = null;
        public static MyUnitySingleton Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
