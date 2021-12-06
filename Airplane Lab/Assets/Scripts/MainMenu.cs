using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public int totalScore;

   public void PlayGame() 
   {
       SceneManager.LoadScene("Level 1"); //go the level 1
       PlayerPrefs.SetInt("PlayerScore", totalScore); //player starts with 0 score
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
