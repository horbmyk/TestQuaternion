using UnityEngine;

public class Test : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private Quaternion RotationY = Quaternion.AngleAxis(7.2f, Vector3.up);

    //Cделать через  Update
    //«м≥нна V в ≥нспектор≥ 
    private void FixedUpdate()
    {
        transform.rotation *= RotationY;
    }



}
