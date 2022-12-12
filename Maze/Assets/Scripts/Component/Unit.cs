using UnityEngine;


namespace Maze
{
    public abstract class Unit : MonoBehaviour
    {     
        
        public float _speed = 3.0f;
              
        public abstract void Move(float x, float y, float z);

    }
}
