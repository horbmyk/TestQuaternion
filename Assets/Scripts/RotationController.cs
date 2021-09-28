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

    //Velocity Revolutions per frame
    private float _vRPF;

    //Angle per frame
    private float _aFPF;

    private Quaternion RotationY;

    private void Update()
    {
        _vRPS = _vRPM / 60f;
        _nFPS = (1.0f / Time.deltaTime);
        _vRPF = _vRPS / _nFPS;
        _aFPF = _vRPF / Time.deltaTime;
        RotationY = Quaternion.AngleAxis(_aFPF, Vector3.up);
        _mainCube.transform.rotation *= RotationY;
    }
}
