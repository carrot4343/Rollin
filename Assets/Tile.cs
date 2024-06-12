using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class Tile : MonoBehaviour
    {
        private int posX;
        private int posZ;
        private int[] pos = new int[2];

        public bool isOccupied = false;

        public void Setposition(int x, int z)
        {
            posX = x;
            posZ = z;
            pos[0] = x;
            pos[1] = z;
        }

        public int[] GetPositionInt()
        {
            return pos;
        }

        public Vector3 Getposition()
        {
            return new Vector3(posX * 2, 1.0f, posZ * 2);
        }
    }
}

