using System;
using Code.Entities.Projectiles;
using Code.Interfaces;
using UnityEngine;

namespace Code.Core.Components
{
    public class ProjectileSpawner : MonoBehaviour, IFireInterface
    {
        public GameProjectile GameProjectile;
        private GiveDamageComponent _giveDamageComponent;
        
        private void Start()
        {
            if (this.GameProjectile == null)
            {
                throw new("Projectile spawner needs a GameProjectile to spawn");
            }
        }

        public float Fire1()
        {
            return SpawnProjectile();
        }
        
        public float Fire2()
        {
            return SpawnProjectile();
        }

        private float SpawnProjectile()
        {
            try
            {
                Instantiate(this.GameProjectile, this.transform);
                return this.GameProjectile.Cost;
            }
            catch (Exception e)
            {
                Debug.Log("Object could not be spawned: " + e);
            }

            return 0;
        }

        
    }
}