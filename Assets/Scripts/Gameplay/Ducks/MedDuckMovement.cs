using UnityEditor.Tilemaps;
using UnityEngine;

public class MedDuckMovement : MonoBehaviour
{
    public Transform PointE;
    public Transform PointF;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointF;
    }

    private void Awake()
    {
        PointE = GameObject.FindWithTag("PointE").transform;
        PointF = GameObject.FindWithTag("PointF").transform;

        Debug.Log("PointE found");
        Debug.Log("PointF found");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointF.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointE.transform;

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointE.transform)
        {
            Debug.Log("we reached a point");
            Flip();
            currentPoint = PointF.transform;
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
        Gizmos.DrawWireSphere(PointE.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointF.transform.position, 0.5f);
        Gizmos.DrawLine(PointE.transform.position, PointF.transform.position);
    }
}
