using Unity.VisualScripting;
using UnityEngine;

public class RoundManageScript : MonoBehaviour
{
    [SerializeField] private Transform start;
    public GameObject basicEnemy;
    void Start()
    {
        start = GameObject.Find("RoundManager/Start").transform;

    }
    void Update()
    {
        roundSpawner();
    }



    public void roundSpawner()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(basicEnemy, start);
        }
    }
}
