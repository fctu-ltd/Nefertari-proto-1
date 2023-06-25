using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public void Resume()
    {
        GameManager.ins.ResumeGame();
    }

    public void Options()
    {
        Debug.Log("Open Options menu");
    }

    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
