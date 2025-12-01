using UnityEditor.Tilemaps;
using UnityEngine;

public class SmallDuckMovement : MonoBehaviour
{
    public Transform PointC;
    public Transform PointD;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointD;
    }

    private void Awake()
    {
        PointC = GameObject.FindWithTag("PointC").transform;
        PointD = GameObject.FindWithTag("PointD").transform;

        Debug.Log("PointA found");
        Debug.Log("PointB found");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointD.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointC.transform;

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointC.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointD.transform;
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
        Gizmos.DrawWireSphere(PointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointD.transform.position, 0.5f);
        Gizmos.DrawLine(PointC.transform.position, PointD.transform.position);
    }
}
