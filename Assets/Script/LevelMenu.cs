using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] public LockLevel[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].IsLock(true) ;
            
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].IsLock(false) ;
        }
    }

    public void OpenLevel(int level)
    {
        Destroy(gameObject);
        string LevelName = "Level " + level;
        SceneManager.LoadScene(LevelName);
    }
}
