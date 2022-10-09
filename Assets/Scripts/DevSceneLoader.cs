using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoader {
    public class DevSceneLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneInfo sceneInfo;
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(sceneInfo.sceneName);
        }
    }          
}

