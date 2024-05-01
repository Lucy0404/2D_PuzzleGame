using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] public Slider musicSlider;

    private void Start()
    {
        // ���������, ��������� �� �������� ��������� ������ � PlayerPrefs.
        // ���� ���, ������������� �������� �� ��������� � ��������� ���. ���� �������� ��� ���������, ������ ��������� ���.
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    // ������������� ������� ��������� � ����, ��������� ������� �������� musicSlider, � ��������� ���.
    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }

    // ��������� �������� ��������� ������ �� PlayerPrefs � ������������� ��� ��� ������� �������� musicSlider.
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // ��������� ������� �������� ��������� ������ � PlayerPrefs.
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
}
