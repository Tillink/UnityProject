using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public List<Transform> trTargets = new List<Transform>();//경로
    public int nCurTarget = 0;//현재 경로 번호
    public GameObject goItem = null;//쫓아다닐 아이템
    public float fDisMin = 1f; //도달 판정 거리
    public float fMoveSpeed = 30;

    // Update is called once per frame
    void Update() {
        Move(trTargets[nCurTarget]);
        NextCheck();
    }
    void Move(Transform trTarget_) {
        goItem.transform.LookAt(trTarget_);//목적지를 본다
        goItem.transform.Translate(Vector3.forward*Time.deltaTime*fMoveSpeed, Space.Self);//앞으로 간다
	}

    //도착 확인
    void NextCheck()
    {
        float fCurDis = Vector3.Distance(
            goItem.transform.position, trTargets[nCurTarget].position);//현재 목적지 거리 계산
        if(fCurDis<fDisMin)//목적지에 가까워지면
        {
            nCurTarget++;//다음 목적지로 지정
            if (nCurTarget >= trTargets.Count)
                nCurTarget = 0;//끝까지 목적지를 다 돌았으면 0으로 초기화
        }
    }
}
