using System.Collections.Generic;
using System.Linq; // LINQ를 쓰기 위해 추가
using UnityEngine;
using UnityEngine.Profiling;

public class LinqClosureTester : MonoBehaviour
{
    private List<int> monsterHps = new List<int>(1000);

    void Start()
    {
        // 시작할 때 몬스터 1,000마리의 체력을 1~100 사이로 넣어둠
        for (int i = 0; i < 1000; i++)
        {
            monsterHps.Add(i % 100);
        }
    }

    void Update()
    {
        int minHp = 50;

        // [실험 1] 나쁜 예: LINQ + 외부 지역 변수(minHp) 캡처(클로저) 사용 (100번 반복)
        // 코드가 한 줄이라 너무 편하지만, 실행될 때마다 클로저 클래스 + LINQ 반복자가 힙에 생성됨!
        Profiler.BeginSample("01_Bad_LinqAndClosure");
        int count1 = 0;
        for (int i = 0; i < 100; i++)
        {
            // 람다식(hp => hp > minHp)이 바깥 변수 minHp를 쓰는 순간 힙 메모리 할당 폭발!
            count1 = monsterHps.Where(hp => hp > minHp).Count();
        }
        Profiler.EndSample();

        // [실험 2] 좋은 예: 투박하지만 정직한 일반 for문 사용 (100번 반복)
        // 힙 메모리를 단 1바이트도 쓰지 않고 스택에서만 초고속으로 계산함!
        Profiler.BeginSample("02_Good_StandardForLoop");
        int count2 = 0;
        for (int i = 0; i < 100; i++)
        {
            count2 = 0;
            for (int j = 0; j < monsterHps.Count; j++)
            {
                if (monsterHps[j] > minHp)
                {
                    count2++;
                }
            }
        }
        Profiler.EndSample();
    }
}