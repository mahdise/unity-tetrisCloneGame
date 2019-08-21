using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisObject : MonoBehaviour
{

  float lastFall = 0f;
    public static bool istheGameOver = false;
   
 public static bool IsGameOver()
    {
        return istheGameOver;


    }
    // Start is called before the first frame update
    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("Game Over");

            Destroy(gameObject);
            istheGameOver = true;
           
        }
        
    }

  
   

    void Update()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(new Vector3(0, 0, 90));
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                MatrixGrid.deleteFullRows();

                //new 
                //if (FindObjectOfType<GameObject>().lat())
                //{

                //    FindObjectOfType<GameObject>().GameOver();
                //}

                // Spawn next Group
                    FindObjectOfType<Spawner>().spawnRandom();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }
    }


    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = MatrixGrid.RoundVector(child.position);

            // Not inside Border?
            if (!MatrixGrid.IsInsideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (MatrixGrid.grid[(int)v.x, (int)v.y] != null &&
                MatrixGrid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }



    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < MatrixGrid.column; ++y)
            for (int x = 0; x < MatrixGrid.row; ++x)
                if (MatrixGrid.grid[x, y] != null)
                    if (MatrixGrid.grid[x, y].parent == transform)
                        MatrixGrid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = MatrixGrid.RoundVector(child.position);
            MatrixGrid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
