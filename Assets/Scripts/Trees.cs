using UnityEngine;

public class Trees : MonoBehaviour
{
    public GameObject treePrefab;
    public int numberOfTrees = 10;
    public float spacing = 2.0f;
    public float areaWidth = 10.0f; 
    public float areaLength = 10.0f; 

    private void Start()
    {
        PlantTrees();
    }

    private void PlantTrees()
    {
        Vector3 centerPosition = transform.position;

        Vector3 startingPosition = centerPosition - new Vector3(areaWidth / 2, 0f, areaLength / 2);

        for (int i = 0; i < numberOfTrees; i++)
        {
            float x1 = Random.Range(0f, areaWidth);
            float z1 = Random.Range(0f, areaLength);

            Vector3 treePosition = startingPosition + new Vector3(x1, 0f, z1);

            Instantiate(treePrefab, treePosition, Quaternion.identity);
        }
    }
}
