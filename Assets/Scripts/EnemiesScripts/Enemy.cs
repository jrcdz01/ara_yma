using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attak,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAtack;
    public float moveSpeed;
    public GameObject deathEffect;
    public void Awake(){
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage){
        Debug.Log("Vida inical"+health);
        health -= damage;
        Debug.Log("Vida restante"+health);
        Debug.Log("Dano sofrido "+damage);
        if(health <= 0){
            DeathEffect();
            this.gameObject.SetActive(false);

        }
    }

    private void DeathEffect(){
        if(deathEffect != null){
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime){
        if (myRigidbody != null ){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }
}
