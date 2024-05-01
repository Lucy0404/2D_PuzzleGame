using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        // ¬ыход из приложени€ и сообщение о том что игра закрыта
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame() 
    {
        // «агрузка выбора уровн€
        SceneManager.LoadScene("Level selector");
    }
}
