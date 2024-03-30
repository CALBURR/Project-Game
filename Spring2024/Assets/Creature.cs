using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    [SerializeField] int health = 3;
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpForce = 10;
    public enum CreatureMovementType{tf, physics};
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;
    [Header("Physics")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpOffset = -0.5f;
    [SerializeField] float jumpRadius = 0.25f;
    [Header("Flavor")]
    [SerializeField] string creatureName = "Magno";
    public GameObject body;
    [SerializeField] private List<AnimationStateChanger> animationStateChangers;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Debug.Log(health);
        

        
    }

    void FixedUpdate(){
        
    }
    // Update is called once per frame
    void Update()
    {
        //MoveCreature(new Vector3(-1,-1,0));
    }

    public void MoveCreature(Vector3 direction){
        if(movementType == CreatureMovementType.tf){
            MoveCreatureTransform(direction);
        }else if(movementType == CreatureMovementType.physics){
            MoveCreatureRb(direction);
        }
        if(direction.x != 0){
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Walk",speed);
            }
        }else{
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Idle");
            }
        }
        

    }

    public void MoveCreatureRb(Vector3 direction){
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);
        if(rb.velocity.x < 0){
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }
        //rb.AddForce(direction * speed);
        //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
    public void MoveCreatureTransform(Vector3 direction){
        transform.position += direction * Time.deltaTime * speed;
    }

    public void Jump(){
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius, groundMask).Length > 0){
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Jump",speed);
            
        }
        }else{
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Idle");
            }
        }
    }
    public void Attack(){
        
    }
}
