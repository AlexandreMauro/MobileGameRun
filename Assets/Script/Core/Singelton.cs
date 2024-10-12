using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Singelton
{
    public class Singelton<T> : MonoBehaviour where T : MonoBehaviour

    {
        public static T Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
            }
            else
            {
                Destroy(gameObject);
            }


        }


    }
}
