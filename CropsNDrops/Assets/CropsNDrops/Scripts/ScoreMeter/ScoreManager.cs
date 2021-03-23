using System;
using System.Collections;
using CropsNDrops.Scripts.Garden.Plants;
using UnityEngine;
using UnityEngine.UI;

namespace CropsNDrops.Scripts.ScoreMeter
{
	public class ScoreManager : MonoBehaviour
	{
		public delegate void ScoreEvent();
		public event ScoreEvent OnGoal;
		
		[SerializeField] private Slider _slider = default;
		[SerializeField] private int _score = 0;
		[SerializeField] private int _goal = 400;

		private void Update()
		{
			if (_score >= _goal)
			{
				Goal();
			}
		}

		public void Initialize(int goal)
		{
			_goal = goal;
			_slider.minValue = _score;
			_slider.maxValue = _goal;
			GameManager.Instance.Player.PutInBasket += ReceivePlant;
		}

		private void UpdateScoreBar(int updateScore)
		{
			_score += updateScore;
			StartCoroutine(UpdadeMeter());
		}

		private IEnumerator UpdadeMeter()
		{
			while (_slider.value < _score)
			{
				float time = 60 * Time.deltaTime;
				_slider.value += time;
				yield return new WaitForEndOfFrame();
			}

			if (_slider.value > _score)
			{
				_slider.value = _score;
			}
		}


		private void ReceivePlant(CropPlant plant)
		{
			UpdateScoreBar(plant.Score);
			Destroy(plant.gameObject);
		}

		protected virtual void Goal()
		{
			OnGoal?.Invoke();
		}
	}
}