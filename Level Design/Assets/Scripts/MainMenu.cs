using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Inventory Test");
    }
    
    public void QuitGame() {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
