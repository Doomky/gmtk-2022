using System;
using Code.Entities.Projectiles;
using Code.Enums;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Core.Components
{
    /// <summary>
    /// Responsible for managing health (takedamage etc.)
    /// </summary>
    public class HealthComponent : MonoBehaviour
    {
        public float Health = 1000;
        //should move this to the entities
        public HealthStates HealthState;
        private Collider2D _collider;

        private void Start()
        {
            this.HealthState = HealthStates.Alive;
            this._collider = GetComponent<Collider2D>();
            if (this._collider == null)
            {
                throw new("Any entity that has a health component requires a 2D collider");
            }
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("Collision");
            GiveDamageComponent gameProjectile = col.gameObject.GetComponent<GiveDamageComponent>();
            if (gameProjectile == null)
            {
                return;
            }
            
            this.Health -= gameProjectile.Damage;
            if (this.Health < 0)
            {
                this.HealthState = HealthStates.Dead;
            }
        }
    }
}