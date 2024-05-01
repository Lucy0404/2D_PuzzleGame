using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMove : MonoBehaviour
{
    bool move;
    Vector2 mousePos; 
    float startPosX;
    float startPosY;
    public GameObject form; // ����� ����� � ���������� ��������
    bool finish;
    public WinScript winScript;

    public void Start()
    {
        winScript.Restart();

        // ������������� ������� ��������� �����
        ShufflePuzzlePieces();
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // ���� ����� ���
        {
            move = true;

            // ����������� ��������� ���������� ���� � ������� ��� ���������� ��������.
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    // ���� ���������� ����� ������� �������� ������� ����� � �������� ����� ����� ������ ��� ����� 20
    // �� ����� ���� � ���� ��� �� ��������, �� ������� ����� ������������ �� ������� ����� �����.
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
            mousePos = Input.mousePosition; // ���������� ������� �������
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY); // ������ ������� ������� �� ������� �����
        }
    }

    private void ShufflePuzzlePieces()
    {
        // ��������� ��������� ��������� x, y � �������� ���������
        float randomX = Random.Range(-16f, -3f);
        float randomY = Random.Range(-4.2f, 2.6f);
        

        // ���������� ��������� ��������� � ������� ������� �����
        transform.position = new Vector2(randomX, randomY);
    }
}
