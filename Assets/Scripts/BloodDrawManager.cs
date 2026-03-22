using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodDrawManager : MonoBehaviour
{
    public GameObject armCanvas;
    public GameObject patientNormal;
    public GameObject patientWithBlood;
    public AudioSource cheerSound;
    public FadeScreen fadeScreen;
    public GameObject syringeObject;

    public void OnInjected()
    {
        StartCoroutine(InjectionSequence());
    }

    IEnumerator InjectionSequence()
    {
        // Step 3 - hold still
        StepManager.singleton.SetStep(3);
        armCanvas.SetActive(false);

        yield return new WaitForSeconds(2f);

        // Swap patient model
        if (patientNormal != null) patientNormal.SetActive(false);
        if (patientWithBlood != null) patientWithBlood.SetActive(true);

        // Step 4 - remove syringe
        StepManager.singleton.SetStep(4);

        yield return new WaitForSeconds(2f);

        // Step 5 - syringe disappears HERE
        if (syringeObject != null)
            syringeObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        if (cheerSound != null) cheerSound.Play();

        yield return new WaitForSeconds(2f);

        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(0);
    }
}