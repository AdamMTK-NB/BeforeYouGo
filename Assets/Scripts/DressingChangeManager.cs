using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DressingChangeManager : MonoBehaviour
{
    public GameObject armCanvas;
    public GameObject patientNormal;
    public GameObject patientWithNewBandage;
    public GameObject bandageRoll;
    public AudioSource cheerSound;
    public FadeScreen fadeScreen;

    public void OnNewBandageApplied()
    {
        StartCoroutine(ApplySequence());
    }

    IEnumerator ApplySequence()
    {
        // Hide arm canvas and bandage roll
        if (armCanvas != null) armCanvas.SetActive(false);
        if (bandageRoll != null) bandageRoll.SetActive(false);

        // Swap patient
        if (patientNormal != null) patientNormal.SetActive(false);
        if (patientWithNewBandage != null) patientWithNewBandage.SetActive(true);

        // Step 4 complete
        StepManager.singleton.SetStep(4);

        yield return new WaitForSeconds(2f);

        if (cheerSound != null) cheerSound.Play();

        yield return new WaitForSeconds(2f);

        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(0);
    }
}