using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;
    public GameObject pausePanel;

    private void Update()
    {
        scoreTMP.text = "Score: " + GameManager.staticScore;       
    }


    public void ExitButton()
    {
        Application.Quit();
    }

    public void PauseResumeButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
