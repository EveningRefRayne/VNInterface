using UnityEditor;
using UnityEngine;

public class VNMakerTool : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    Vector2 scroll;
    public GameObject source;

    public string[] dropDownList = new string[] { "Cube", "Sphere", "Plane" };
    public int dropDownIndex = 0;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/VNTool")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(VNMakerTool));
    }

    void OnGUI()
    {
        scroll = EditorGUILayout.BeginScrollView(scroll);
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        /*groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();*/
        source = (GameObject)EditorGUILayout.ObjectField("Character 1", source, typeof(GameObject),true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("ConversationText");
        EditorGUILayout.TextArea("",GUILayout.MaxHeight(500),GUILayout.MinHeight(100));
        Rect cont = EditorGUILayout.BeginHorizontal();
        Rect p1 = EditorGUILayout.BeginVertical("Button",GUILayout.Width(100));
        if (GUI.Button(p1, GUIContent.none))
        {
            Debug.Log("Clicked1");
        }
        GUILayout.Label("button1");
        EditorGUILayout.EndVertical();
        Rect p2 = EditorGUILayout.BeginVertical("Button", GUILayout.Width(100));
        if (GUI.Button(p2, GUIContent.none))
        {
            Debug.Log("Clicked2");
        }
        GUILayout.Label("button2");
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        Rect r = EditorGUILayout.BeginHorizontal("Button");
        if(GUI.Button(r, GUIContent.none))
        {
            Debug.Log("Clicked");
        }
        GUILayout.Label("I'm inside the button");
        EditorGUILayout.EndHorizontal();

        dropDownIndex = EditorGUILayout.Popup(dropDownIndex, dropDownList);
        if (GUILayout.Button("Clicky"))
        {
            switch(dropDownIndex)
            {
                case 0:
                    Debug.Log("clicked 0");
                    break;
                case 1:
                    Debug.Log("clicked 1");
                    break;
                case 2:
                    Debug.Log("clicked 3");
                    break;
                default:
                    Debug.LogError("Unrecognized Option");
                    break;
            }
        }




            EditorGUILayout.EndScrollView();
        //if (GUI.changed) Debug.Log("Input changed");
    }
}