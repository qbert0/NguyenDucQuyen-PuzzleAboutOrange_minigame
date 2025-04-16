using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour
{
    [SerializeField] public GameObject imageObject;

    public void IsLock(bool locked) {

        if (locked) {
            imageObject.SetActive(true);
        } else {
            
            imageObject.SetActive(false);
        }
    }
}
