using UnityEngine;

namespace Maze
{
    public class InputController: IExecute
    {
        private readonly Unit _player;

        public InputController(Unit player) { _player = player; }

        public void Update()
        {            
            _player.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }

}

