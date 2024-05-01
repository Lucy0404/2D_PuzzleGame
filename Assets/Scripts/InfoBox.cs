using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isInfoPanelActive = false; // ���� ��� ������������ ��������� ������ ����������

    public void ToggleInfoPanel()
    {
        // ����������� ��������� ������ ����������
        isInfoPanelActive = !isInfoPanelActive;

        // ������������� ���������� ������ ���������� � ������������ � ������
        infoPanel.SetActive(isInfoPanelActive);
    }
}
