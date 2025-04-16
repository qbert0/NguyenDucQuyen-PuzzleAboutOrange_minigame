using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
[RequireComponent(typeof(Tilemap))]
public class GridManager : MonoBehaviour
{
    public Tilemap tilemap;
    Grid grid;

    [SerializeField] Cricle cricle;

    [SerializeField] BoardBackGround board;
    [SerializeField] Board camera;
    [SerializeField] TileBase tileBase;
    [SerializeField] TileBase tileBase2;
    [SerializeField] int width;
    [SerializeField] int height;

    [SerializeField] int count;
    [SerializeField] Timer time;

    [SerializeField] ListStart winPane;

    private List<Vector2> usePoint = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        grid = GetComponent<Grid>();
        grid.Init( height, width);

        
        RandomCricle( height, width);
        RamdomPoint(width,height, count);


        // foreach(Vector2 p in usePoint) {
        //     Debug.Log(p.x + " " + p.y);
        // }
        UpdateTitleMap();
        UpdateBoard();
    }

    public void RandomCricle(int x, int y) {
        Vector2 point = new Vector2(0, 0 );
        
        point.x = Random.Range(0, x-1);
        point.y = Random.Range(0, y-1);

        for (float i= point.x; i <= point.x + 1; i++ ) {
            for (float j = point.y; j <= point.y + 1; j++) {
                usePoint.Add(new Vector2(i, j));
            }
        }

        grid.setCricle((int)point.x, (int)point.y, 2);

        cricle.setLocation((int)point.x, (int)point.y);
    }

    public void RamdomPoint(int x, int y, int count) {

        for (int i = 0; i < count; i++)
        {
            Vector2 point;
            do
            {
                point.x = Random.Range(0, x);
                point.y = Random.Range(0, y);
            } 
            while (checkUsePoint(point));

            grid.setGrid((int)point.x, (int)point.y, 1);
            usePoint.Add(point); 
        }

    }

    private bool checkUsePoint(Vector2 vec) {
        foreach (Vector2 vec2 in usePoint) {
            if (vec2.x == vec.x && vec2.y == vec.y) return true;
        }
        return false;
    }


    private void Update()
    {
        if (cricle.checkDone())
        {
            if (time.tooFass()) {

                cricle.resetup();
                cricle.setup();
            } else {
                winPane.Win();
            }
        }
    }

    void UpdateTitleMap()
    {
        for (int x = 0; x < grid.height; x++)
        {
            for (int y = 0; y < grid.width; y++)
            {
                if (!grid.checkvatcan(x, y))
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase2);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileBase);
                }
            }
        }
    }


    void UpdateBoard()
    {

        Vector3 cellSize = tilemap.layoutGrid.cellSize; 
        // Debug.Log(cellSize);
        float mapWidth = grid.width * cellSize.x; 
        float mapHeight = grid.height * cellSize.y; 

        Debug.Log(" " + mapWidth + " " + mapHeight + " ");
        
        Vector3 mapCenter = tilemap.transform.position + new Vector3(
            grid.height * cellSize.x / 2f,
            grid.width * cellSize.y / 2f,
            0
        );

        Vector3 mapCentercamera = tilemap.transform.position + new Vector3(
            grid.height * cellSize.x / 2f,
            grid.width * cellSize.y / 2f,
            -10
        );

        Debug.Log(" " + mapCenter);

        
        board.UpdateLocation(mapHeight, mapWidth, mapCenter);
        camera.UpdateCamera(mapCentercamera);
    }


    public bool checkPos(int x, int y, bool state)
    {
        if (grid.checkPos(x, y) == false) return false;
        if (grid.checkvatcan(x, y) == false) return false;
        if (grid.checkPeace(x, y) == false) {

            if (state == false) return false;
            return checkAnotherPeace(x, y);
        }
        
        return true;

    }

    public bool checkAnotherPeace(int x, int y)
    {
        return cricle.askAnotherPeace(x, y);
    }


    public void setGrid(int x, int y, int to)
    {
        grid.setGrid(x, y, to);
    }

}
