using System;
using UnityEngine;
using UnityEngine.UI;

namespace CropsNDrops.Scripts.Inventory
{
    public class ItemManager : MonoBehaviour
    {
	    public delegate void ItemManagerEvent();
	    public event ItemManagerEvent OnGameOver;
	    
	    [Header("Definitions")]
	    [SerializeField] private ItemGenerator _generator = default;
	    [SerializeField] private Slot[] _slots = default;
	    [SerializeField] private Text _blockCount = default;


	    [Header("Informations")]
	    [SerializeField] private int _numberOfBlocks = default;

	    private void Update()
	    {
		    if (AllSlotsEmpty)
		    {
			    GameOver();
		    }
	    }
	    
	    public void Initialize()
	    {
		    _blockCount.text = _numberOfBlocks.ToString();  
		    
		    foreach (Slot slot in _slots)
		    { 
			    slot.OnPutItem += GerateItemInSlot;
			    slot.ItemBox = _generator.GerateItemBox(slot);
		    }
	    }

	    private void GerateItemInSlot(Slot slot)
	    {
		    if (_numberOfBlocks > 0)
		    {
			    UpdateNumberOfBlock();
			    slot.ItemBox = _generator.GerateItemBox(slot);
		    }
	    }

	    private void UpdateNumberOfBlock()
	    {
		    _numberOfBlocks--;
		    
		    if (!_blockCount.text.Equals(_numberOfBlocks.ToString()))
		    {
			    _blockCount.text = _numberOfBlocks.ToString();  
		    }  
	    }

	    private bool AllSlotsEmpty
	    {
		    get
		    {
			    int count = 0;
			    foreach (Slot slot in _slots)
			    {
				    if (slot.DontHaveItem)
				    {
					    count++;
				    }
			    }
		    
			    if (count == 3)
			    {
				    return true;
			    }

			    return false;  
		    }
	    }
	    
	    protected virtual void GameOver()
	    {
		    OnGameOver?.Invoke();
	    }
    }
}
