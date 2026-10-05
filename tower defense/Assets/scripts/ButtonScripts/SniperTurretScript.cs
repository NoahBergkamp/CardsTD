using UnityEngine;

public class SniperTurretScript : MonoBehaviour
{
    public GameObject SniperTurret;
    private Transform mousePos;


    public void TowerPlacement()
    {
        Instantiate(SniperTurret);
    }
}
