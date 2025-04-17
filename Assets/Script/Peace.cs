using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peace : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GridManager gridManager;
    private float moveSpeed = 10f;
    private Vector2 targetLocal;
    public Vector2 posMap = new Vector2(0, 0);

    [SerializeField] public int type;

    private List<string> stackDir = new List<string>();

    private bool isRun = false;

    private bool isState = false;

    private void Awake()
    {

    }

    public void stateDone(bool done)
    {
        isState = done;
    }

    public void Init()
    {
        Vector3Int cellPosition = new Vector3Int((int)posMap.x, (int)posMap.y, 0);
        Vector3 worldPosition = gridManager.tilemap.GetCellCenterWorld(cellPosition);
        this.transform.position = worldPosition;
        targetLocal = transform.position;

        Vector3 scale = this.transform.localScale;
        scale.x = 0.95f;
        scale.y = 0.95f;
        this.transform.localScale = scale;
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (isRun == false)
        {
            if (stackDir.Count > 0)
            {
                changeTaret(stackDir[0]);
                stackDir.RemoveAt(0);
                isRun = true;
            }
        }
        var step = moveSpeed * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetLocal, step);
        if (Vector2.Distance(this.transform.position, targetLocal) < 0.0001f)
        {
            isRun = false;
            gridManager.setGrid((int)targetLocal.x, (int)targetLocal.y, 2);

        }
    }

    public void addTarget(string direct)
    {
        stackDir.Add(direct);
    }

    public void changeTaret(string direct)
    {

        if (!canMove(direct))
        {
            // Debug.Log("loi cai" + type);
            return;
        }

        moveForDirect(direct);


    }

    public bool canMove(string direct)
    {
        if (direct == "left")
        {
            return gridManager.checkPos((int)posMap.x - 1, (int)posMap.y, isState);
        }
        else if (direct == "right")
        {
            return gridManager.checkPos((int)posMap.x + 1, (int)posMap.y, isState);
        }
        else if (direct == "up")
        {
            return gridManager.checkPos((int)posMap.x, (int)posMap.y + 1, isState);
        }
        else if (direct == "down")
        {
            return gridManager.checkPos((int)posMap.x, (int)posMap.y - 1, isState);
        }
        else
        {
            return false;
        }
    }


    public void moveForDirect(string direct)
    {
        gridManager.setGrid((int)posMap.x, (int)posMap.y, 0);
        if (direct == "left")
        {
            targetLocal -= new Vector2(1, 0);
            posMap -= new Vector2(1, 0);
        }
        else if (direct == "right")
        {
            targetLocal += new Vector2(1, 0);
            posMap += new Vector2(1, 0);
        }
        else if (direct == "up")
        {
            targetLocal += new Vector2(0, 1);
            posMap += new Vector2(0, 1);
        }
        else
        {
            targetLocal -= new Vector2(0, 1);
            posMap -= new Vector2(0, 1);
        }
        // Debug.Log(posMap + "  " + type);

    }

    public void setLocation(int x, int y)
    {
        if (type == 1)
        {
            posMap = new Vector2(x + 1, y);
        }
        else if (type == 2)
        {
            posMap = new Vector2(x, y);
        }
        else if (type == 3)
        {
            posMap = new Vector2(x, y + 1);
        }
        else
        {
            posMap = new Vector2(x + 1, y + 1);
        }
    }



    public bool isPeace(int x, int y)
    {
        if (x == posMap.x && y == posMap.y) return true;
        else return false;
    }




}
