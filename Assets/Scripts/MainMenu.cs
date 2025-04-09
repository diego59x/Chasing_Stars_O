using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static readonly string FirstTimePlayingPref = "FirstTimePlayingPref";

    public GameObject settingsMenu;
    public GameObject mainMenu;
    public GameObject historyMenu;
    public GameObject instructionsUI;
    public GameObject creditsMenu;

    public bool useInstructions;
    public AudioClip audioClick;
    private AudioSource audioManage;
    private float soundVolumeEffects;
    private void Start()
    {
        Time.timeScale = 1;
        //PlayerPrefs.SetInt(FirstTimePlayingPref, 0);

        if (PlayerPrefs.GetInt(FirstTimePlayingPref) < 2)
        {
            if (historyMenu && PlayerPrefs.GetInt(FirstTimePlayingPref) == 0)
                PlayerPrefs.SetInt(FirstTimePlayingPref, 1);
                historyMenu.SetActive(true);

            if (useInstructions && PlayerPrefs.GetInt(FirstTimePlayingPref) == 1)
                PlayerPrefs.SetInt(FirstTimePlayingPref, 2);
                StartCoroutine(DisplayInstructions());
        }
        soundVolumeEffects = PlayerPrefs.GetFloat("SoundEffectsPref");
        audioManage = GetComponent<AudioSource>();
        audioManage.volume = PlayerPrefs.GetFloat("BackgroundPref");
    }
    public void SpacelogScene()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        SceneManager.LoadScene("SpaceLog");
    }
    public void MainMenuScene()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        SceneManager.LoadScene("Menu");
    }
    public void PlayGame()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        SceneManager.LoadScene("RacingStars");
    }
    public void ButtonPause()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        Time.timeScale = 0;
        settingsMenu.SetActive(true);
    }
    public void ButtonResume()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        Time.timeScale = 1;
        settingsMenu.SetActive(false);
    }

    public void Settings()
    {
        creditsMenu.SetActive(false);
        historyMenu.SetActive(false);
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        audioManage.PlayOneShot(audioClick, soundVolumeEffects + 0.2f);
        Application.Quit();
    }

    public void HideShowHistory()
    {
        if (historyMenu.activeSelf)
        {
            historyMenu.SetActive(false);
        }
        else
        {
            creditsMenu.SetActive(false);
            historyMenu.SetActive(true);
        }
    }

    public void HideShowCredits()
    {

        if (creditsMenu.activeSelf) 
        {
            creditsMenu.SetActive(false);
        } 
        else 
        {
            historyMenu.SetActive(false);
            creditsMenu.SetActive(true);
        }
    }

    IEnumerator DisplayInstructions()
    {
        instructionsUI.SetActive(true);
        yield return new WaitForSeconds(4);
        instructionsUI.SetActive(false);
        StopCoroutine(DisplayInstructions());
    }

}
