using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAI : MonoBehaviour
{

    public Transform target = null;//대상이 바뀌는 경우엔 반드시 null 표기가 필요
    Vector3 destination;
    NavMeshAgent agent;
    bool InRange = false;
    public float agrro = 0f;
    Vector3 comeback;
    public bool isStopped = false;
    public float speed = 1.0f;
    public float range = 1.0f;
    public Transform reaturnArea;//대상이 고정되서 지정만 하는 경우, 어차피 지정을 하지 않아도 null로 되므로 지정을 안해도 괜찮다.
    public Transform spawn;
    //public GameObject go = new GameObject();
    private Ray _ray;
    private RaycastHit _raycastHit;
    public enum state
    {
        stay,
        watching,
        patrol,
        attck,
        //장기적으로 고려할 부분.
        //평시-감시-경계-공격-행동불가 패턴이 있어야 할 것.
    }

    //어그로 수치에 따라 행동 시작.
    //어그로 수치가 낮은 정도를 넘으면 플레이어를 계속 봄
    //어그로 수치가 중간 수준을 넘으면 플레이어를 따라감
    //어그로 수치가 매우 높은 수준을 넘으면 빠른 속도로 따라감
    //어그로가 높아도 범위 밖으로 나가면 추적을 포기하고 원래 경로로 돌아감.
    //평소엔 어그로가 낮아지고 있으나, 범위 안에 들어오면 점차 증가치가 늘어남.
    //경비병이 
    // Use this for initialization
    public Vector3 ReturnPoint;
    void OnEnable()
    {
        
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        
    }
    void Start()
    {
        
        ReturnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            if (Vector3.Distance(destination, target.position) > range)
            {
                destination = target.position;
                agent.destination = destination;
                
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            {
               Physics.SphereCast(transform.position, 3f, transform.TransformDirection(Vector3.forward), out _raycastHit, Mathf.Infinity);
               if(_raycastHit.collider.tag == "Player")
                {
                  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _raycastHit.distance, Color.yellow);
                  Debug.Log(_raycastHit.collider.tag);
                   target = other.gameObject.transform;
                  agent.speed = 2.0f;
                  isStopped = false;
                   Debug.Log("가");
                  agrro++;
                }
            else
                {
                  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                  Debug.Log(_raycastHit.collider.name);
                }                

            }
        }
    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            agent.destination = transform.position;
            isStopped = true;
            Debug.Log("멈춰");
        }
    }

}

// 기본적인 내비매쉬 AI
//     public Transform target;
//     Vector3 destination;
//     NavMeshAgent agent;


//     // Use this for initialization
//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         destination = agent.destination;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (target != null)
//         {


//             if (Vector3.Distance(destination, target.position) > 1.0f)
//             {
//                 destination = target.position;
//                 agent.destination = destination;
//             }
//         }
//     }
//     void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             target = other.gameObject.transform;
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             target = null;
//             agent.destination = transform.position;
//         }
//     }

// }