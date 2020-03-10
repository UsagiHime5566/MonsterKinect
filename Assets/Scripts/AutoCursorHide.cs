using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCursorHide : MonoBehaviour
{
    //Cursor
    int cursorStayTime = 0;
    Vector3 lastCursorPos;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update(){
        if(lastCursorPos != Input.mousePosition){
            Cursor.visible = true;
            cursorStayTime = 0;
        } else {
            if(cursorStayTime < 30){
                cursorStayTime++;
            } else {
                Cursor.visible = false;
            }
        }
        lastCursorPos = Input.mousePosition;
    }
}
