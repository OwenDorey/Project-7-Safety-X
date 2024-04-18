using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuResultController : MonoBehaviour
{
    [Header("Menus")]
    public GameObject initialLoadPanel;
    public GameObject pauseMenuPanel;
    public GameObject winMenuPanel;
    public GameObject loseMenuPanel;
    public GameObject loadingMenu;
    [Header("Engine Audio")]
    [SerializeField] private AudioSource forkliftEngine;
    [Header("Sliders")]
    [SerializeField] private Slider slider;
    [Header("Buttons")]
    [SerializeField] private GameObject startGameButton;

    [HideInInspector] public bool gameStarted = false;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        winMenuPanel.SetActive(false);
        loseMenuPanel.SetActive(false);
        loadingMenu.SetActive(false);
        initialLoadPanel.SetActive(true);
        forkliftEngine.enabled = false;
        EventSystem.current.SetSelectedGameObject(startGameButton);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        forkliftEngine.enabled = true;
        initialLoadPanel.SetActive(false);
        gameStarted = true;
    }

    public void Resume()
    {
        forkliftEngine.Play();
        pauseMenuPanel.SetActive(false);
        winMenuPanel.SetActive(false);
        loseMenuPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void Restart(string levelToLoad)
    {
        pauseMenuPanel.SetActive(false);
        winMenuPanel.SetActive(false);
        loseMenuPanel.SetActive(false);
        loadingMenu.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    public void QuitToMainMenu(string levelToLoad)
    {
        pauseMenuPanel.SetActive(false);
        winMenuPanel.SetActive(false);
        loseMenuPanel.SetActive(false);
        loadingMenu.SetActive(true);
        Time.timeScale = 1;
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
}