using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListStart : MonoBehaviour
{
    [SerializeField] Timer timer ;
    [SerializeField] GameObject pane;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    [SerializeField] Number numberStart;

    [SerializeField] GameObject board;


    public void Lose() {
        Time.timeScale = 0;
        lose.SetActive(true);
        show();
    }

    public void Win() {
        // Time.timeScale = 0;
        timer.off();
        win.SetActive(true);
        float time = timer.getTime();
        if (time > 30) {
            numberStart.setPoint(3);
        } else if (time > 15) {
            numberStart.setPoint(2);
        } else {
            numberStart.setPoint(1);
        }

        show();
    }


    public void show() {
        board.SetActive(false);
        pane.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
