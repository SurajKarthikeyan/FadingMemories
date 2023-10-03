using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskMenuUIManager : MonoBehaviour
{
    
    public GameObject currActivePage;

    public GameObject clipboard;

    public Flowchart currentFlowChart;

    public AudioSource taskAudioSource;
    public AudioClip menuToggleSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleClipboard();
            taskAudioSource.PlayOneShot(menuToggleSFX);
        }
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenPage(GameObject page)
    {
        Debug.Log("I'm opening the page " + page.name);
        currActivePage.SetActive(false);
        page.SetActive(true);
        currActivePage = page;
    }

    public void ToggleClipboard()
    {
        if (clipboard.activeInHierarchy)
        {
            clipboard.SetActive(false);
            currentFlowChart.SetBooleanVariable("BlockExecuting", false);
        }
        else
        {
            clipboard.SetActive(true);
            currentFlowChart.SetBooleanVariable("BlockExecuting", true);
        }
    }


}
