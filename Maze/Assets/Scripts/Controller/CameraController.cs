using UnityEngine;
using System;
using TMPro;

namespace Maze
{
    public sealed class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController (Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void Update()
        {
            _mainCamera.position = _player.position + _offset;
        }
    }

}

