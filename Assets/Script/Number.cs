using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    
    [SerializeField] Image[] image;
    [SerializeField] Sprite spirte1;
    [SerializeField] Sprite spirte2;

    
    public void setPoint(int point) {
        if (point == 1 ) {
            image[0].sprite = spirte1;
            image[1].sprite = spirte2;
            image[2].sprite = spirte2;
        } else if (point == 2 ) {
            image[0].sprite = spirte1;
            image[1].sprite = spirte2;
            image[2].sprite = spirte1;
        } else {
            image[0].sprite = spirte1;
            image[1].sprite = spirte1;
            image[2].sprite = spirte1;
        }
    }
}
