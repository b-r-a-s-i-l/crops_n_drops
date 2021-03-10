using CropsNDrops.Scripts.Scriptables.Inventory;
using CropsNDrops.Scripts.Scriptables.Inventory.CropsNDrops.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CropsNDrops.Scripts.UI
{
    public class ItemManager : MonoBehaviour
    {
	    [Header("Definitions")]
	    [SerializeField] private Text _blockCount = default;
	    [SerializeField] private Slot[] _slots = default;
	    [SerializeField] private Item[] _itemPrefabs = default; 
	    [SerializeField] private ItemDisplay[] _displays = default;
	   
	    [Header("Informations")]
	    [SerializeField] private int _numberOfBlocks = default;
	    
	    private void Update()
	    {
		    foreach (Slot slot in _slots)
		    {
			    if (slot.DontHaveItem)
			    {
				    GerateItemInSlot(slot);
			    }
		    }
		    
		    if (!_blockCount.text.Equals(_numberOfBlocks.ToString()))
		    {
			    _blockCount.text = _numberOfBlocks.ToString();  
		    }
	    }

	    private void GerateItemInSlot(Slot slot)
	    {
		    ItemDisplay display = RandomizeItem();
		    
		    switch (display)
		    {
			    case PlantItemDisplay _:
			    {
				    PlantItem prefab = _itemPrefabs[0] as PlantItem;
				    Item item = Instantiate(prefab, transform);
				    item.Initialize(display);
				    slot.Item = item;
				    break;
			    }
			    case ElementalItemDisplay _:
			    {
				    ElementItem element = _itemPrefabs[1] as ElementItem;
				    Instantiate(element, transform);
				    slot.Item = element;
				    break;
			    }
		    }
		   
		    _numberOfBlocks--;
	    }

	    private ItemDisplay RandomizeItem()
	    {
		    int i = Random.Range(0, _displays.Length);
		    
		    return _displays[i];
	    }

	    public int NumberOfBlocks
	    {
		    get { return _numberOfBlocks; }
		    set { _numberOfBlocks = value; }
	    }

    }
}
