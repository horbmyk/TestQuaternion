using UnityEngine;

public class Test : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private Quaternion RotationY = Quaternion.AngleAxis(7.2f, Vector3.up);


    private void FixedUpdate()
    {
        transform.rotation *= RotationY;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X:" + x + " Y:" + y + " Z:" + z, style);
        GUI.Label(new Rect(10, 25, 0, 0), "Transform.eulerAngle: " + transform.eulerAngles, style);
    }

}
