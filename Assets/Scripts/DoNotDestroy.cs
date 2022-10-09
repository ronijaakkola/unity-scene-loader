using UnityEngine;

namespace SceneLoader
{
    public class DoNotDestroy : MonoBehaviour
    {    
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
