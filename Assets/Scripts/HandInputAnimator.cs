using UnityEngine;
using UnityEngine.XR;

public class HandDebug : MonoBehaviour
{
    public Animator animator;
    public XRNode handNode = XRNode.RightHand;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);
        
        device.TryGetFeatureValue(CommonUsages.trigger, out float trigger);
        device.TryGetFeatureValue(CommonUsages.grip, out float grip);
        
        Debug.Log($"HAND DEBUG - Trigger: {trigger} Grip: {grip}");
        
        // Force animate regardless
        animator.SetFloat("Trigger", trigger);
        animator.SetFloat("Grip", grip);
    }
}