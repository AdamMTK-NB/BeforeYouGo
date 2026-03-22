using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform target;
    public float bobSpeed = 2f;
    public float bobAmount = 0.05f;
    public float heightAboveTarget = 0.3f;

    void Update()
    {
        if (target == null) return;

        // Position above the target
        transform.position = target.position + 
            Vector3.up * (heightAboveTarget + 
            Mathf.Sin(Time.time * bobSpeed) * bobAmount);

        // Always point downward toward target
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}