using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Map;

namespace ObserverSpace
{
    public class Enemy : Observer
    {
        GameObject enemyObject;
        EnemyEvents enemyEvent;
        TutorialMap gridMap;
        //���� A* ��ã�� ����
        private GameObject destination, start;
        private List<GameObject> path = new List<GameObject>();
        private List<GameObject> neighborGridCell = new List<GameObject>();
        private List<float> gCost = new List<float>();
        private List<float> hCost = new List<float>();
        private List<float> fCost = new List<float>();
        private int pathCount = -1;

        private int[] enemyPosition = new int[2];
        private float gCostSum = 0;

        private List<GameObject> pathToPlayer = new List<GameObject>();

        public Enemy(GameObject enemyObject)
        {
            this.enemyObject = enemyObject;
        }

        public override void OnNotify(GameManager gameManager)
        {
            destination = gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(gameManager.GetPlayerPos()[0], gameManager.GetPlayerPos()[1]);


            if (gameManager.turnCount <= 1)
            {
                gridMap = gameManager.map.GetComponent<TutorialMap>();
                enemyPosition[0] = (int)enemyObject.transform.position.x / 2;
                enemyPosition[1] = (int)enemyObject.transform.position.z / 2;
            }
            gameManager.map.GetComponent<TutorialMap>().GetGridCellInfo(enemyPosition[0], enemyPosition[1]).GetComponent<Tile>().isOccupied = true;

            pathToPlayer = PathFindWithAstar(enemyPosition[0], enemyPosition[1]);

            enemyObject.transform.position = pathToPlayer[0].transform.position + new Vector3(0.0f, 0.75f, 0.0f);

            path.Clear();
            pathToPlayer.Clear();

            if (gameManager.whoseTurn == 1)
            {
                Debug.Log("EnemyOnNotify");
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    gameManager.TurnManage();
                }
            }
        }

        public List<GameObject> PathFindWithAstar(int startX, int startY)
        {
            pathCount += 1;
            start = gridMap.GetGridCellInfo(startX, startY);

            neighborGridCell.Add(gridMap.GetGridCellInfo(startX, startY));
            if (gridMap.GetGridCellInfo(startX + 1, startY).GetComponent<Tile>().isOccupied == false
                && gridMap.GetGridCellInfo(startX + 1, startY).GetComponent<Tile>() != null)//������ cell �� ����ְų� null�� �ƴϸ�
            {
                neighborGridCell.Add(gridMap.GetGridCellInfo(startX + 1, startY));//List�� �߰�
            }
            if (gridMap.GetGridCellInfo(startX, startY + 1).GetComponent<Tile>().isOccupied == false
                && gridMap.GetGridCellInfo(startX, startY + 1).GetComponent<Tile>() != null)//���� cell �� ����ְų� null�� �ƴϸ�
            {
                neighborGridCell.Add(gridMap.GetGridCellInfo(startX, startY + 1));
            }
            if(startX > 0)
            {
                if (gridMap.GetGridCellInfo(startX - 1, startY).GetComponent<Tile>().isOccupied == false
                && gridMap.GetGridCellInfo(startX - 1, startY).GetComponent<Tile>() != null)//���� cell �� ����ְų� null�� �ƴϸ�
                {
                    neighborGridCell.Add(gridMap.GetGridCellInfo(startX - 1, startY));
                }
            }
            if(startY > 0)
            {
                if (gridMap.GetGridCellInfo(startX, startY - 1).GetComponent<Tile>().isOccupied == false
                && gridMap.GetGridCellInfo(startX, startY - 1).GetComponent<Tile>() != null)//�Ʒ��� cell �� ����ְų� null�� �ƴϸ�
                {
                    neighborGridCell.Add(gridMap.GetGridCellInfo(startX, startY - 1));
                }
            }

            for (int j = 1; j < neighborGridCell.Count; j++)
            {
                gCost.Add((neighborGridCell[0].transform.position - neighborGridCell[j].transform.position).magnitude);//g(x)
                hCost.Add((neighborGridCell[j].transform.position - destination.transform.position).magnitude); // h(x)
                fCost.Add(gCost[j - 1] + hCost[j - 1]);//f(x)
            }
            var a = fCost.IndexOf(fCost.Min());
            path.Add(neighborGridCell[fCost.IndexOf(fCost.Min()) + 1]);//��� ��忡 �߰�
            gCostSum = gCostSum + gCost[fCost.IndexOf(fCost.Min())];//��������� ������ gCost �� �ջ�

            neighborGridCell.Clear();
            fCost.Clear();
            gCost.Clear();
            hCost.Clear();

            if (path.Contains(destination) == true)
            {
                gCostSum = 0;
                pathCount = 0;
                return path;
            }

            PathFindWithAstar(path[pathCount].GetComponent<Tile>().GetPositionInt()[0], path[pathCount].GetComponent<Tile>().GetPositionInt()[1]);
            return path;
        }
    }

    public abstract class EnemyEvents
    {

    }
}
