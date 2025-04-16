using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pasuMenu;
    [SerializeField] GameObject board;

    public void Pausepane() {
        pasuMenu.SetActive(true);
        board.SetActive(false);
        Time.timeScale = 0;
    }

    public void Home() {
        SceneManager.LoadScene("mainMenu");
    }

    public void Resume() {
        pasuMenu.SetActive(false);
        board.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel(int level) {
        string LevelName = "Level " + level;
        SceneManager.LoadScene(LevelName);
        Destroy(gameObject);
    }

    public void outdoor() {
        
        SceneManager.LoadScene("mainMenu");
        
    }
}
