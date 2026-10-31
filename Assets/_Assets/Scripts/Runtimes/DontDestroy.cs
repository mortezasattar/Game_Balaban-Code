using UnityEngine;

namespace Palapal.Utilities
{
    public class DontDestroy : MonoBehaviour
    {
        private static DontDestroy _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            if (_instance == this)
                _instance = null;
        }
    }
}