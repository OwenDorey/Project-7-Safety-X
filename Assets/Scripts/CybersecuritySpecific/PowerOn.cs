using System.Collections;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject startupScreen;
    public GameObject loginScreen;

    public Material onMaterial;
    public Material offMaterial;

    public Animator showDay;

    [HideInInspector] public bool isOn = false;
    private void OnMouseDown()
    {
        if (!isOn)
        {
            startupScreen.SetActive(true);
            gameObject.GetComponent<Renderer>().material = onMaterial;
            isOn = true;
            StartCoroutine(StartUp());
        }

        IEnumerator StartUp()
        {
            yield return new WaitForSeconds(3f);

            loginScreen.SetActive(true);
            showDay.SetTrigger("Show");
            startupScreen.SetActive(false);
        }
            
    }
}