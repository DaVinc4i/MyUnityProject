using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace Maze
{
    public class ListExecuteObjectController: IEnumerable, IEnumerator
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;
        private Bonus _current;

        public ListExecuteObjectController()
        {
            var interactiveObjects = Object.FindObjectsOfType<Bonus>();
            for (var i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    AddExecuteObject(interactiveObject);
                }
            }
        }
        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObject == null)
            {
                _interactiveObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }

        public IExecute this[int index] { get => _interactiveObject[index]; private set => _interactiveObject[index] = value; }

        public int Length  => _interactiveObject.Length;     

        
        public bool MoveNext() 
        {
            if (_index == _interactiveObject.Length-1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObject[_index];

        public IEnumerator GetEnumerator() { return this; }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator();}

    }

}

