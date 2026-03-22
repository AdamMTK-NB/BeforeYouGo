using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 offset = new Vector3(0, 0.5f, 2f);

    void Update()
    {
        if (playerCamera == null) return;

        transform.position = playerCamera.position +
            playerCamera.forward * offset.z +
            playerCamera.up * offset.y +
            playerCamera.right * offset.x;

        transform.rotation = playerCamera.rotation;
    }
}