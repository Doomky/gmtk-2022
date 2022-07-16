using System;
using UnityEngine;

namespace Code.Entities.Projectiles
{
    /// <summary>
    /// Spawns projectiles, for anything (turrets, enemies, player)
    /// </summary>
    public class GameProjectile : MonoBehaviour
    {
        public GameObject Parent;
        public float Cost;

        private void Start()
        {
            
        }
    }
}