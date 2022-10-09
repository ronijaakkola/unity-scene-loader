using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SceneLoader
{
    public class SceneLoaderWindow : EditorWindow
    {
        [SerializeField]
        SceneInfo targetSceneInfo;

        SceneAsset targetScene;

        SceneAsset managerScene;

        static string editModeScene;

        [MenuItem("Window/Testing/Scene Loader")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(SceneLoaderWindow));
        }

        void OnEnable()
        {
            EditorApplication.playModeStateChanged += _OnPlayModeStateChanged;
        }

        void OnGUI()
        {
            _GUIHandler();
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }

        void _GUIHandler()
        {
            titleContent.text = "Scene Loader";
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            _PlayHandler();
            EditorGUI.EndDisabledGroup();
        }

        static void _OnPlayModeStateChanged(PlayModeStateChange state)
        {
            var shouldResetSceneInEditMode = (state == PlayModeStateChange.EnteredEditMode);

            if (shouldResetSceneInEditMode) {
                EditorSceneManager.playModeStartScene = (SceneAsset)AssetDatabase.LoadAssetAtPath(editModeScene, typeof(SceneAsset));
            }
        }

        void _PlayHandler()
        {
            GUILayout.Label("Play", EditorStyles.boldLabel);

            managerScene = (SceneAsset)EditorGUILayout.ObjectField(
                    new GUIContent("Manager scene:"),
                    managerScene,
                    typeof(SceneAsset),
                    false);

            targetScene = (SceneAsset)EditorGUILayout.ObjectField(
                    new GUIContent("Target scene:"),
                    targetScene,
                    typeof(SceneAsset),
                    false);

            if (GUILayout.Button("Load scene", GUILayout.Height(20)))
            {
                if (!EditorApplication.isPlayingOrWillChangePlaymode) {
                    if (targetScene != null && managerScene != null && targetSceneInfo != null) {
                        editModeScene = EditorSceneManager.GetActiveScene().path;
                        EditorSceneManager.playModeStartScene = managerScene;
                        targetSceneInfo.sceneName = targetScene.name;
                        EditorApplication.isPlaying = true;
                    }
                    else {
                        if (managerScene == null)
                            EditorUtility.DisplayDialog("Error", "No manager scene selected.", "OK");
                        else if (targetScene == null)
                            EditorUtility.DisplayDialog("Error", "No target scene selected.", "OK");
                        else
                            EditorUtility.DisplayDialog("Error", "No SceneInfo reference found. You can do this in the SceneLoader script inspector view.", "OK");
                    }
                }
            }
        }
    }
}
