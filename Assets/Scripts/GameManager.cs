using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public ObsCamera obsCamera;
    public InventoryDisplay inventoryDisplay;

    public Node startingNode;

    [HideInInspector]
    public Node currentNode;
    public Item itemHeld;

    public CameraRig rig;

    private void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    private void Start()
    {
        startingNode.Arrive();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if (ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            if (obsCamera.gameObject.activeInHierarchy)
            {
                obsCamera.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
