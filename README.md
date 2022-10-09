<h1 align="center">Unity Scene Loader</h1>

<div align="center">
  <strong>A simple Unity editor extension to load two scenes after each other</strong>
</div>

<p align="center">
  <img src="https://user-images.githubusercontent.com/4214671/194774447-08756ac8-2434-487f-a85d-2e92cb0c1619.png" alt="Image showing a custom Unity editor window for loading scenes" width="335">
</p>

### What?
Unity Scene Loader is a very simple Unity editor extension that allows you to load any two scenes in order.

### Why?
This is useful when you have objects that need to be present in all scenes (e.g. a game manager script). This is most often solved by adding all of these objects to the first scene of the game and calling `DontDestroyOnLoad` for them. This way the objects will stay in scene even between scene loads. However, if your game has a lot of scenes and during development you want to be able to start Play mode in any scene, you run into trouble.

Unity does not offer any clean solution to this and this is why the Unity Scene Loader was implemented. It allows you to gather all of your necessary objects into one "Manager" scene and then load that scene in front of any scene you like! Now you can start the Play mode in that Level 38 with no issues.

### How?
This solution uses an editor script to create window where you can select two scenes to be loaded in order. The script uses a scriptable object to relay the target scene information to another script in the manager scene. This way the manager scene knows which scene should be eventually loaded after managers, controllers etc. have been initialized in the scene.

### Setting up
Please follow these instructions to get this extension working:
1. Clone this repository and copy its contents to your project (or download the .unitypackage file from [Releases](https://github.com/ronijaakkola/unity-scene-loader/releases)).
2. Create a scene and gather all of your managers, controllers etc. objects into that.
3. Create an empty game object to that scene and add `DevSceneLoader` script to the object. Drag `TargetSceneInfo` scriptable object to the "Scene info" variable of the script.
4. Make sure the editor script `SceneLoaderWindow` has the same scriptable object reference set to its variable "Target Scene Info".
5. Create a window by selecting "Window/Testing/Scene Loader" and drag it where you like.
6. Select a manager scene and a target scene in the Scene Loader window.
7. Press "Load scene".

This should first load the manager scene and then immediately the target scene you selected.
