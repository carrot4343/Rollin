using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ObserverSpace;

namespace Map
{
    public class TutorialMap : MonoBehaviour
    {
        private int map_height = 10;
        private int map_width = 10;
        private float gridCellSize = 2.0f;
        public int[] startLocation = new int[2];
        public GameObject gameManager;

        [SerializeField] private GameObject tilePrefab1;
        [SerializeField] private GameObject tilePrefab2;
        private GameObject[,] gridMap1;

        private void CreateGrid()
        {
            gridMap1 = new GameObject[map_height, map_width];

            for (int j = 0; j < map_height; j++)
            {
                for (int i = 0; i < map_width; i++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        gridMap1[i, j] = Instantiate(tilePrefab1, new Vector3(i * gridCellSize, 0.25f, j * gridCellSize), Quaternion.identity);
                    }
                    else
                    {
                        gridMap1[i, j] = Instantiate(tilePrefab2, new Vector3(i * gridCellSize, 0.25f, j * gridCellSize), Quaternion.identity);
                    }
                    gridMap1[i, j].GetComponent<Tile>().Setposition(i, j);
                    gridMap1[i, j].transform.parent = transform;
                    gridMap1[i, j].gameObject.name = "Grid Cell (" + i + "," + j + ")";
                }
            }
        }

        public GameObject GetGridCellInfo(int x, int y)
        {
            return gridMap1[x, y];
        }

        private void Start()
        {
            CreateGrid();
            gameManager.GetComponent<GameManager>().playerObject.transform.position = GetGridCellInfo(startLocation[0], startLocation[1]).transform.position + new Vector3(0.0f, 0.75f, 0.0f);
            gameManager.GetComponent<GameManager>().SetPlayerPos(startLocation[0], startLocation[1]);
        }

        void Update()
        {
            
        }
    }

}
