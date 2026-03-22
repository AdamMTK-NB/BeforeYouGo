using UnityEngine;
using UnityEngine.UI;

public class StepManager : MonoBehaviour
{
    public static StepManager singleton;

    [Header("UI")]
    public Image instructionImage;
    public GameObject directionArrow;

    [Header("Step Images")]
    public Sprite step0Image; // Go pick up the syringe
    public Sprite step1Image; // Walk over to the patient
    public Sprite step2Image; // Press the glowing spot
    public Sprite step3Image; // Hold still
    public Sprite step4Image; // Remove the syringe

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        SetStep(0);
    }

    public void SetStep(int step)
    {
        // Show correct image
        switch (step)
        {
            case 0:
                instructionImage.sprite = step0Image;
                break;
            case 1:
                instructionImage.sprite = step1Image;
                break;
            case 2:
                instructionImage.sprite = step2Image;
                break;
            case 3:
                instructionImage.sprite = step3Image;
                break;
            case 4:
                instructionImage.sprite = step4Image;
                break;
        }

        // Hide arrow after step 0
        if (directionArrow != null)
            directionArrow.SetActive(step == 0);
    }

    public int GetCurrentStep()
    {
        return currentStep;
    }

    private int currentStep = 0;

    public void AdvanceStep()
    {
        currentStep++;
        if (currentStep <= 4)
            SetStep(currentStep);
    }
}