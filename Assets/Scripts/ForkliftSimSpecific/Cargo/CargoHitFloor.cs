using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CargoHitFloor : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private MenuResultController resultController;
    [SerializeField] private AudioSource forkliftEngine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(PauseForAnimation());
        }
    }

    IEnumerator PauseForAnimation()
    {
        yield return new WaitForSeconds(1f);
        forkliftEngine.Stop();
        resultController.loseMenuPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(restartButton);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}