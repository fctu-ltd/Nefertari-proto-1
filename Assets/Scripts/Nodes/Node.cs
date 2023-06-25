using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Node : MonoBehaviour
{

    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();
    public bool alignTo = true;

    [HideInInspector]
    public Collider col;
    [HideInInspector] 
    public CursorMode cursorMode = CursorMode.Auto;
    [HideInInspector]
    public Vector2 hotSpot = Vector2.zero;

    private bool inCollider;

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    public virtual void OnMouseDown()
    {
        inCollider = true;
    }


    public virtual void OnMouseUp()
    {
        if (inCollider && !GameManager.ins.isPaused)
        {
            Arrive();
        }

    }

    public virtual void OnMouseEnter()
    {
        
    }

    public virtual void OnMouseExit()
    {
        inCollider = false;
        if (GameManager.ins.cursorTextureDefault != null)
        {
            Cursor.SetCursor(GameManager.ins.cursorTextureDefault, Vector2.zero, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public virtual void Arrive()
    {
        if (GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }
        GameManager.ins.currentNode = this;
        if (alignTo)
        {
            GameManager.ins.rig.AlignTo(cameraPosition);
        }
        else
        {
            GameManager.ins.rig.MoveTo(cameraPosition);
        }
        if (col != null)
        {
            col.enabled = false;
        }
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        foreach (Node node in reachableNodes)
        {
            if (node != null && node.col != null)
            {
                /* if (node.GetComponent<PreRequisite>() && node.GetComponent<PreRequisite>().nodeAccess)
                 {
                     if (node.GetComponent<PreRequisite>().Complete)
                     {
                         node.col.enabled = set;
                     }
                 }
                 else
                 {
                     node.col.enabled = set;
                 }*/
                if (node.GetComponent<PreRequisite>() && node.GetComponent<PreRequisite>().nodeAccess && !node.GetComponent<PreRequisite>().Complete)
                {
                    continue;
                }
                node.col.enabled = set;
            }
        }
    }
}
