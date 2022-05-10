# CPPT-VRClimbing
Created by Ethan Ruoff (er3074), Namratha Prithviraj (np2788), and Arnavi Chheda (amc2476)  <br/>
Video URL: https://youtu.be/lWTj3D2fHIQ <br/>
Date of Submission: _______ <br/>

## Development Platforms: 
- Unity 2020.3.33f1
- Oculus Integration Package v38.0
- OpenXR 1.3.1
- Terrain Tools 3.0.2-Preview.3

## Compatible Devices:
- Oculus Quest v39
- Oculus Quest 2 v39

## Directory Overview
### Assets
- ADG_Textures: Contains the textures for the terrain
- GeneratedAnimations: Animations for different hand poses
- HandGrabInteractableDataCollection: Metadata of the hand poses for the knobs
- LIV: The LIV package that allows AR functionality
- Materials: Materials, textures and shaders
- Models: 3D models for the wall and knobs
- Oculus: The Oculus Interaction SDK Package
- Plugins: Contains the AndroidManifest for building the app
- Prefabs: Contains all of our prefabs
- ProBuilder Data: Contains the assets used by the ProBuilder plugin
- QuickOutline: Contains the assets used by the QuickOutline plugin
- Resources: Contains settings
- Scenes:
    - ____________
- Scripts: Contains all of the scripts we wrote to control different functions in the game
- Sounds: Contains any sound effects we use
- TextMesh Pro: Contains the assets TextMeshPro uses
- XR: Contains functionality for XR gameplay

## Scene Overview

### StartMenuScene

### MainGameScene

## Instructions for setting up the project
1. Install the Unity editor 2020.3.33f1
2. Add this repo as a project in the Unity Hub
3. Go to the package manager or asset store and import the newest version of the Oculus Integration Package (v38.0)
4. Go to build settings, click on Android, and click "Switch Platforms"
5. Enter "Player Settings" and navigate to the "XR Plug-in Management" tab
6. Under the Android tab make sure that only Oculus is checked. Under the PC tab make sure only OpenXR is checked
    - If there is a warning symbol next to the checked OpenXR, click on it and click fix on the warning about Gameview
    - If there is another warning for missing interaction profiles, click on the OpenXR tab on the left and add the "Oculus Touch Controller Profile" to the "Interaction Profile" sections for both PC and Android
7. Navigate to the package manager and remove and the re-install the "OpenXR Plugin." Make sure it is reinstalled as version 1.3.1
8. Search for "OVRPlugin" in the project manager and open it in your code editor
9. Find the following lines and cut/paste them to line 38 below "public static partial class OVRPlugin": <br/>
`private const string pluginName = "OVRPlugin";` <br/>
`private static System.Version _versionZero = new System.Version(0, 0, 0);`<br/>

10. Save and exit the script
11. Navigate to the following scenes, click on the "OVRCameraRig" object, scroll down to "Quest Features," and change "Hand Tracking Support" to "Controllers and Hands"
    - Scenes that require step 8:
        - MainTestScene

## Missing Features
Our project is currently missing the custom wall creation mode and timers.
## Known Bugs

## Asset Sources
- Knobs used as handgrips: https://drive.google.com/file/d/1gwLXOBAx5IqPFIDcJJIyJSVAgR9GifKX/view
- Textures for the terrain: https://assetstore.unity.com/packages/2d/textures-materials/nature/terrain-textures-pack-free-139542#publisher
- Quick Outline: https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488#publisher
- Augmented Reality is done via the LIV SDK: https://www.liv.tv/developers
- Wind sound effect: https://opengameart.org/content/wind-whoosh-loop