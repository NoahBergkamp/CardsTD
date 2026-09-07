using UnityEngine;

public class TrackFollower : MonoBehaviour
{

    [SerializeField]private Transform start;
    [SerializeField] private Transform rotate1;
    [SerializeField] private Transform rotate2;
    [SerializeField] private Transform rotate3;
    [SerializeField] private Transform rotate4;
    [SerializeField] private Transform end;



    [Header("Movement")]
    public float speed = 5f;
    public float reachDistance = 0.1f;

    private Rigidbody2D rb;
    private Transform[] waypoints;
    private int currentPoint = 1;



    private void Awake()
    {
        start = GameObject.Find("RoundManager/Start").transform;
        rotate1 = GameObject.Find("RoundManager/rotate1").transform;
        rotate2 = GameObject.Find("RoundManager/rotate2").transform;
        rotate3 = GameObject.Find("RoundManager/rotate3").transform;
        rotate4 = GameObject.Find("RoundManager/rotate4").transform;
        end = GameObject.Find("RoundManager/End").transform;
        
    }
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();

        waypoints = new Transform[] { start, rotate1, rotate2, rotate3, rotate4, end};

        transform.position = start.position;
    }



    void FixedUpdate()
    {
        if (currentPoint >= waypoints.Length)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 target = waypoints[currentPoint].position;
        Vector2 direction = (target - rb.position).normalized;

        rb.linearVelocity = direction * speed;

        // Rotate sprite to face movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (Vector2.Distance(rb.position, target) < reachDistance)
        {
            currentPoint++;
        }
    }
}