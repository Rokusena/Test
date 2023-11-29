using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI healthText;
    public float damage = 5f;
    public float attackRange = 5f;
    public float attackRotationDuration = 0.2f;
    public Transform swordTransform;
    public AudioSource sound;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            swordTransform.rotation = Quaternion.Euler(-43f, 90f, 60f);
            Attack();
            sound.Play();
            StartCoroutine(wait1(0.5f));
            swordTransform.rotation = Quaternion.Euler(-43f, 90f, 90f);

        }
        if(gameObject.transform.position.y < -10)
        {
            Die();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + "/100";
        }
    }

    private void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        float closestDistance = float.MaxValue;
        GameObject closestEnemy = null;

       
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }

        if (closestEnemy != null)
        {
            EnemySplitter enemySplitter = closestEnemy.GetComponent<EnemySplitter>();
            if (enemySplitter != null)
            {
                enemySplitter.Split();
            }
            else
            {
              
                Destroy(closestEnemy);
            }
        }
       
    }
    private IEnumerator wait1(float time)
    {
        yield return new WaitForSeconds(time);
    }
   

}
