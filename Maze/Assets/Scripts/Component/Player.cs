using UnityEngine;

namespace Maze
{
    public sealed class Player : Unit
    {
        private Rigidbody _rigibody;

        private void Start()
        {
            _rigibody= GetComponent<Rigidbody>();
        }
        public override void Move(float x, float y, float z)
        {
            _rigibody.AddForce(new Vector3(x, y, z)*_speed);
           
        }
    }

}

