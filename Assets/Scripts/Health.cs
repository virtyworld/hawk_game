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
    
    public void Setup(Action onLoseScreenAction,Score score = null)
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
            //если умирает враг - проверка на то,попадал ли он в игрока
            
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
    }

    private IEnumerator Die()
    {
        if (gameObject.tag != "Character")
        {
            score.KillEnemy(gameObject.GetInstanceID());
        }
      
        
        explosion.Play();
        if (gameObject.tag == "Character")
        {
            Time.timeScale = 0.3f;
            // Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
      
        yield return new WaitForSeconds(0.5f);
        onLoseScreenAction?.Invoke();
        Time.timeScale = 1f;
        //Time.fixedDeltaTime = Time.timeScale * 0.01f;
        Destroy(gameObject);
    }
}