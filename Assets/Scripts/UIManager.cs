using System;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    [Header("ComparePanel")]
    [SerializeField] private GameObject comparePanel;

    public void ComparePanelSetActive(bool isActive = true) {
        if (comparePanel != null) {
            comparePanel.SetActive(isActive);
        } else {
            try {
                comparePanel = FindAnyObjectByType<ComparePanel>(FindObjectsInactive.Include).gameObject;
                comparePanel.SetActive(isActive);
            } catch (Exception e) {
                Debug.LogError("ComparePanelSetActive: no comparePanel found!" + e);
            }
        }
    }

}
