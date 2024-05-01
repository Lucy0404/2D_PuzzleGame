using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMove : MonoBehaviour
{
    bool move;
    Vector2 mousePos; 
    float startPosX;
    float startPosY;
    public GameObject form; // Форма пазла с правильной позицией
    bool finish;
    public WinScript winScript;

    public void Start()
    {
        winScript.Restart();

        // Перемешивание позиций элементов пазла
        ShufflePuzzlePieces();
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // Если нажал лкм
        {
            move = true;

            // Сохраняются начальные координаты мыши и объекта для вычисления смещения.
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    // Если расстояние между текущей позицией кусочка пазла и позицией формы пазла меньше или равно 20
    // по обеим осям и пазл еще не завершен, то кусочек пазла перемещается на позицию формы пазла.
    public void OnMouseUp()
    {
        move = false;
       
        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 20f &&
           Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 20f && finish != true)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinScript.AddElement();
        }
    }

    public void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition; // Записываем позицию курсора
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY); // Меняем позицию обьекта на позицию мышки
        }
    }

    private void ShufflePuzzlePieces()
    {
        // Получение случайных координат x, y в пределах диапазона
        float randomX = Random.Range(-16f, -3f);
        float randomY = Random.Range(-4.2f, 2.6f);
        

        // Применение случайных координат к позиции кусочка пазла
        transform.position = new Vector2(randomX, randomY);
    }
}
