using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;

public class Test : EditorWindow
{
    [MenuItem("Winodw/Test")]
    // Start is called before the first frame update
    static void Init()
    {
        Test window = (Test)EditorWindow.GetWindow(typeof(Test));
        window.Show();
    }

    // Update is called once per frame
    void OnGUI()
    {
        Handles.color = Color.red ;
        Handles.DrawRectangle(0, new Vector3(160, 200, 0), Quaternion.identity,80 );
        Handles.DrawSolidDisc(new Vector3(60, 200, 0),Vector3.forward, 50);
        Handles.color = Color.yellow;
        Handles.DrawSolidDisc(new Vector3(160, 200, 0),Vector3.forward, 50);
        Handles.color = Color.green;
        Handles.DrawSolidDisc(new Vector3(260, 200, 0),Vector3.forward, 50);
    }
}
