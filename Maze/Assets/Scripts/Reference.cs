using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class Reference
    {
        private Player _player;
        private Camera _mainCamera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private Canvas _canvas;
        private Button _restartGame;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }

                return _player;
            }
        }       

        public Button RestartGame
        {
            get
            {
                if (_restartGame == null)
                {
                    var gameObject = Resources.Load<Button>("RestartGame");
                    _restartGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartGame;
            }
        }

        public Canvas Canvas
        {
            get
            { 
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            { 
                if (_bonuse == null)
                {
                    var gameObject = Resources.Load<GameObject>("Bonuse");
                    _bonuse = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _bonuse;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }

}

