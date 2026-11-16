using System;
using UnityEngine;
using UnityEngine.Profiling;

public class EventMemoryTester : MonoBehaviour
{
    // 실무 표준 방식: event 키워드 + Action<int> 만능 대리자 결합
    public event Action<int> OnScoreChanged;

    private int score = 0;

    void Start()
    {
        // 올바른 습관: 이벤트 구독(+=)은 Start나 OnEnable에서 딱 1번만 해야 함!
        OnScoreChanged += UpdateScoreUI;
    }

    void OnDestroy()
    {
        // 매우 중요 (메모리 누수 방지): 객체가 파괴될 때 반드시 구독 해제(-=)를 해줘야 함!
        // 만약 안 빼주면, 이 객체가 파괴되어도 이벤트가 주소를 잡고 있어서 GC가 메모리를 못 치움!
        OnScoreChanged -= UpdateScoreUI;
    }

    void Update()
    {
        // [실험 1] 나쁜 예: Update에서 매 프레임 이벤트를 등록(+=)하고 빼는(-=) 실수 (100번 반복)
        // delegate는 불변에 가까워서 += 할 때마다 힙에 새 배열(목록)을 찍어냄!
        Profiler.BeginSample("01_Bad_DelegateAlloc");
        for (int i = 0; i < 100; i++)
        {
            OnScoreChanged += DummyMethod;
            OnScoreChanged -= DummyMethod;
        }
        Profiler.EndSample();

        // [실험 2] 좋은 예: 이미 연결된 이벤트를 호출(Invoke)만 할 때 (100번 반복)
        // 연결된 함수를 부르기만 하는 것은 힙 메모리(GC)가 단 1바이트도 들지 않음!
        Profiler.BeginSample("02_Good_EventInvoke");
        for (int i = 0; i < 100; i++)
        {
            OnScoreChanged?.Invoke(score); // 등록된 모든 함수에 방송 송출! (GC 0B!)
        }
        Profiler.EndSample();
    }

    void UpdateScoreUI(int newScore) { /* 점수가 바뀔 때만 실행되는 UI 로직 */ }
    void DummyMethod(int val) { }
}