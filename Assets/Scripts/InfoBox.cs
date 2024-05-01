using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isInfoPanelActive = false; // Флаг для отслеживания состояния панели информации

    public void ToggleInfoPanel()
    {
        // Инвертируем состояние панели информации
        isInfoPanelActive = !isInfoPanelActive;

        // Устанавливаем активность панели информации в соответствии с флагом
        infoPanel.SetActive(isInfoPanelActive);
    }
}
