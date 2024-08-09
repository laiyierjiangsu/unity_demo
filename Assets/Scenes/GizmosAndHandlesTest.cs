using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
[ExecuteInEditMode] 
public class GizmosAndHandlesTest : MonoBehaviour
{
    public float shieldArea;
    public float value = 7.0f;
    public Vector3 targetPosition { get { return m_TargetPosition; } set { m_TargetPosition = value; } }
    [SerializeField]
    private Vector3 m_TargetPosition = new Vector3(1f, 0f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        transform.LookAt(m_TargetPosition);
    }

    void OnDrawGizmosSelected()
    {
        //https://docs.unity3d.com/2023.2/Documentation/ScriptReference/Gizmos.html
        // Draw a yellow cube at the transform position
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireCube(transform.position, new Vector3(10, 10, 10));
    }

}


// Create a 180 degrees wire arc with a ScaleValueHandle attached to the disc
// that lets you modify the "shieldArea" value in the WireArcExample
[CustomEditor(typeof(GizmosAndHandlesTest))]
public class DrawWireArc : Editor
{
    void OnSceneGUI()
    {
        ////Handles https://docs.unity3d.com/2023.2/Documentation/ScriptReference/Handles.html
        //Handles.color = Color.red;
        //GizmosAndHandlesTest myObj = (GizmosAndHandlesTest)target;
        //Handles.DrawWireArc(myObj.transform.position, myObj.transform.up, -myObj.transform.right, 180, myObj.shieldArea);
        //myObj.shieldArea = (float)Handles.ScaleValueHandle(myObj.shieldArea, myObj.transform.position + myObj.transform.forward * myObj.shieldArea, myObj.transform.rotation, 1, Handles.ConeHandleCap, 1);


        //var t = target as GizmosAndHandlesTest;
        //var tr = t.transform;
        //var pos = tr.position;
        //// display an orange disc where the object is
        //var color = new Color(1, 0.8f, 0.4f, 1);
        //Handles.color = color;
        //Handles.DrawWireDisc(pos, tr.up, 1.0f);
        //// display object "value" in scene
        //GUI.color = color;
        //Handles.Label(pos, t.value.ToString("F1"));


        //GizmosAndHandlesTest handleExample = (GizmosAndHandlesTest)target;
        //if (handleExample == null)
        //{
        //    return;
        //}

        //Handles.color = Color.blue;
        //Handles.Label(handleExample.transform.position + Vector3.up * 2,
        //    handleExample.transform.position.ToString() + "\nShieldArea: " +
        //    handleExample.shieldArea.ToString());

        //Handles.BeginGUI();
        //if (GUILayout.Button("Reset Area", GUILayout.Width(100)))
        //{
        //    handleExample.shieldArea = 5;
        //}
        //Handles.EndGUI();


        //Handles.DrawWireArc(handleExample.transform.position,
        //    handleExample.transform.up,
        //    -handleExample.transform.right,
        //    180,
        //    handleExample.shieldArea);
        //handleExample.shieldArea =
        //    Handles.ScaleValueHandle(handleExample.shieldArea,
        //        handleExample.transform.position + handleExample.transform.forward * handleExample.shieldArea,
        //        handleExample.transform.rotation,
        //        1,
        //        Handles.ConeHandleCap,
        //        1);


        //GizmosAndHandlesTest example = (GizmosAndHandlesTest)target;

        //float size = HandleUtility.GetHandleSize(example.targetPosition) * 0.5f;
        //float snap = 0.1f;

        //EditorGUI.BeginChangeCheck();
        //Vector3 newTargetPosition = Handles.Slider(example.targetPosition, Vector3.up, size, Handles.ArrowHandleCap, snap);
        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObject(example, "Change Look At Target Position");
        //    example.targetPosition = newTargetPosition;
        //    example.Update();
        //}


        GizmosAndHandlesTest example = (GizmosAndHandlesTest)target;

        //float size = HandleUtility.GetHandleSize(example.targetPosition) * 0.5f;
        float size = 0.3f; 
        float snap = 0.1f;
        Vector3 handleDirection = Vector3.up;

        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.Slider2D(example.targetPosition, handleDirection, Vector3.right, Vector3.forward, size, Handles.SphereHandleCap, snap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(example, "Change Look At Target Position");
            example.targetPosition = newTargetPosition;
            example.Update();
        }
    }
}
