using UnityEngine;

public class Line : MonoBehaviour
{

    public Vector3 supportVector = new Vector3(1,2,0);
    public Vector3 directionVector = new Vector3 (1,1,0);
    public float lenght;
    public LineRenderer lineRenderer;

    void Start()
    {
        
    }

   
    void Update()
    {
        lineRenderer.SetPosition(0, supportVector  -20 * directionVector.normalized);
        lineRenderer.SetPosition(1, supportVector + 20 * directionVector.normalized);

    }
}
