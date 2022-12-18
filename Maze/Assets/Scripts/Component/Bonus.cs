using UnityEngine;
using static UnityEngine.Random;

namespace Maze
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float ActiveDis;

        private bool _isInteractable;
        protected Color _color;
       
        public float _heightfly;
        

        protected bool IsInteractable 
        { 
            get => _isInteractable;
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }        

    private void OnTriggerEnter(Collider other)
        {
           if (!IsInteractable || !other.CompareTag("Player")) { return; }

            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();
        public abstract void Update();

        private void Start()
        {
            IsInteractable = true;
            _color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
                renderer.material.color = _color;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "print.jpg", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
            #if UNITY_EDITOR
            Transform t = transform;

            var flat = new Vector3(ActiveDis, 0, ActiveDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5);
            #endif
        }

    }

}

