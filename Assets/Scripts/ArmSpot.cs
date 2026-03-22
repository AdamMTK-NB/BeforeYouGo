using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArmSpot : MonoBehaviour
{
    public BloodDrawManager bloodDrawManager;
    public GameObject glowSphere;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private bool triggered = false;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
        gameObject.SetActive(false);
    }

    void OnSelected(SelectEnterEventArgs args)
    {
        if (triggered) return;
        if (StepManager.singleton.GetCurrentStep() != 2) return;
        triggered = true;
        bloodDrawManager.OnInjected();
    }

    public void Show()
    {
        triggered = false;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}