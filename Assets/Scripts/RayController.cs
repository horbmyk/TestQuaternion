using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] GameObject StartObj;
    [SerializeField] GameObject FinishObj;
    private void FixedUpdate()
    {
        Ray ray = new Ray(StartObj.transform.position, FinishObj.transform.position);
        Debug.DrawRay(gameObject.transform.position, FinishObj.transform.position, Color.green);
    }
}
