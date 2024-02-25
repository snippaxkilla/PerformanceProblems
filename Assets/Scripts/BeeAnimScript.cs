using UnityEngine;

public class BeeAnimScript : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject[] bees;
    private float dist = 0;
    private Vector3 middle = new Vector3(5f, 2f, 5f);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bees = BB.bees.bee;
        Vector3 directionToMiddle = Vector3.ClampMagnitude(middle - transform.position, 1);
        rb.AddForce(directionToMiddle * 2f, ForceMode.Acceleration);

        for (int i = 0; i < BB.bees.nBees; i++)
        {
            if (bees[i] != gameObject)
            {
                dist = Vector3.Distance(transform.position, bees[i].transform.position);
                if (dist < BB.bees.spacing)
                {
                    Vector3 separationForce = Vector3.ClampMagnitude(transform.position - bees[i].transform.position, 1);
                    rb.AddForce(separationForce * 3f, ForceMode.Acceleration);
                }
            }
        }

        dist = Vector3.Distance(transform.position, BB.bees.queen.transform.position);
        if (dist < BB.bees.spacing * 2.5f)
        {
            Vector3 avoidQueenForce = Vector3.ClampMagnitude(transform.position - BB.bees.queen.transform.position, 1);
            rb.AddForce(avoidQueenForce * 3f, ForceMode.Acceleration);
        }
    }
}
