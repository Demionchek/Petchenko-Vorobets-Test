using System;
using UnityEngine;

[Flags]
public enum ItemCategory {
    HEAD = 1,
    TORSO = 2,
    BELTS = 3,
    SHOULDER = 4,
    BOOTS = 5,
    WEAPON = 6
}

public class Item {
    private int attack;
    private int defence;
    private int speed;
    private int health;
    private ItemCategory category;
    private Sprite[] sprites;

    public Item(int attack, int defence, int speed, int health, ItemCategory categories, Sprite[] sprites) {
        this.attack = attack;
        this.defence = defence;
        this.speed = speed;
        this.health = health;
        this.category = categories;
        this.sprites = sprites;
    }

    public int Attack { get { return attack; } }
    public int Defence { get {  return defence; } }
    public int Speed { get { return speed; } }
    public int Health { get { return health; } }
    public ItemCategory Category { get { return category; } }
    public Sprite[] Sprites { get { return sprites; } }
}