using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour{

    public float sliderMaxValue = 100f;
    public float manaIncome;
    public float manaCooldown;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text manaCountText;
    [SerializeField]
    private Button getItemButton;

    private int manaCount;

    private void Start() {
        if (slider != null) {
            slider.minValue = 0;
            slider.maxValue = sliderMaxValue;
            slider.wholeNumbers = false;
        }
        StartCoroutine(ManaGenerator());
        SetInteractiveButton(false);
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    private void SetInteractiveButton(bool isInteractive) {
        if (getItemButton != null) {
            getItemButton.interactable = isInteractive;
        }
    }

    private void UpdateManaText() => manaCountText.text = manaCount.ToString();

    public void GetItemButtonPressed() {
        if (manaCount <= 0) return;

        manaCount--;

        if (manaCount <= 0) SetInteractiveButton(false);

        UpdateManaText();
        UIManager.Instance.ComparePanelSetActive(true);
    }

    private IEnumerator ManaGenerator() {
        while (true) {
            if (slider != null) {
                slider.value += manaIncome;
                if (slider.value >= slider.maxValue) {
                    slider.value = 0;
                    manaCount++;
                    UpdateManaText();
                    SetInteractiveButton(true);
                }
            }
            yield return new WaitForSeconds(manaCooldown);
        }
    }
}