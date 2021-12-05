using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame() 
   {
       SceneManager.LoadScene("Level 1");
   }

   public void Instructions()
   {
       SceneManager.LoadScene("");
   }

   public void Settings()
   {
       SceneManager.LoadScene("");
   }
}
