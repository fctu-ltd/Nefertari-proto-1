using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{

    public Sprite pic;

    public override void Interact()
    {
        base.Interact();

        GameManager.ins.ivCanvas.Activate(pic);
    }
}
