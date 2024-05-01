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
        // ѕровер€ет, сохранено ли значение громкости музыки в PlayerPrefs.
        // ≈сли нет, устанавливает значение по умолчанию и загружает его. ≈сли значение уже сохранено, просто загружает его.
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

    // ”станавливает уровень громкости в игре, использу€ текущее значение musicSlider, и сохран€ет его.
    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }

    // «агружает значение громкости музыки из PlayerPrefs и устанавливает его как текущее значение musicSlider.
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // —охран€ет текущее значение громкости музыки в PlayerPrefs.
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
}
