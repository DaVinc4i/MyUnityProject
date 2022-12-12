using UnityEngine;
using System;

using Random = UnityEngine.Random;

namespace Maze
{
    public sealed class GoodBonus : Bonus, IFlay, IRotation
    {
        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };
        
        public float _speedRotation;


        private void Awake()
        {              
            _heightfly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);

        }               
        
        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public override void Execute()
        {
            if(!IsInteractable) { return; }
            Flay();
            Rotation();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f +
                Mathf.PingPong(Time.time, _heightfly), transform.localPosition.z);
        }               

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }

}

