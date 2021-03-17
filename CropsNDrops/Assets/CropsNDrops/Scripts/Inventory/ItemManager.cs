using CropsNDrops.Scripts.Enum;
using CropsNDrops.Scripts.Scriptables.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CropsNDrops.Scripts.Inventory
{
    public class ItemManager : MonoBehaviour
    {
	    [Header("Definitions")]
	    [SerializeField] private Text _blockCount = default;
	    [SerializeField] private Slot[] _slots = default;
	    [SerializeField] private Item[] _itemPrefabs = default; 
	    [SerializeField] private ItemDisplay[] _itemDisplays = default;
	   
	    [Header("Informations")]
	    [SerializeField] private int _numberOfBlocks = default;

	    private void Start()
	    {
		    foreach (Slot t in _slots)
		    { 
			    t.PutItem += GerateItemInSlot; 
			    //Isso funciona por que tô pansando o próprio t.
			    //t.PutItem += _ => GerateItemInSlot(t);
		    }
	    }

	    private void GerateItemInSlot(Slot slot)
	    {
		    UpdateNumberOfBlock();
		    ItemDisplay itemDisplay = RandomizeItem();

		    switch (itemDisplay)
		    {
			    case PlantItemDisplay _:
			    {
				    itemDisplay.Type = ItemType.PLANT;
				    
				    foreach (Item itemPrefab in _itemPrefabs)
				    {
					    if (itemPrefab is PlantItem)
					    {
						    Item item = Instantiate(itemPrefab, slot.transform);
						    item.Initialize(itemDisplay);
						    slot.Item = item;
					    }
				    }
				    
				    return;
			    }
			    case ElementalItemDisplay _:
			    {
				    itemDisplay.Type = ItemType.ELEMENTAL;
				    
				    foreach (Item itemPrefab in _itemPrefabs)
				    {
					    if (itemPrefab is ElementItem)
					    {
						    Item item = Instantiate(itemPrefab, slot.transform);
						    item.Initialize(itemDisplay);
						    slot.Item = item;
					    }
				    }
				    
				    return;
			    }
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

	    private ItemDisplay RandomizeItem()
	    {
		    //Melhorar mais tarde
		    
		    int i = Random.Range(0, _itemDisplays.Length);
		    
		    return _itemDisplays[i];
	    }

	    public int NumberOfBlocks
	    {
		    get { return _numberOfBlocks; }
		    set { _numberOfBlocks = value; }
	    }

    }
}
