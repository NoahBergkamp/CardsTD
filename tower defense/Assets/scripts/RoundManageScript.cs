using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManageScript : MonoBehaviour
{
    [SerializeField] private Transform start;
    public GameObject basicEnemy;
    private bool CoroutineTest = true;
    void Start()
    {
        start = GameObject.Find("RoundManager/Start").transform;
        
        
    }
    void Update()
    {
        RoundHandler();
    }


    private void RoundHandler()
    {
        if (CoroutineTest == true)
        {
            StartCoroutine(round1Spawn());
            CoroutineTest = false;

        }
    }
    public IEnumerator round1Spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(basicEnemy, start);
            yield return new WaitForSeconds(0.5f);         
        }
        for (int i = 0; i < 12; i++)
        {
            Instantiate(basicEnemy, start);
            yield return new WaitForSeconds(0.4f);
        }
        for (int i = 0; i < 24; i++)
        {
            Instantiate(basicEnemy, start);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 48; i++)
        {
            Instantiate(basicEnemy, start);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
