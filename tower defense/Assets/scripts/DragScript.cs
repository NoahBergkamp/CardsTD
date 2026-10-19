using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragScript : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActionAsset;
    InputActionMap actionMap;
    private InputAction InputAction;
    private bool dragging = false;
    private bool placed = false;
    private TrackCollision trackCollision;
    private Rigidbody2D rb;
    


    private void Start()
    {
        trackCollision = FindFirstObjectByType<TrackCollision>();
        GetComponent<AimScript>().enabled = false;
        rb = GetComponent<Rigidbody2D>();

        actionMap = inputActionAsset.FindActionMap("Game");
        InputAction = actionMap.FindAction("Mouse");
        transform.position = Vector3.zero;
        dragging = true;
    }

    private void OnEnable()
    {
        inputActionAsset.Enable();
    }

    private void OnDisable()
    {
        inputActionAsset.Disable();
    }


    void Update()
    {
        if(InputAction.WasPressedThisFrame() && trackCollision.onTrack == false)
        {

            placed = true;
            dragging = false;
            
        }

        if (dragging == true)
        {
            TowerPlacement();
        }

        if (placed == true)
        {
            GetComponent<AimScript>().enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
             
        }
    }

    private void TowerPlacement()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0f));
        mouseWorldPos.z = 0f; 
        transform.position = mouseWorldPos;
    }
}