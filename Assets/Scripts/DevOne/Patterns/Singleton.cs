using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevOne.Patterns
{

    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this.gameObject.GetComponent<T>();
                DontDestroyOnLoad(this.gameObject);
                InitInAwake();
            }
            else if (Instance != this.gameObject.GetComponent<T>())
            {
                Destroy(this.gameObject);
            }
        }

        public abstract void InitInAwake();

    }
}
