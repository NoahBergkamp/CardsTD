using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FastTurretButton : MonoBehaviour
{
    public GameObject basicTurret;
    private Transform mousePos;

    
    public void TowerPlacement()
    {
        Instantiate(basicTurret);
    }

}
