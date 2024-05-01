using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;

    [Header("------Audio Clip------")]
    public AudioClip background;


    // ���������, ���� �� ����������� �������� ��� ����� "muted" � PlayerPrefs. ���� ���, ��������������� �������� �� ���������.
    // ���������� ����� Load(), ������� ��������� ����������� ���������. ����� ���������� ����� UpdateButtonIcon() ���
    // ���������� ������ ������ ����� � ����������� �� �������� ���������. ����� ����� ��������������� ���������
    // �������������� � ��������������� ������.
    public void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;

        musicSource.clip = background;
        musicSource.Play();
    }

    // ���������/���������� �����.
    // ���������� ������ Save() ��� ���������� ��������� � UpdateButtonIcon() ��� ���������� ������ ������.
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    // ��������� ��������� ����� �� PlayerPrefs. 
    // ���� �������� ����� "muted" ����� 1, �� ���� �������� (���������� muted ��������������� � true),
    // � ��������� ������ ���� �������.
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // ��������� ������� ��������� ����� � PlayerPrefs.
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // ��������� ������ ������ ����� � ����������� �� �������� ��������� �����. 
    private void UpdateButtonIcon()
    {
        if (muted == false) 
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
