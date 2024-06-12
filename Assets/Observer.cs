using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverSpace
{
    public abstract class Observer
    {
        public abstract void OnNotify(GameManager gameManager);
    }
}


