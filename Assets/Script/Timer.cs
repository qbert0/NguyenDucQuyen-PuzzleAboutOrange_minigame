using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private void Awake() {
        
    }
    [SerializeField] TextMeshProUGUI timer ;

    [SerializeField] float remainingTime;

    [SerializeField] ListStart winPane;
    private float localTime;
   
    void Update() {
        remainingTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);

        timer.text = string.Format("{0:00}:{1:00}", min, second);

        if (remainingTime <= 0) {
            winPane.Lose();
        }
    }

    public void off() {
       timer.text = ""; 
    }

    public bool tooFass() {
        if (remainingTime > 44.5 ) return true;
        else return false;
    }

    public float getTime() {
        return remainingTime;
    }
}
