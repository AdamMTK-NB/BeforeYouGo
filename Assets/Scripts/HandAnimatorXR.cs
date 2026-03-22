using UnityEngine;
using UnityEngine.XR;

public class HandAnimatorXR : MonoBehaviour
{
    public Animator animator;
    public XRNode handNode = XRNode.RightHand;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);
        
        device.TryGetFeatureValue(CommonUsages.trigger, out float trigger);
        device.TryGetFeatureValue(CommonUsages.grip, out float grip);
        
        animator.SetFloat("Trigger", trigger);
        animator.SetFloat("Grip", grip);
    }
}