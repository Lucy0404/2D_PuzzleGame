using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement; //Кол-во всех элементов пазла
    public static int myElement = 0; //Число элементов, лежащих на своем месте
    public GameObject myPuzzle; //Родительский объект, содержащий все элементы пазла 
    public GameObject myPanel; //Панель с пазлом
    public GameObject winUI;
    public GameObject pauseButton;
    public AudioManager audioManager;
 

    public void Start()
    {
        Restart();
        fullElement = myPuzzle.transform.childCount; //Получаем кол-во элементов пазла
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Update()
    {
        fullElement = myPuzzle.transform.childCount;
        if (fullElement == myElement) //Если все элементы на своем месте
        {
            myPanel.SetActive(false); //Скрываем панель с пазлом
            pauseButton.SetActive(false);
            winUI.SetActive(true); //Показываем панель победы
            audioManager.PauseMusic();
        }
    }

    // Функция увеличения кол-ва элементов, которые лежат на своем месте
    public static void AddElement()
    {
        myElement ++;
    }

    public void Restart()
    {
        myElement = 0; // Сброс количества элементов на своем месте
        myPanel.SetActive(true); // Показываем панель с пазлом
        winUI.SetActive(false); // Скрываем панель победы
        pauseButton.SetActive(true);
        audioManager.ResumeMusic(); 
    }
}
