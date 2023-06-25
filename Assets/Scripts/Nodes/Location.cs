using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Location : Node
{
    public override void OnMouseEnter()
    {
        if (GameManager.ins.cursorTextureLoc != null)
        {
            Cursor.SetCursor(GameManager.ins.cursorTextureLoc, hotSpot, cursorMode);
        }
    }
    /*   private readonly Timer _MouseSingleClickTimer = new Timer();

       void Awake()
       {
           _MouseSingleClickTimer.Interval = 400;
           _MouseSingleClickTimer.Elapsed += SingleClick;
       }
       void SingleClick(object o, System.EventArgs e)
       {
           _MouseSingleClickTimer.Stop();

           Debug.Log("Single Click");
           //Do your stuff for single click here....
       }

       public override void OnMouseDown()
       {
           if (_MouseSingleClickTimer.Enabled == false)
           {
               _MouseSingleClickTimer.Start();
               return;
           }
           else
           {
               _MouseSingleClickTimer.Stop();
               Debug.Log("Double Click");
               Arrive();
           }
       }*/
}
