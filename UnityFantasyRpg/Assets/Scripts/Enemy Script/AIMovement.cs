using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    Rigidbody rb;

    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    public bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    [SerializeField]
    private bool isChasing = false;

    Transform player;
    NavMeshAgent nav;

    //Creating EnemyGolem Script Variable
    EnemyGolem enemyGolemScript;

    public GameObject AttackScript;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        //Using TryGetComponent here to prevent null reference errors on your enemies that are NOT a Golem
        //If any other enemies have a jump, you will need to do this for each. This is where I would suggest a refactor because this goes against the norm of how Unity is meant to function
        AttackScript.TryGetComponent<EnemyGolem>(out enemyGolemScript);

        AttackScript.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isWandering == false && !isChasing){
            StartCoroutine(Wander());
        }
        if(isRotatingRight == true){
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if(isRotatingLeft == true){
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }

        if(!isFront() || !isLineOfSight()){
            //Grabbing the isJumping variable and just returning (leaving the statement) if it is true
            if(enemyGolemScript != null){
                if (enemyGolemScript.isJumping) return;
            }
                

            isChasing = false;
            AttackScript.SetActive(false);
        }
     
        if(isFront() && isLineOfSight())
        {
            isChasing = true;
            float dist = Vector3.Distance(this.transform.position, player.transform.position);
            nav.SetDestination(player.position);
            transform.LookAt(player.transform);

            if (dist <= 12 && (this.gameObject.tag == "RangeEnemy") || (this.gameObject.tag == "TormentedSoul") ){
                AttackScript.SetActive(true);
            } else if ((dist <= 3 && this.gameObject.tag == "MeleeEnemy")||(dist <= 3 && this.gameObject.tag == "Goblin") || (dist <= 5 && this.gameObject.tag == "Golem")){
                AttackScript.SetActive(true);
            }
            else
            {
                //Grabbing the isJumping variable and just returning (leaving the statement) if it is true
                if(enemyGolemScript != null){
                    if (enemyGolemScript.isJumping) return;
                }
                
                AttackScript.SetActive(false);
            }
        }else{
            isChasing = false;
        }

    }

    private void FixedUpdate()
    {
        if (isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed * Time.deltaTime);
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
        RaycastHit[] _hit;
        Vector3 directionOfPlayer = player.position - transform.position;
        _hit = Physics.RaycastAll(transform.position,directionOfPlayer, 10f);

        foreach(RaycastHit hit in _hit){
            if(hit.transform.gameObject.tag == "Player"){
                //Debug.Log("Hit Raycast " + hit.transform.gameObject.tag);
                Debug.DrawLine(transform.position, player.position, Color.green);
                return true;
            }
        }

        return false;
    }
}
