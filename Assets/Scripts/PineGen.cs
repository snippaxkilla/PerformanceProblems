using UnityEngine;

public class PineGen : MonoBehaviour
{
    [SerializeField] private GameObject pinePrefab;
    [SerializeField] private GameObject[] pine;
    [SerializeField] private Vector3 center;

    [SerializeField] private int nPines = 5000;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.5f;


    private void Start()
    {
        pine = new GameObject[nPines];
        Vector3[] positions = GenerateRandomPositions(nPines);

        for (int i = 0; i < nPines; i++)
        {
            pine[i] = Instantiate(pinePrefab, positions[i], Quaternion.identity);
            var scale = Random.Range(minScale, maxScale);
            pine[i].transform.localScale *= scale;
        }
    }

    // Create an array of random positions instead of going through a loop and creating one at a time
    Vector3[] GenerateRandomPositions(int count)
    {
        Vector3[] positions = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            var tx = Random.Range(-4.9f, 4.9f);
            var ty = Random.Range(-4.9f, 4.9f);
            positions[i] = new Vector3(tx, 0, ty) + center;
        }
        return positions;
    }
}
