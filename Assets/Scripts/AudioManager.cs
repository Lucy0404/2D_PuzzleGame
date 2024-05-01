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


    // Проверяет, есть ли сохраненное значение для ключа "muted" в PlayerPrefs. Если нет, устанавливается значение по умолчанию.
    // Вызывается метод Load(), который загружает сохраненное состояние. Затем вызывается метод UpdateButtonIcon() для
    // обновления иконки кнопки звука в зависимости от текущего состояния. После этого устанавливается состояние
    // аудиослушателя и воспроизводится музыка.
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

    // Включение/выключение звука.
    // Вызываются методы Save() для сохранения состояния и UpdateButtonIcon() для обновления иконки кнопки.
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

    // Загружает состояние звука из PlayerPrefs. 
    // Если значение ключа "muted" равно 1, то звук выключен (переменная muted устанавливается в true),
    // в противном случае звук включен.
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // Сохраняет текущее состояние звука в PlayerPrefs.
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // Обновляет иконку кнопки звука в зависимости от текущего состояния звука. 
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
