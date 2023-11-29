using System.Collections;

using UnityEngine;

using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public AudioSource audio;
    public NavMeshAgent agent;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    private Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            hitEffect();
           
        }
    }

  
    void Update()
    {
        agent.destination = target.position;
        agent.speed = speed;
          transform.LookAt(target);
          transform.position += transform.forward * speed * Time.deltaTime;


    }
   

    void hitEffect()
    {
        audio.Play();
        player.TakeDamage(20);
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;

            Camera.main.transform.localPosition = new Vector3(x, 10, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition;
    }
}
