using System;
using UnityEngine;

public class GridElement : MonoBehaviour
{
   public int columns;
   public int rows;
   public float cellSize = 1f;
   public Color gridColor = Color.green;
   
          private void OnDrawGizmos()
          {
              Gizmos.color = gridColor;
              float worldScreenHeight = Camera.main.orthographicSize * 2f;
              float worldScreenWidth = Camera.main.aspect * worldScreenHeight;
              
              for (int x = 0; x <= worldScreenWidth; x++)
              {
                  Vector3 start = transform.position + new Vector3(x * cellSize, 0, 0);
                  Vector3 end = transform.position + new Vector3(x * cellSize, worldScreenHeight * cellSize, 0);
                  Gizmos.DrawLine(start, end);
              }
              
              for (int y = 0; y <= worldScreenHeight; y++)
              {
                  Vector3 start = transform.position + new Vector3(0, y * cellSize, 0);
                  Vector3 end = transform.position + new Vector3(worldScreenWidth * cellSize, y * cellSize, 0);
                  Gizmos.DrawLine(start, end);
              }
          }
}
