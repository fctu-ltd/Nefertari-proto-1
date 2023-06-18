using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class Node : MonoBehaviour
{

    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    private void OnMouseDown()
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        if (GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }
        GameManager.ins.currentNode = this;
        GameManager.ins.rig.AlignTo(cameraPosition);
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
