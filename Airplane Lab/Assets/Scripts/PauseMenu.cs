using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public void Menu()
   {
       SceneManager.LoadScene("Menu");
       Time.timeScale = 1;
   }

   public void Resume()
   {
       Time.timeScale = 1;
   }

   public void Pause()
   {
       Time.timeScale = 0;
   }
}
