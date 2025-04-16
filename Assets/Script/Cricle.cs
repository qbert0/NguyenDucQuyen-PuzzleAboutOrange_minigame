using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<Peace> listpeace;
    private void Awake() {
        
    }
    public bool checkDone()
    {
        for (int i = 0; i < listpeace.Count; i++)
        {
            if ((listpeace[i].posMap.x * listpeace[i].posMap.y ) - (int)(listpeace[i].posMap.x * listpeace[i].posMap.y ) > 0) return false;
        }
        if (!(listpeace[0].posMap + new Vector2(-1, 0) == listpeace[1].posMap)) return false;
        if (!(listpeace[1].posMap + new Vector2(0, 1) == listpeace[2].posMap)) return false;
        if (!(listpeace[2].posMap + new Vector2(1, 0) == listpeace[3].posMap)) return false;
        if (!(listpeace[3].posMap + new Vector2(0, -1) == listpeace[0].posMap)) return false;
        return true;
    }

    public Vector2 pos = new Vector2(0, 0);
    private string directLocal;

    public void setLocation(int x, int y)
    {
        for (int i = 0; i < listpeace.Count; i++)
        {
            listpeace[i].setLocation(x, y);
            listpeace[i].Init();
        }

        setup();
    }

    public void setup() {
        List<string> list = createRandom(2);

        foreach (string sl in list) {
            for (int i = 0; i < listpeace.Count; i++)
            {
                listpeace[i].addTarget(sl);
            
            }
        }


        for (int i = 0; i < listpeace.Count; i++)
        {
            listpeace[i].stateDone(true);
            
        }
    }

    public void resetup() {
        for (int i = 0; i < listpeace.Count; i++)
        {
            listpeace[i].stateDone(false);
        }
    }

    public List<string> createRandom(int count)
    {
        string[] possibleDirections = { "left", "right", "up", "down" };

        List<string> result = new List<string>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, possibleDirections.Length);
            result.Add(possibleDirections[randomIndex]);
        }

        return result;
    }


    public void move(string direct)
    {
        // Debug.Log("Hướng vuốt: " + direct);
        directLocal = direct;
        for (int i = 0; i < listpeace.Count; i++)
        {
            listpeace[i].addTarget(direct);
        }
    }

    public bool askAnotherPeace(int x, int y)
    {
        for (int i = 0; i < listpeace.Count; i++)
        {
            if (listpeace[i].isPeace(x, y))
            {
                return listpeace[i].canMove(directLocal);
            }
        }
        return false;
    }

    
}
