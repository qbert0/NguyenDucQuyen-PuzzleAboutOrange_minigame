using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{


    // Start is called before the first frame update
    [SerializeField] private Cricle circle;
    private void Awake() {
        
    }
    private Vector2 touchStart;
    private Vector2 touchEnd;

    public void UpdateCamera(Vector3 center) {
        this.transform.position = center;
        Debug.Log("spri  " + center);

    }
    void Update()
    {
        TouchMove();
    }

    void TouchMove()
    {

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            touchStart = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            touchEnd = Input.GetTouch(0).position;

            Vector2 direct = touchEnd - touchStart;
            circle.move(CheckDirection(direct));
            
        }


    }


    public string CheckDirection(Vector2 vector)
    {
        if (vector == Vector2.zero)
        {
            return "no";
        }

        if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
        {
            if (vector.x > 0)
            {

                return "right";
            }
            else
            {
                return "left";
            }
        }
        else
        {
            if (vector.y > 0)
            {
                return "up";
            }
            else
            {
                return "down";
            }
        }
    }
}
