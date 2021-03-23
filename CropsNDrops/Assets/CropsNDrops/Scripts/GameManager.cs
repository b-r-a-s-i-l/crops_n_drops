using CropsNDrops.Scripts.Garden;
using CropsNDrops.Scripts.Inventory;
using CropsNDrops.Scripts.Player;
using CropsNDrops.Scripts.ScoreMeter;
using CropsNDrops.Scripts.Tools;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CropsNDrops.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        
        [Header("Garden Size")]
        public int width;
        public int height;
        
        [Header("Score")]
        public int goal;
        
        [Header("Managers")]
        [SerializeField] private PlayerController _player = default;
        [SerializeField] private Camera _mainCamera = default;
        [SerializeField] private GardenManager _garden = default;
        [SerializeField] private ItemManager _inventory = default;
        [SerializeField] private ScoreManager _score = default;
        [SerializeField] private PanelManager _panel = default;
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            
            Initializes();
        }

        private void Initializes()
        {
            if (_garden)
            {
                _garden.Initialize(width, height);
            }
            if (_inventory)
            {
                _inventory.Initialize();
                _inventory.OnGameOver += OpenPanel;
            }
            if (_score)
            {
                _score.Initialize(goal);
                _score.OnGoal += OpenPanel;
            }
            if (_panel)
            {
                _panel.Initialize();
            }
            if (_player)
            {
                _player.Initialize();
            }
        }

        private void OpenPanel()
        {
            _inventory.gameObject.SetActive(false);
            _score.gameObject.SetActive(false);
            _panel.gameObject.SetActive(true);
        }
        
        private void ClosePanel()
        {
            _inventory.gameObject.SetActive(true);
            _score.gameObject.SetActive(true);
            _panel.gameObject.SetActive(false);
        }

        private void Pause()
        {
            //
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void CallScene(int id)
        {
            SceneManager.LoadScene(id, LoadSceneMode.Single);
        }

        public PlayerController Player
        {
            get { return _player; }
        }
        
        public GardenManager Garden
        {
            get { return _garden; }
        }

        public Camera MainCamera
        {
            get { return _mainCamera; }
        }
    }
}
