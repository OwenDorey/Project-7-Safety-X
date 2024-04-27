using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuResultControllerCS : MonoBehaviour
{
    [Header("Menus")]
    public GameObject gameStartPanel;
    public GameObject pauseMenuPanel;
    public GameObject loadingGameCanvas;
    [Header("Sliders")]
    [SerializeField] private Slider loadingSlider;
    [Header("Buttons")]
    [SerializeField] private GameObject gameStartButton;
    [Header("Animators")]
    [SerializeField] private Animator showDay;

    [HideInInspector] public bool gameStarted = false;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        loadingGameCanvas.SetActive(false);
        gameStartPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameStartButton);
    }

    public void StartGame()
    {
        gameStartPanel.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1;
        showDay.SetTrigger("Show");
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart(string levelToLoad)
    {
        pauseMenuPanel.SetActive(false);
        loadingGameCanvas.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    public void QuitToMainMenu(string levelToLoad)
    {
        pauseMenuPanel.SetActive(false);
        loadingGameCanvas.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}