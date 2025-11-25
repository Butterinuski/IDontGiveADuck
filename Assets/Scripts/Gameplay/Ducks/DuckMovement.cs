using UnityEditor.Tilemaps;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB;
    }

    private void Awake()
    {
        PointA = GameObject.FindWithTag("PointA").transform;
        PointB = GameObject.FindWithTag("PointB").transform;

        Debug.Log("PointA found");
        Debug.Log("PointB found");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = (currentPoint.position - transform.position).normalized;
        if (currentPoint == PointB.transform)
        {
            Debug.Log("We shmoovin");
            rb.velocity = new Vector2(speed, 1);
        }
        else
        {
            rb.velocity = new Vector2(-speed, -1);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointA.transform;

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= 1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }

    
}
