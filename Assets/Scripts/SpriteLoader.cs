using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpriteLoader {

    private const string SPRITES_FOLDER = "Sprites";
    private const string RESOURCES_FOLDER =  "Resources";
    private const int MAX_SPRITES_COUNT = 2;
    private const int MAX_FOLDERS_COUNT = 6;

    public Sprite[] LoadRandomSpriteByCategory(ItemCategory category) {

        Sprite[] sprites = new Sprite[MAX_SPRITES_COUNT];
        string fullPath = Application.dataPath + "/" + RESOURCES_FOLDER + "/" + SPRITES_FOLDER + "/" + category.ToString();
        try {
            int index = Random.Range(1, 6);
            string resourcesPath = SPRITES_FOLDER + "/" + category.ToString() + "/" + index.ToString();
            sprites = Resources.LoadAll<Sprite>(resourcesPath);
        } catch (Exception e) {
            Debug.LogError("LoadRandomSpriteByCategory: Failed to load " + e);
            return null;
        }
        
        return sprites;
    }
}