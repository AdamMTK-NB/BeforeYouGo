using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BandageGrab : MonoBehaviour
{
    public ArrowPointer pointerArrow;
    public GameObject armCanvas;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool grabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        if (armCanvas != null) armCanvas.SetActive(false);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        if (grabbed) return;
        grabbed = true;
        StepManager.singleton.SetStep(2);
        if (pointerArrow != null) pointerArrow.gameObject.SetActive(false);
        Invoke(nameof(ShowArmCanvas), 1.5f);
    }

    void ShowArmCanvas()
    {
        StepManager.singleton.SetStep(3);
        if (armCanvas != null) armCanvas.SetActive(true);
    }
}