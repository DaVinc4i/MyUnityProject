using UnityEngine;
using System;

using Random = UnityEngine.Random;

namespace Maze
{
    public sealed class BadBonus : Bonus
    {        
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        private Material _material;

        private void Awake()
        {         
            _heightfly = Random.Range(1.0f, 5.0f);
            _material = GetComponent<Renderer>().material;
        }
              

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public override void Update() 
        {
            if (!IsInteractable) { return; }
            Flay();
            Flicker();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f +
                Mathf.PingPong(Time.time, _heightfly), transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 
                Mathf.PingPong(Time.time, 1.0f));
        }
    }

}
