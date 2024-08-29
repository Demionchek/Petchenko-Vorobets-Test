using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsGenerator {

    private const int MAX_VALUE = 101;
    private const int MIN_VALUE = 1;
    private const int STATS_COUNT = 4;

    public Item GetNewRandomItem() {

        int[] stats = new int[STATS_COUNT];
        GenerateStats(stats);
        SpriteLoader spriteLoader = new SpriteLoader();
        int enumCount = Enum.GetNames(typeof(ItemCategory)).Length;
        int categoryIndex = Random.Range(1, enumCount + 1);
        ItemCategory category = (ItemCategory)categoryIndex;
        Sprite[] sprites = spriteLoader.LoadRandomSpriteByCategory(category);
        Item item = new Item(stats[0], stats[1], stats[2], stats[3], category, sprites);
        return item;
    }

    private void GenerateStats(int[] stats) { 
        for (int i = 0; i < stats.Length; i++) {
            stats[i] = Random.Range(MIN_VALUE, MAX_VALUE);
        }
    }
}
