using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] private Transform _startPosRay;
    [SerializeField] private Transform _targetPosRay;
    private Ray _rayTargets;
    private Ray _rayMouse;
    private RaycastHit _hitTargets;
    private RaycastHit _hitMouse;

    private void Start()
    {
        _rayTargets = new Ray(_startPosRay.position, _targetPosRay.position);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ChangeTarget();

        if (Input.GetKeyDown(KeyCode.Space))
            ShowInfoTarget();

        Debug.DrawRay(_startPosRay.transform.position, _targetPosRay.position, Color.green);

    }

    private void ChangeTarget()
    {
        _rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_rayMouse, out _hitMouse) && _hitMouse.collider.gameObject)
        {
            _targetPosRay = _hitMouse.collider.gameObject.transform;
            _rayTargets = new Ray(_startPosRay.position, _targetPosRay.position);
        }
    }

    private void ShowInfoTarget()
    {
        if (Physics.Raycast(_rayTargets, out _hitTargets))
            Debug.Log("Targets Name: " + _hitTargets.collider.name + "  " + " Distance to Target = " + _hitTargets.distance);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        GUI.Label(new Rect(10, 0, 0, 0), " 1. Select a new targets with the MouseLeftButton", style);
        GUI.Label(new Rect(10, 25, 0, 0), " 2. Get Targets Info  - press Spase ", style);
    }
}
