using UnityEngine;

public class Test : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private Quaternion RotationY = Quaternion.AngleAxis(7.2f, Vector3.up);

    //C������ �����  Update
    //����� V � ��������� 
    private void FixedUpdate()
    {
        transform.rotation *= RotationY;
    }



}
