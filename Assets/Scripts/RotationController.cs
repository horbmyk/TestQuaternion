using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCube;

    //Velocity Revolutions per minute
    [Range(0, 200)] [SerializeField] private int _velocityRevolutionsMinute = 60;

    //Velocity Revolutions per second
    private float _velocityRevolutionsSecond;

    //Number of frames per second
    private float _numberFramesSecond;

    //Angle per frame
    private float _angleFrame;

    private Quaternion RotationY;

    private const float FULL_REVOLUTION = 360f;

    private void Update()
    {
        _velocityRevolutionsSecond = _velocityRevolutionsMinute / 60f;
        _numberFramesSecond = (1.0f / Time.deltaTime);
        _angleFrame = FULL_REVOLUTION / _numberFramesSecond * _velocityRevolutionsSecond;
        RotationY = Quaternion.AngleAxis(_angleFrame, Vector3.up);
        _mainCube.transform.rotation *= RotationY;
    }
}
