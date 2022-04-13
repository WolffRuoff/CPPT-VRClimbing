# CPPT-VRClimbing

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
