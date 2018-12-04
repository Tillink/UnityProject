using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoint : MonoBehaviour {
    public List<Transform> trTargets = new List<Transform>();//경로
    internal int nCurTarget = 0;//현재 경로 번호
    public float fDisMin = 1f; //도달 판정 거리
    internal Vector3 destination;
    internal NavMeshAgent agent;
    internal bool isCameback = true;
    internal Transform returnPoint;
    private float range = 1;
    // Update is called once per frame
    void Update() {

        if(isCameback)
        {
        Move(trTargets[nCurTarget].transform.position);
        NextCheck(trTargets[nCurTarget].transform.position);
        }
        else
        {
            Move(returnPoint.position);
            NextCheck(returnPoint.position);
        }
    }
    void Move(Vector3 target)
    {
	    if (Vector3.Distance(destination, target) > range)
            {
                destination = target;
                agent.destination = destination;
            }
    }
    //도착 확인
    void NextCheck(Vector3 target)
    {
        float fCurDis = Vector3.Distance(
            transform.position, target);//현재 목적지 거리 계산
        if(fCurDis<fDisMin)//목적지에 가까워지면
        {
            nCurTarget++;//다음 목적지로 지정
            isCameback = true;
            if (nCurTarget >= trTargets.Count)
                nCurTarget = 0;//끝까지 목적지를 다 돌았으면 0으로 초기화
        }
    }
}
