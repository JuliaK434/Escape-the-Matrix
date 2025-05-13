using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovengPuzzl : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;

    void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            move = true;
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }

    void OnMouseUp(){
        move = false;

        
        if(Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x)<=10f&&
           Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y)<=10f){
               this.transform.position = new Vector2(form.transform.position.x,form.transform.position.y);
               finish = true;
               WinScript.AddElement();
        }
    }

 
    void Update()
    {
        if(move == true && finish == false){
            mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y-startPosY);//Перемещаем обЪект
        }
    }
}
