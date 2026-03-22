using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProcedureCard : MonoBehaviour
{
    public int sceneIndex;
    public AudioSource audioSource;
    public AudioClip clickSound;
    public FadeScreen fadeScreen;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnCardSelected);
    }

    public void OnCardSelected()
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}