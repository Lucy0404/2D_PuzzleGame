using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement; //���-�� ���� ��������� �����
    public static int myElement = 0; //����� ���������, ������� �� ����� �����
    public GameObject myPuzzle; //������������ ������, ���������� ��� �������� ����� 
    public GameObject myPanel; //������ � ������
    public GameObject winUI;
    public GameObject pauseButton;
    public AudioManager audioManager;
 

    public void Start()
    {
        Restart();
        fullElement = myPuzzle.transform.childCount; //�������� ���-�� ��������� �����
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Update()
    {
        fullElement = myPuzzle.transform.childCount;
        if (fullElement == myElement) //���� ��� �������� �� ����� �����
        {
            myPanel.SetActive(false); //�������� ������ � ������
            pauseButton.SetActive(false);
            winUI.SetActive(true); //���������� ������ ������
            audioManager.PauseMusic();
        }
    }

    // ������� ���������� ���-�� ���������, ������� ����� �� ����� �����
    public static void AddElement()
    {
        myElement ++;
    }

    public void Restart()
    {
        myElement = 0; // ����� ���������� ��������� �� ����� �����
        myPanel.SetActive(true); // ���������� ������ � ������
        winUI.SetActive(false); // �������� ������ ������
        pauseButton.SetActive(true);
        audioManager.ResumeMusic(); 
    }
}
