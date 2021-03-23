using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.ScoreMeter;
using UnityEngine;
using UnityEngine.UI;

namespace CropsNDrops.Scripts
{
	public class PanelManager : MonoBehaviour
	{
		[SerializeField] private Text _text = default;
		[SerializeField] private ItemManager _itemManager = default;
		[SerializeField] private ScoreManager _scoreManager = default;

		public void Initialize()
		{
			_itemManager.OnGameOver += GameOverPanel;
			_scoreManager.OnGoal += GoalPanel;
		}

		private void GoalPanel()
		{
			_text.text = "Your basket is full of vegetables! You won!";
		}

		private void GameOverPanel()
		{
			_text.text = "Your blocks are finished ... You lost!";
		}
	}
}