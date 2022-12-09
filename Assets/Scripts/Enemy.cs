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
    public void Awake(){
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage){
        Debug.Log("Vida inical"+health);
        health -= damage;
        Debug.Log("Vida restante"+health);
        Debug.Log("Dano sofrido "+damage);
        if(health <= 0){
            this.gameObject.SetActive(false);
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
