using UnityEngine;
using System.Text;
using UnityEngine.Profiling;

public class MemoryTester : MonoBehaviour
{
    int score = 100;
    StringBuilder sb = new StringBuilder(50); // 힙에 미리 버퍼를 할당해 재사용

    void Update()
    {
        Profiler.BeginSample("MemoryTester_Bad");
        BadMemoryCode();  // 박싱 + 문자열(+) 연산
        Profiler.EndSample();

        Profiler.BeginSample("MemoryTester_Good");
        GoodMemoryCode(); // 원시 타입 유지 + StringBuilder 재사용
        Profiler.EndSample();
    }

    void BadMemoryCode()
    {
        for (int i = 0; i < 100; i++)
        {
            object boxed = score;
            string str = "현재 점수: " + boxed;
        }
    }

    void GoodMemoryCode()
    {
        for (int i = 0; i < 100; i++)
        {
            int unboxed = score;
            sb.Clear();
            sb.Append("현재 점수: ").Append(unboxed);
        }
    }
}