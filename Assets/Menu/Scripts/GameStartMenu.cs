using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject howItWorks;
    public GameObject procedureSelection;

    [Header("Other")]
    public GameObject gameTitle;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button howItWorksButton;

    public List<Button> returnButtons;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    void Start()
    {
        EnableMainMenu();

        startButton.onClick.AddListener(StartGame);
        howItWorksButton.onClick.AddListener(EnableHowItWorks);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    private void PlayClick()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
    }

    public void StartGame()
    {
        PlayClick();
        HideAll();
        procedureSelection.SetActive(true);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        howItWorks.SetActive(false);
        gameTitle.SetActive(false);
        procedureSelection.SetActive(false);
    }

    public void EnableMainMenu()
    {
        PlayClick();
        mainMenu.SetActive(true);
        howItWorks.SetActive(false);
        gameTitle.SetActive(true);
        procedureSelection.SetActive(false);
    }

    public void EnableHowItWorks()
    {
        PlayClick();
        mainMenu.SetActive(false);
        howItWorks.SetActive(true);
        gameTitle.SetActive(false);
        procedureSelection.SetActive(false);
    }

    public void QuitGame()
    {
        PlayClick();
        Application.Quit();
    }
}