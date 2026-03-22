using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SyringeGrab : MonoBehaviour
{
    public GameObject armCanvas;
    public BloodDrawManager bloodDrawManager;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool injectionStarted = false;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        if (armCanvas != null) armCanvas.SetActive(false);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        StepManager.singleton.SetStep(1);
        Invoke(nameof(ShowSpot), 1.5f);
    }

    void ShowSpot()
    {
        StepManager.singleton.SetStep(2);
        if (armCanvas != null) armCanvas.SetActive(true);
    }

    // Call this from the inject button
    public void TriggerInjection()
    {
        if (injectionStarted) return;
        if (StepManager.singleton.GetCurrentStep() != 2) return;
        injectionStarted = true;
        bloodDrawManager.OnInjected();
    }
}