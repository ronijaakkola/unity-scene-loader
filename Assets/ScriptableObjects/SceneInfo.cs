using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneLoader {
    [CreateAssetMenu(fileName = "SceneInfo", menuName = "Testing/Scene to test", order = 0)]
    public class SceneInfo : ScriptableObject 
    {
        public string sceneName = "Game";
    }
}

