using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoveBandage : MonoBehaviour
{
    public GameObject oldBandage;
    public ArrowPointer pointerArrow;
    public Transform bandageRollTarget;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;

    void Start()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnBandageRemoved);
    }

    void OnBandageRemoved(SelectEnterEventArgs args)
    {
        oldBandage.SetActive(false);
        StepManager.singleton.SetStep(1);

        // Move arrow to bandage roll
        pointerArrow.target = bandageRollTarget;
    }
}