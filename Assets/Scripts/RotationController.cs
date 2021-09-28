using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCube;

    //Velocity Revolutions per minute
    [Range(0, 200)] [SerializeField] private int _vRPM = 60;

    //Velocity Revolutions per second
    private float _vRPS;

    //Number of frames per second
    private float _nFPS;

    //Angle per frame
    private float _aFPF;

    const float Constant_FullRevolutions = 360f;

    private Quaternion RotationY;

    private void Update()
    {
        _vRPS = _vRPM / 60f;
        _nFPS = (1.0f / Time.deltaTime);
        _aFPF = Constant_FullRevolutions / _nFPS * _vRPS;
        RotationY = Quaternion.AngleAxis(_aFPF, Vector3.up);
        _mainCube.transform.rotation *= RotationY;
    }
}
