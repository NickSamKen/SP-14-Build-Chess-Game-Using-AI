using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static bool gamep = false;
    public GameObject pm;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamep)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
        pm.SetActive(false);
        Time.timeScale = 1f;
        gamep =false;

    }
    public void Pause()
    {
        pm.SetActive(true);
        Time.timeScale = 0f;
        gamep = true;
    }
    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
