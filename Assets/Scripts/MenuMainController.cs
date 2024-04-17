using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuMainController : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private string forkliftScene;
    [SerializeField] private string cybersecurityScene;
    [Header("Options Menus")]
    [SerializeField] private GameObject optionsMenuPanel_1;
    [SerializeField] private GameObject optionsMenuPanel_2;
    [Header("Options Buttons")]
    [SerializeField] private GameObject optionsCloseButton_1;
    [SerializeField] private GameObject optionsCloseButton_2;
    [SerializeField] private GameObject optionsOpenButton;
    [Header("Game Select Menus")]
    [SerializeField] private GameObject gameSelectPanel;
    [Header("Game Select Buttons")]
    [SerializeField] private GameObject forkliftSelectButton;
    [SerializeField] private GameObject cybersecuritySelectButton;
    [SerializeField] private GameObject gameSelectOpenButton;
    [SerializeField] private GameObject gameSelectCloseButton;
    [Header("Loading Screens")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject loadingScreen;
    [Header("Slider")]
    [SerializeField] private Slider slider;

    public void OptionsMenuClose()
    {
        EventSystem.current.SetSelectedGameObject(optionsOpenButton);
        optionsMenuPanel_1.SetActive(false);
        optionsMenuPanel_2.SetActive(false);
    }

    public void OptionsMenuOpen_1()
    {
        optionsMenuPanel_1.SetActive(true);
        optionsMenuPanel_2.SetActive(false);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton_1);
    }
    public void OptionsMenuOpen_2()
    {
        optionsMenuPanel_1.SetActive(false);
        optionsMenuPanel_2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton_2);
    }

    public void GameSelectOpen()
    {
        gameSelectPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameSelectCloseButton);
    }
    public void GameSelectClose()
    {
        gameSelectPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(gameSelectOpenButton);
    }

    public void StartForkliftGame(string levelToLoad)
    {
        mainMenuPanel.SetActive(false);
        gameSelectPanel.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    public void StartCybersecurityGame(string levelToLoad)
    {
        mainMenuPanel.SetActive(false);
        gameSelectPanel.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}