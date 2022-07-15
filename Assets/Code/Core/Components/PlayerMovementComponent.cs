using System;
using UnityEngine;

namespace Assets.Code.Core.Components
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Rigidbody2D _rb = null;

        [UnityEngine.SerializeField]
        private Collider2D _coll = null;

        [UnityEngine.SerializeField]
        private float _forwardForce = 1;

        [UnityEngine.SerializeField]
        private float _backwardForce = 1;

        [UnityEngine.SerializeField]
        private float _rotationSpeed = 10f;

        [UnityEngine.SerializeField]
        private KeyCode _moveForwardKeyCode = KeyCode.W;

        [UnityEngine.SerializeField]
        private KeyCode _moveBackwardKeyCode = KeyCode.S;

        [UnityEngine.SerializeField]
        private KeyCode _rotateLeftKeyCode = KeyCode.A;

        [UnityEngine.SerializeField]
        private KeyCode _rotateRightKeyCode = KeyCode.D;


        [UnityEngine.SerializeField]
        private ParticleSystem[] _backThrustersPS = null;

        [UnityEngine.SerializeField]
        private ParticleSystem _frontLeftPS = null;

        [UnityEngine.SerializeField]
        private ParticleSystem _frontRightPS = null;

        protected void MoveForward()
        {
            this._rb.AddForce(this._forwardForce * this.transform.right, ForceMode2D.Impulse);
        }

        protected void MoveBackward()
        {
            this._rb.AddForce(this._backwardForce * -this.transform.right, ForceMode2D.Impulse);
        }

        protected void RotateLeft()
        {
            this.transform.Rotate(Vector3.forward, this._rotationSpeed * Time.fixedDeltaTime);
        }

        protected void RotateRight()
        {
            this.transform.Rotate(Vector3.forward, -this._rotationSpeed * Time.fixedDeltaTime);
        }

        public enum Movement
        {
            None,
            Forward,
            Backward
        }

        public enum Rotation
        {
            None,
            Left,
            Right
        }

        protected void FixedUpdate()
        {
            Movement movement = this.GetMovement();
            switch (movement)
            {
                case Movement.Forward:
                    {
                        this.MoveForward();
                        break;
                    }
                case Movement.Backward:
                    {
                        this.MoveBackward();
                        break;
                    }
                case Movement.None:
                default:
                    {
                        break;
                    }
            }

            Rotation rotation = this.GetRotation();
            switch (rotation)
            {
                case Rotation.Left:
                    {
                        this.RotateLeft();
                        break;
                    }
                case Rotation.Right:
                    {
                        this.RotateRight();
                        break;
                    }
                case Rotation.None:
                default:
                    {
                        break;
                    }
            }

            this.UpdatePS(movement, rotation);
        }

        private void UpdatePS(Movement movement, Rotation rotation)
        {
            this.UpdatePS(this._backThrustersPS, movement == Movement.Forward);
            this.UpdatePS(this._frontLeftPS, movement == Movement.Backward || rotation == Rotation.Right);
            this.UpdatePS(this._frontRightPS, movement == Movement.Backward || rotation == Rotation.Left);
        }

        private void UpdatePS(ParticleSystem[] particleSystems, bool state)
        {
            int psCount = particleSystems?.Length ?? 0;
            for (int i = 0; i < psCount; i++)
            {
                ParticleSystem particleSystem = particleSystems[i];
                UpdatePS(particleSystem, state);
            }
        }

        private void UpdatePS(ParticleSystem particleSystem, bool state)
        {
            if (state)
            {
                if (!particleSystem.isPlaying)
                {
                    particleSystem.Play();
                }
            }
            else
            {
                if (!particleSystem.isStopped)
                {
                    particleSystem.Stop();
                }
            }
        }

        private Rotation GetRotation()
        {
            if (Input.GetKey(this._rotateLeftKeyCode))
            {
                return Rotation.Left;
            }
            else if (Input.GetKey(this._rotateRightKeyCode))
            {
                return Rotation.Right;
            }
            else
            {
                return Rotation.None;
            }
        }

        private Movement GetMovement()
        {
            if (Input.GetKey(_moveForwardKeyCode))
            {
                return Movement.Forward;
            }
            else if (Input.GetKey(_moveBackwardKeyCode))
            {
                return Movement.Backward;
            }
            else
            {
                return Movement.None;
            }
        }
    }
}
