using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FastTurretButton : MonoBehaviour
{
    public GameObject Turret;
    private Transform mousePos;

    
    public void TowerPlacement()
    {
        Instantiate(Turret);
    }

}
