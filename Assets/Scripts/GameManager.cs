using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public GameObject pauseMenu;
    public ObsCamera obsCamera;
    public InventoryDisplay inventoryDisplay;

    public Node startingNode;

    [HideInInspector]
    public Node currentNode;
    public Item itemHeld;

    public CameraRig rig;

    public Texture2D cursorTextureLoc;
    public Texture2D cursorTextureProp;
    public Texture2D cursorTextureDefault;

    public bool isPaused = false;


    private void Awake()
    {
        ins = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    private void Start()
    {
        startingNode.Arrive();
        if (cursorTextureDefault != null)
        {
            Cursor.SetCursor(GameManager.ins.cursorTextureDefault, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("PAUSE GAME");
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("RESUME GAME");
        pauseMenu.SetActive(false); 
        isPaused = false;
        Time.timeScale = 1f;
    }
}
