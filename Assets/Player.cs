using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Map;

namespace ObserverSpace
{
    public class Player : Observer
    {
        private int walkCount = 100; //Test를 위해 임시로 값 고정. 
        //private int playerPower = 2;
        private int[] playerPos = new int[2];
        private GameObject topObject;
        GameObject playerObject;


        public Player(GameObject playerObject)
        {
            this.playerObject = playerObject;
        }

        public override void OnNotify(GameManager gameManager)
        {
            topObject = gameManager.GetPlayerTopObject();
            if (gameManager.whoseTurn == 0)
            {
                Debug.Log("PlayerOnNotify");

                if (walkCount > 0)
                {
                    InputManage(gameManager);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameManager.TurnManage();
                }
            }
        }

        public void AddWalkCount(int addNum)
        {
            walkCount += addNum;
        }

        public void SubtractWalkCount(int subtractNum)
        {
            walkCount -= subtractNum;
        }

        private void InputManage(GameManager gameManager)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                if(gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1] + 1) != null)
                {                    
                    playerObject.transform.Rotate(90, 0, 0, Space.World);
                    playerPos[1] += 1;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().isOccupied = false;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1] + 1).GetComponent<Tile>().isOccupied = true;
                    playerObject.transform.position = gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().Getposition();
                    SubtractWalkCount(1);
                }
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                if(gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0] + 1, playerPos[1]) != null)
                {
                    playerObject.transform.Rotate(0, 0, -90, Space.World);
                    playerPos[0] += 1;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().isOccupied = false;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0] + 1, playerPos[1]).GetComponent<Tile>().isOccupied = true;
                    playerObject.transform.position = gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().Getposition();
                    SubtractWalkCount(1);
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1] - 1) != null)
                {
                    playerObject.transform.Rotate(-90, 0, 0, Space.World);
                    playerPos[1] -= 1;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().isOccupied = false;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1] - 1).GetComponent<Tile>().isOccupied = true;
                    playerObject.transform.position = gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().Getposition();
                    SubtractWalkCount(1);
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0] - 1, playerPos[1]) != null)
                {
                    playerObject.transform.Rotate(0, 0, 90, Space.World);
                    playerPos[0] -= 1;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().isOccupied = false;
                    //gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0] - 1, playerPos[1]).GetComponent<Tile>().isOccupied = true;
                    playerObject.transform.position = gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(playerPos[0], playerPos[1]).GetComponent<Tile>().Getposition();
                    SubtractWalkCount(1);
                }
            }
        }

        public int[] GetPlayerPos()
        {
            return playerPos;
        }

        public void SetPlayerPos(int x, int y)
        {
            playerPos[0] = x;
            playerPos[1] = y;
        }
    }

    public abstract class PlayerEvents
    {

    }

}

