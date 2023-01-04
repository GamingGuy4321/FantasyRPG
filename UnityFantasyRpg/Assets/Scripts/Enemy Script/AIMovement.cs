using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    Transform player;

    Rigidbody rb;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isFront();
        isLineOfSight();
        
        if(isWandering == false){
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true){
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if(isRotatingLeft == true){
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if(isWalking == true){
            rb.AddForce(transform.forward * movementSpeed);
        }

        if(isFront() && isLineOfSight()){
            
        }

    }

    IEnumerator Wander(){
        
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(2, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if(rotateDirection == 1){
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        if(rotateDirection == 2){
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;

    }

    bool isFront(){
            Vector3 directionOfPlayer = transform.position - player.position;
            float angle = Vector3.Angle(transform.forward, directionOfPlayer);

            if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270){
                Debug.DrawLine(transform.position, player.position, Color.red);
                return true;
            }

            return false;
        }

    bool isLineOfSight(){
        RaycastHit _hit;
        Vector3 directionOfPlayer = player.position - transform.position;

        if(Physics.Raycast(transform.position,directionOfPlayer, out _hit, 50000f)){
            if(_hit.transform.name == "Player"){
                Debug.DrawLine(transform.position, player.position, Color.green);
                return true;
            }
        }

        return false;
    }
}
