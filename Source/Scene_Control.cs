using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static int scenecount = 1;

    public void pause()
    {
        //Time.timeScale = 0f;
        open();
    }

    public void resume()
    {
        //Time.timeScale = 1f;
        back();
    }

    public void open()
    {
        pauseMenu.SetActive(true);
    }

    public void back()
    {
        pauseMenu.SetActive(false);
    }

    public void Menu(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        //Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void next()
    {
        Debug.Log("scenecount = " + scenecount);
        if (scenecount == 4)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            scenecount += 1;
            SceneManager.LoadScene(1);
        }
    }
}
