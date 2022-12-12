using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Maze
{
    public sealed class Main : MonoBehaviour, IDisposable
    {        
        private ListExecuteObjectController _executeObject;
        private DisplayBonuses _displayBonuses;
        private DisplayEndGame _displayEndGame;
        private int _countBonuses;
        
        private InputController _inputController;       
        
        private CameraController _cameraController;
        private Reference _reference;

        private void Awake()
        {            
            _executeObject = new ListExecuteObjectController();

            _reference = new Reference();

            Unit player = null;

            if (player == null)
            {
                player = _reference.Player;
            }

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _executeObject.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _executeObject.AddExecuteObject(_inputController);
            }

            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);

            _reference.RestartGame.onClick.AddListener(RestartGame);
            _reference.RestartGame.gameObject.SetActive(false);

            foreach (var o in _executeObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }
            } 
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartGame.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        private void Update()
        {
            for (int i = 0; i < _executeObject.Length; i++)
            {
               var executeObject = _executeObject[i];
               if (executeObject == null) { continue; }

                executeObject.Execute();
            }
        }

        public void Dispose ()
        {
            foreach (var o in _executeObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
            }

        }


    }

}

