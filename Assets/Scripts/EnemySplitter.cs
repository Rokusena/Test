using UnityEngine;

public class EnemySplitter : MonoBehaviour
{
    public GameObject smallerEnemyPrefab;
    public int splitAmount = 2;

    public void Split()
    {
       
        for (int i = 0; i < splitAmount; i++)
        {
            Instantiate(smallerEnemyPrefab, transform.position + Random.insideUnitSphere, Quaternion.identity);
        }

       
        Destroy(gameObject);
    }
}
