using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    dash,
    interact,
    atack,
    stagger,
    idle,
}

public class PlayerMovement : MonoBehaviour
{
	public PlayerState currentState;
    public float speed;
	private Rigidbody2D myRigidbody;
    private Vector3 change;
    private  Vector3 Dashchange;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;


    private Animator animator;
    // Start is called before the first frame update
    void Start(){
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update(){
        change = Vector3.zero;
	    change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("atack") && currentState != PlayerState.atack 
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AtackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle){
            UpdateAnimationMove();    
        }

        // else if (Input.GetButtonDown("dash") && currentState != PlayerState.dash){
        //     StartCoroutine(DashCo());
        // }
    }

    private IEnumerator AtackCo(){

        animator.SetBool("atacking", true);
        currentState = PlayerState.atack;
        yield return null;
        animator.SetBool("atacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    // private IEnumerator DashCo(){
    //     Dashchange = Vector3.zero;
    //     animator.SetBool("dashing", true);
    //     currentState = PlayerState.dash;
    //     yield return null;
    //     animator.SetBool("dashing", false);
    //     yield return new WaitForSeconds(0.5f);
        
    //     Dashchange.x = Input.GetAxisRaw("Horizontal");
    //     Dashchange.y = Input.GetAxisRaw("Vertical");

    //    if (Dashchange.x > 0){
    //         transform.position += Vector3.left;
    //    }

    // //    if (Dashchange.x < 0){
    // //         transform.position += 1;
    // //    }

    //     // Vector3 dashVector = myRigidbody.transform.position + (Vector3)playerFacingDirection.normalized * dashForce;

    //     currentState = PlayerState.walk;
    // }

    void UpdateAnimationMove(){
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter(){
        change.Normalize();
        if( Input.GetKey("e")){
            myRigidbody.MovePosition(
                transform.position + change * speed * 2 * Time.deltaTime
            );
        }else{
            myRigidbody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );
        }
    }

    public void Knock( float knockTime, float damage){
        currentHealth.initialValue -= damage;
        if (currentHealth.initialValue > 0){
            playerHealthSignal.Raise();
            StartCoroutine(KnockCo(knockTime));
        } 
    }

     private IEnumerator KnockCo(float knockTime){
        if (myRigidbody != null ){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }
}