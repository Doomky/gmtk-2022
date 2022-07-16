using System;
using System.Collections.Generic;
using Code.Interfaces;
using Code.Module;
using UnityEngine;

namespace Code.Entities.Enemy
{
    public class GameEnemy : MonoBehaviour
    {
        private FireModule _fireModule;

        private void Start()
        {
            if (this._fireModule == null)
            {
               this._fireModule = this.gameObject.AddComponent<FireModule>();
            }
        }
    }
}