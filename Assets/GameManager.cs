using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

namespace ObserverSpace
{
    public class Subject
    {
        List<Observer> observers = new List<Observer>();

        public void Notify(GameManager gameManager)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify(gameManager);
            }
        }

        public void AddObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }
    }


    public class GameManager : MonoBehaviour
    {
        public int whoseTurn; //0: Player Turn, 1: Enemy Turn
        public int turnCount;
        private List<GameObject> playerSideList, enemySideList1, enemySideList2;
        public GameObject map;
        public GameObject playerObject;
        public GameObject enemyObject1, enemyObject2;
        private int[] playerPos;
        Player player;
        Enemy enemy1, enemy2;

        Subject subject = new Subject();
        
        public void Start()
        {
            player = new Player(playerObject);
            enemy1 = new Enemy(enemyObject1);
            enemy2 = new Enemy(enemyObject2);
            playerSideList = new List<GameObject>()
            {
                playerObject.transform.GetChild(0).gameObject,
                playerObject.transform.GetChild(1).gameObject,
                playerObject.transform.GetChild(2).gameObject,
                playerObject.transform.GetChild(3).gameObject,
                playerObject.transform.GetChild(4).gameObject,
                playerObject.transform.GetChild(5).gameObject
            };
            enemySideList1 = new List<GameObject>()
            {
                enemyObject1.transform.GetChild(0).gameObject,
                enemyObject1.transform.GetChild(1).gameObject,
                enemyObject1.transform.GetChild(2).gameObject,
                enemyObject1.transform.GetChild(3).gameObject,
                enemyObject1.transform.GetChild(4).gameObject,
                enemyObject1.transform.GetChild(5).gameObject
            };
            enemySideList2 = new List<GameObject>()
            {
                enemyObject2.transform.GetChild(0).gameObject,
                enemyObject2.transform.GetChild(1).gameObject,
                enemyObject2.transform.GetChild(2).gameObject,
                enemyObject2.transform.GetChild(3).gameObject,
                enemyObject2.transform.GetChild(4).gameObject,
                enemyObject2.transform.GetChild(5).gameObject
            };

            playerPos = player.GetPlayerPos();

            turnCount = 1;
            whoseTurn = 0;

            subject.AddObserver(player);
            subject.AddObserver(enemy1);
            subject.AddObserver(enemy2);

        }

        public int[] GetPlayerPos()
        {
            return playerPos;
        }

        public void SetPlayerPos(int x, int y)
        {
            player.SetPlayerPos(x, y);
        }

        void Update()
        {
            playerPos = player.GetPlayerPos();
            subject.Notify(this.GetComponent<GameManager>());
        }

        public void TurnManage()
        {
            if(whoseTurn == 0)
            {
                whoseTurn = 1;
                turnCount += 1;
            }
            else if(whoseTurn == 1)
            {
                whoseTurn = 0;
            }
        }

        public GameObject GetPlayerTopObject()
        {
            if (playerSideList[0].transform.position.y > playerSideList[1].transform.position.y &&
                playerSideList[0].transform.position.y > playerSideList[2].transform.position.y &&
                playerSideList[0].transform.position.y > playerSideList[3].transform.position.y &&
                playerSideList[0].transform.position.y > playerSideList[4].transform.position.y &&
                playerSideList[0].transform.position.y > playerSideList[5].transform.position.y)
            {
                return playerSideList[0];
            }
            else if (playerSideList[1].transform.position.y > playerSideList[0].transform.position.y &&
                     playerSideList[1].transform.position.y > playerSideList[2].transform.position.y &&
                     playerSideList[1].transform.position.y > playerSideList[3].transform.position.y &&
                     playerSideList[1].transform.position.y > playerSideList[4].transform.position.y &&
                     playerSideList[1].transform.position.y > playerSideList[5].transform.position.y)
            {
                return playerSideList[1];
            }
            else if (playerSideList[2].transform.position.y > playerSideList[0].transform.position.y &&
                     playerSideList[2].transform.position.y > playerSideList[1].transform.position.y &&
                     playerSideList[2].transform.position.y > playerSideList[3].transform.position.y &&
                     playerSideList[2].transform.position.y > playerSideList[4].transform.position.y &&
                     playerSideList[2].transform.position.y > playerSideList[5].transform.position.y)
            {
                return playerSideList[2];
            }
            else if (playerSideList[3].transform.position.y > playerSideList[0].transform.position.y &&
                     playerSideList[3].transform.position.y > playerSideList[1].transform.position.y &&
                     playerSideList[3].transform.position.y > playerSideList[2].transform.position.y &&
                     playerSideList[3].transform.position.y > playerSideList[4].transform.position.y &&
                     playerSideList[3].transform.position.y > playerSideList[5].transform.position.y)
            {
                return playerSideList[3];
            }
            else if (playerSideList[4].transform.position.y > playerSideList[0].transform.position.y &&
                     playerSideList[4].transform.position.y > playerSideList[1].transform.position.y &&
                     playerSideList[4].transform.position.y > playerSideList[2].transform.position.y &&
                     playerSideList[4].transform.position.y > playerSideList[3].transform.position.y &&
                     playerSideList[4].transform.position.y > playerSideList[5].transform.position.y)
            {
                return playerSideList[4];
            }
            else
            {
                return playerSideList[5];
            }
        }
        public GameObject GetEnemy1TopObject()
        {
            if (enemySideList1[0].transform.position.y > enemySideList1[1].transform.position.y &&
                enemySideList1[0].transform.position.y > enemySideList1[2].transform.position.y &&
                enemySideList1[0].transform.position.y > enemySideList1[3].transform.position.y &&
                enemySideList1[0].transform.position.y > enemySideList1[4].transform.position.y &&
                enemySideList1[0].transform.position.y > enemySideList1[5].transform.position.y)
            {
                return enemySideList1[0];
            }
            else if (enemySideList1[1].transform.position.y > enemySideList1[0].transform.position.y &&
                     enemySideList1[1].transform.position.y > enemySideList1[2].transform.position.y &&
                     enemySideList1[1].transform.position.y > enemySideList1[3].transform.position.y &&
                     enemySideList1[1].transform.position.y > enemySideList1[4].transform.position.y &&
                     enemySideList1[1].transform.position.y > enemySideList1[5].transform.position.y)
            {
                return enemySideList1[1];
            }
            else if (enemySideList1[2].transform.position.y > enemySideList1[0].transform.position.y &&
                     enemySideList1[2].transform.position.y > enemySideList1[1].transform.position.y &&
                     enemySideList1[2].transform.position.y > enemySideList1[3].transform.position.y &&
                     enemySideList1[2].transform.position.y > enemySideList1[4].transform.position.y &&
                     enemySideList1[2].transform.position.y > enemySideList1[5].transform.position.y)
            {
                return enemySideList1[2];
            }
            else if (enemySideList1[3].transform.position.y > enemySideList1[0].transform.position.y &&
                     enemySideList1[3].transform.position.y > enemySideList1[1].transform.position.y &&
                     enemySideList1[3].transform.position.y > enemySideList1[2].transform.position.y &&
                     enemySideList1[3].transform.position.y > enemySideList1[4].transform.position.y &&
                     enemySideList1[3].transform.position.y > enemySideList1[5].transform.position.y)
            {
                return enemySideList1[3];
            }
            else if (enemySideList1[4].transform.position.y > enemySideList1[0].transform.position.y &&
                     enemySideList1[4].transform.position.y > enemySideList1[1].transform.position.y &&
                     enemySideList1[4].transform.position.y > enemySideList1[2].transform.position.y &&
                     enemySideList1[4].transform.position.y > enemySideList1[3].transform.position.y &&
                     enemySideList1[4].transform.position.y > enemySideList1[5].transform.position.y)
            {
                return enemySideList1[4];
            }
            else
            {
                return enemySideList1[5];
            }
        }
        public GameObject GetEnemy2TopObject()
        {
            if (enemySideList2[0].transform.position.y > enemySideList2[1].transform.position.y &&
                enemySideList2[0].transform.position.y > enemySideList2[2].transform.position.y &&
                enemySideList2[0].transform.position.y > enemySideList2[3].transform.position.y &&
                enemySideList2[0].transform.position.y > enemySideList2[4].transform.position.y &&
                enemySideList2[0].transform.position.y > enemySideList2[5].transform.position.y)
            {
                return enemySideList2[0];
            }
            else if (enemySideList2[1].transform.position.y > enemySideList2[0].transform.position.y &&
                     enemySideList2[1].transform.position.y > enemySideList2[2].transform.position.y &&
                     enemySideList2[1].transform.position.y > enemySideList2[3].transform.position.y &&
                     enemySideList2[1].transform.position.y > enemySideList2[4].transform.position.y &&
                     enemySideList2[1].transform.position.y > enemySideList2[5].transform.position.y)
            {
                return enemySideList2[1];
            }
            else if (enemySideList2[2].transform.position.y > enemySideList2[0].transform.position.y &&
                     enemySideList2[2].transform.position.y > enemySideList2[1].transform.position.y &&
                     enemySideList2[2].transform.position.y > enemySideList2[3].transform.position.y &&
                     enemySideList2[2].transform.position.y > enemySideList2[4].transform.position.y &&
                     enemySideList2[2].transform.position.y > enemySideList2[5].transform.position.y)
            {
                return enemySideList2[2];
            }
            else if (enemySideList2[3].transform.position.y > enemySideList2[0].transform.position.y &&
                     enemySideList2[3].transform.position.y > enemySideList2[1].transform.position.y &&
                     enemySideList2[3].transform.position.y > enemySideList2[2].transform.position.y &&
                     enemySideList2[3].transform.position.y > enemySideList2[4].transform.position.y &&
                     enemySideList2[3].transform.position.y > enemySideList2[5].transform.position.y)
            {
                return enemySideList2[3];
            }
            else if (enemySideList2[4].transform.position.y > enemySideList2[0].transform.position.y &&
                     enemySideList2[4].transform.position.y > enemySideList2[1].transform.position.y &&
                     enemySideList2[4].transform.position.y > enemySideList2[2].transform.position.y &&
                     enemySideList2[4].transform.position.y > enemySideList2[3].transform.position.y &&
                     enemySideList2[4].transform.position.y > enemySideList2[5].transform.position.y)
            {
                return enemySideList2[4];
            }
            else
            {
                return enemySideList2[5];
            }
        }
    }

}
