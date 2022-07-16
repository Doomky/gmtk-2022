using System;
using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Module
{
    public class FireModule : MonoBehaviour
    {
        private List<IFireInterface> _fireInterface;

        private void Start()
        {
            this._fireInterface = new();
            Component[] myComponents = this.gameObject.GetComponents(typeof(IFireInterface));
            foreach (Component myComponent in myComponents)
            {
                this._fireInterface.Add((IFireInterface)myComponent);
                Debug.Log(myComponent.GetType().ToString());
            }
        }
        
        public void Fire1()
        {
            foreach (IFireInterface fireInterface in this._fireInterface)
            {
                fireInterface.Fire1();
            }
        }

        public void Fire2()
        {
            foreach (IFireInterface fireInterface in this._fireInterface)
            {
                fireInterface.Fire2();
            }
        }
    }
}