using System;
using System.Collections;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] private ParticleSystem explosion;

    private Action onLoseScreenAction;
    private Score score;
    
    public void Setup( Score score = null, Action onLoseScreenAction = null)
    {
        this.onLoseScreenAction = onLoseScreenAction;
        this.score = score;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthImage.fillAmount = 1;
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private void TakeDamage(Collider collider)
    {
        if (currentHealth > 0)
        {
            currentHealth -= 20;
            textHealth.text = currentHealth.ToString();
            healthImage.fillAmount = currentHealth / 100;

            if (gameObject.tag == "Character")
            {
                score.PlayerHasDamage(collider.transform.parent.GetInstanceID());
            }
            else
            {
                score.EnemyHasDamage();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(other);
        Debug.Log("OnTriggerEnter ");
    }

    private IEnumerator Die()
    {
        explosion.Play();
        yield return new WaitForSeconds(0.5f);
        
        if (gameObject.tag == "Character")
        {
            Time.timeScale = 0.3f;
            onLoseScreenAction?.Invoke();
        }
        if (gameObject.tag != "Character")
        {
            score.KillEnemy(gameObject.GetInstanceID());
        }
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}