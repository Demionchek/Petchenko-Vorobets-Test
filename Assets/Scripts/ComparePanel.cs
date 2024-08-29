using UnityEngine;
using UnityEngine.UI;

public class ComparePanel : MonoBehaviour {

    [SerializeField] private Player player;

    [Header("CurrentItem")]
    [SerializeField] Text currAttackText;
    [SerializeField] Text currDefenceText;
    [SerializeField] Text currSpeedText;
    [SerializeField] Text currHeathText;
    [SerializeField] SpriteRenderer currSpriteRenderer;

    [Space(15)]
    [Header("ObtainedItem")]
    [SerializeField] Text obtAttackText;
    [SerializeField] Text obtDefenceText;
    [SerializeField] Text obtSpeedText;
    [SerializeField] Text obtHeathText;
    [SerializeField] SpriteRenderer obtSpriteRenderer;

    private ItemsGenerator itemsGenerator;
    private Item generatedItem;

    private const string ATTACK_TEXT = "ATK";
    private const string DEFENCE_TEXT = "DEF";
    private const string SPEED_TEXT = "SPD";
    private const string HEALTH_TEXT = "HP";


    private void OnEnable() {

        if (itemsGenerator == null) {
            itemsGenerator = new ItemsGenerator();
        }

        if (player == null) {
            player = FindFirstObjectByType<Player>();
        }
        if (player == null) Debug.LogError("No Player object found!");

        generatedItem = itemsGenerator.GetNewRandomItem();
        if (generatedItem == null) {
            Debug.LogError("No Item was generated!");
        }
        SetupItemText(generatedItem, obtAttackText, obtDefenceText, obtHeathText, currSpeedText, obtSpriteRenderer);

        if (player.Equipment.ContainsKey(generatedItem.Category)) { 
            Item playerItem = player.Equipment[generatedItem.Category];
            SetupItemText(playerItem, currAttackText, currDefenceText, currHeathText, currSpeedText, currSpriteRenderer);
        }
    }

    private void SetupItemText(Item item, Text attackText, Text defenceText, Text heathText, Text speedText, SpriteRenderer renderer) {
        attackText.text = ATTACK_TEXT + " " + item.Attack.ToString();
        defenceText.text = DEFENCE_TEXT + " " + item.Defence.ToString();
        heathText.text = HEALTH_TEXT + " " + item.Health.ToString();
        speedText.text = SPEED_TEXT + " " + item.Speed.ToString();
        renderer.sprite = item.Sprites == null ? null : item.Sprites[0];
    }

    public void OnClickEquip() {
        if (player != null) {
            player.EquipItem(generatedItem);
        } else {
            Debug.LogError("No Player object!");
        }
        UIManager.Instance.ComparePanelSetActive(false);
    }

    public void OnClickDrop() {
        generatedItem = null;
        UIManager.Instance.ComparePanelSetActive(false);
    }

}