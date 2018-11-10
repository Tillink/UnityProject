using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAI : MonoBehaviour
{
//이 AI는 Waypoint와 Chase를 운용하는 스크립트임.
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

    #region forChasing
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
    #endregion

    // void Update() {
    //     Move(trTargets[nCurTarget]);
    //     NextCheck();
    // }
    
    // void Move(Transform trTarget_) {
    //     gameObject.transform.LookAt(trTarget_);//목적지를 본다
    //     gameObject.transform.Translate(Vector3.forward*Time.deltaTime*fMoveSpeed, Space.Self);//앞으로 간다
	// }

    // //도착 확인
    // void NextCheck()
    // {
    //     float fCurDis = Vector3.Distance(
    //         gameObject.transform.position, trTargets[nCurTarget].position);//현재 목적지 거리 계산
    //     if(fCurDis<fDisMin)//목적지에 가까워지면
    //     {
    //         nCurTarget++;//다음 목적지로 지정
    //         if (nCurTarget >= trTargets.Count)
    //             nCurTarget = 0;//끝까지 목적지를 다 돌았으면 0으로 초기화
    //     }
    // }

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