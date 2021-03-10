using CropsNDrops.Scripts.Garden;
using CropsNDrops.Scripts.UI;
using UnityEngine;

namespace CropsNDrops.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}
        
        [Header("Garden Size")]
        public int width;
        public int height;
        
        [Header("Managers")]
        [SerializeField] private Camera _camera = default;
        [SerializeField] private GardenManager _garden = default;
        [SerializeField] private ItemManager _inventory = default;
        

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
            
            _garden.Initialize(width, height);
        }

        public GardenManager Garden
        {
            get { return _garden; }
        }

        public Camera Camera
        {
            get { return _camera; }
        }
    }
}
