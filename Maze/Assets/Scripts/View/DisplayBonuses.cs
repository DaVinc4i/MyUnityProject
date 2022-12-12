using UnityEngine;
using UnityEngine.UI;
using System;

namespace Maze
{
    public sealed class DisplayBonuses
{
        private Text _bonuseLabel;
        public DisplayBonuses(GameObject bonus)
        {
            _bonuseLabel = bonus.GetComponentInChildren<Text>();
            _bonuseLabel.text = String.Empty;
        } 

        public void Display (int value)
        {
            _bonuseLabel.text = $"Вы набрали {value}";
        }
}

}


