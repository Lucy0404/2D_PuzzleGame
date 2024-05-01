using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int lvl;

    // Открывает нужную сцену, то есть нужный уровень
    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + lvl.ToString());        
    }
}
