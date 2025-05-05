using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovengPuzzl : MonoBehaviour
{
    bool move;//Перемещаем/не перемещаем
    Vector2 mousePos;//Позиция курсора
    float startPosX;//Начальное пеложение объекта по Х
    float startPosY;//Начальное пеложение объекта по Y
    public GameObject form;//Прозрачная форма с правильной позицией
    bool finish;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {//Когда пользователь нажимает левой клавишей мыши
            move = true;//Разрешаем перемещение
            mousePos = Input.mousePosition;//Получаем координаты курсора

            startPosX = mousePos.x - this.transform.localPosition.x;//Записываем стартовое положение по Х
            startPosY = mousePos.y - this.transform.localPosition.y;//Записываем стартовое положение по Y
        }
    }

    void OnMouseUp()
    {//Когда пользователь отпускает клавишу мыши
        move = false;//Запрещяем перемещение

        //Если Объект рядом со своим местом, то помещаем его его туда и запрещаем дальнейшее перемещение
        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
           Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinScript.AddElement();//Увеличиваем кол-во элементов на своем месте
        }
    }

    //Само перемещение
    void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition;//Получаем координаты курсора
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);//Перемещаем обЪект
        }
    }
}
