using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] private Transform _startPosRay;
    [SerializeField] private Transform _targetPosRay;
    private Ray _rayTargets;
    private Ray _rayMouse;
    private RaycastHit _hitTargets;
    private RaycastHit _hitMouse;

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
}
