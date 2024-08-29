using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer[] headRenderer;
    [SerializeField]
    private SpriteRenderer[] torsoRenderer;
    [SerializeField]
    private SpriteRenderer[] beltRenderer;
    [SerializeField]
    private SpriteRenderer[] bootsRenderer;
    [SerializeField]
    private SpriteRenderer[] shouldersRenderer; 
    [SerializeField]
    private SpriteRenderer[] weaponsRenderer;

    private Dictionary<ItemCategory,Item> equipment = new Dictionary<ItemCategory,Item>();

    public Dictionary<ItemCategory, Item> Equipment { get { return equipment; } }

    private void Awake() {
        equipment = GetEquipment();
    }

    public void EquipItem(Item item) {

        equipment[item.Category] = item;

        switch (item.Category) {
            case (ItemCategory.HEAD):
                ChangeSprite(item, headRenderer);
                break;
            case (ItemCategory.TORSO):
                ChangeSprite(item, torsoRenderer);
                break;
            case (ItemCategory.BOOTS):
                ChangeSprite(item, bootsRenderer);
                break;
            case (ItemCategory.BELTS):
                ChangeSprite(item, beltRenderer);
                break;
            case (ItemCategory.SHOULDER):
                ChangeSprite(item, shouldersRenderer);
                break;
            case (ItemCategory.WEAPON):
                ChangeSprite(item, weaponsRenderer);
                break;
        }
    }

    private void ChangeSprite(Item item, SpriteRenderer[] renderer) {

        for (int i = 0; i < renderer.Length; i++) {
            if (item.Sprites != null && item.Sprites[i] != null) {
                renderer[i].sprite = item.Sprites[i];
            } else {
                Debug.LogError($"EquipItem: Sprite is null! sprite index : {i} "  + item.Category.ToString());
            }
        }


    }

    //mockup, should be loaded from server
    private Dictionary<ItemCategory, Item> GetEquipment() {
        Item newItem = new Item(1,1,1,1,ItemCategory.HEAD, null);
        equipment.Add(ItemCategory.HEAD, newItem);
        equipment.Add(ItemCategory.TORSO, newItem);
        equipment.Add(ItemCategory.SHOULDER, newItem);
        equipment.Add(ItemCategory.BOOTS, newItem);
        equipment.Add(ItemCategory.BELTS, newItem);
        equipment.Add(ItemCategory.WEAPON, newItem);

        return equipment;
    }
}