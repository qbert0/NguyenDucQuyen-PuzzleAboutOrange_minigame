using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private void Awake() {
        
    }
    public int height;
    public int width;

    int[,] grid ;

    public void Init(int height, int width) {
        grid = new int[height, width];
        this.height = height;
        this.width = width;
        for (int x = 0; x < height; x++) {
            for (int y = 0; y < width; y++) {
                grid[x, y] = 0;
            }
        }
    }

    public void setGrid (int x, int y, int to) {
        if (checkPos(x,y) == false) return;
        grid[x, y] = to;
    }

    public int GetGrid (int x, int y) {
        if(checkPos(x,y) == false) return 1;
        return grid[x, y];
    }

    public bool checkPos (int x, int y) {
        if (x < 0 || x >= height ) {
            return false;
        }
        if (y < 0 || y >= width) {
            return false;
        }
        return true;   
    }

    public bool checkvatcan (int x, int y) {
        if (grid[x,y] == 1) return false;
        return true;
    }

    public bool checkPeace (int x, int y) {
        if (grid[x,y] == 2) return false;
        return true;
    }


    public void setCricle(int x, int y, int to) {
        for (int i = x; i <= x+ 1; i++) {
            for (int j = y; j <= y+1; j++) {
                setGrid(i,j,to);
            }
        }
    }
}
