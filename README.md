# 🚀 C# & Unity Optimization Study

> **가물가물했던 CS/메모리 이론을 코드로 다시 구현하고, Unity Profiler로 직접 검증하는 아키텍처 & 최적화 실험실입니다.**

<br>

## 🛠️ Tech Stack & Tools
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Unity](https://img.shields.io/badge/Unity-000000?style=flat-square&logo=unity&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat-square&logo=github&logoColor=white)

<br>

## 📊 주차별 학습 및 최적화 검증 기록

| 주차 | 학습 주제 | 핵심 검증 및 최적화 결과 | 상세 분석 (Tech Blog) |
| :---: | :--- | :--- | :---: |
| **Week 01** | **Stack vs Heap & 박싱(Boxing)** | 박싱 제거 및 `StringBuilder` 버퍼 재사용 실험<br>*(GC 감소 검증 및 `int.ToString()` 내부 할당 원인 분석)* | [📝 벨로그 보러가기](https://velog.io/@c101892/CUnity-%EC%B5%9C%EC%A0%81%ED%99%94-1-%EA%B0%92-%ED%98%95%EC%8B%9D-vs-%EC%B0%B8%EC%A1%B0-%ED%98%95%EC%8B%9D-%EB%A9%94%EB%AA%A8%EB%A6%AC-%EA%B5%AC%EC%A1%B0%EC%99%80-%EB%B0%95%EC%8B%B1Boxing-GC-%EC%B5%9C%EC%A0%81%ED%99%94) |
| **Week 02** | **Class vs Struct & Generic `<T>`** | 값/참조 복사 차이 분석 및 `Generic<T>`을 통한 구조체 박싱 원천 차단<br>*(프레임당 GC Alloc **39.1KB ➔ 0B** 달성)* | [📝 벨로그 보러가기](https://velog.io/@c101892/CUnity-%EC%B5%9C%EC%A0%81%ED%99%94-2-Class-vs-Struct-%EB%A9%94%EB%AA%A8%EB%A6%AC-%EB%B3%B5%EC%82%AC-%EC%B0%A8%EC%9D%B4%EC%99%80-GenericT%EC%9D%84-%ED%86%B5%ED%95%9C-%EB%B0%95%EC%8B%B1Boxing-%EC%9B%90%EC%B2%9C-%EC%B0%A8%EB%8B%A8-GC-0B-%EA%B2%80%EC%A6%9D) |
| **Week 03** | **GC 원리 & Event/Delegate 최적화** | 세대별 GC 메커니즘 분석, `event Action` 캡슐화 및 `+=` 반복 할당 방지<br>*(구독 해제 `-=`를 통한 메모리 누수 차단 및 `Invoke` **GC 0B** 검증)* | [📝 벨로그 보러가기](https://velog.io/@c101892/CUnity-%EC%B5%9C%EC%A0%81%ED%99%94-3-%EA%B0%80%EB%B9%84%EC%A7%80-%EC%BB%AC%EB%A0%89%ED%84%B0GC-%EB%8F%99%EC%9E%91-%EC%9B%90%EB%A6%AC%EC%99%80-EventAction-%ED%99%9C%EC%9A%A9-%EC%8B%9C-%EB%A9%94%EB%AA%A8%EB%A6%AC-%EB%88%84%EC%88%98-%EB%B0%8F-GC-Alloc-%EB%B0%A9%EC%A7%80%EB%B2%95) |
| **Week 04** | **LINQ & 람다 클로저(Closure) 비용** | 람다식의 지역 변수 캡처(Closure) 시 숨겨진 클래스 힙 할당 원리 규명<br>*(`LINQ` 탐색을 일반 `for`문으로 대체하여 **GC 12.5KB ➔ 0B** 달성)* | [📝 벨로그 보러가기]https://velog.io/@c101892/CUnity-%EC%B5%9C%EC%A0%81%ED%99%94-4-LINQ%EC%99%80-%EB%9E%8C%EB%8B%A4%EC%8B%9D-%ED%81%B4%EB%A1%9C%EC%A0%80Closure%EA%B0%80-%ED%9E%99-%EB%A9%94%EB%AA%A8%EB%A6%ACGC%EB%A5%BC-%EC%9E%A0%EC%8B%9D%ED%95%98%EB%8A%94-%EC%9B%90%EB%A6%AC%EC%99%80-%EC%8B%A4%EC%A0%84-%EB%8C%80%EC%B2%B4%EB%B2%95 |
<br>

## 📂 폴더 구조 (Directory Structure)
```text
CSharp-Memory-Lab/
├── Week01/
│   └── MemoryTester.cs     # 박싱(Boxing) 및 StringBuilder GC 할당 측정
├── Week02/
│   └── GenericTester.cs    # Object 박싱 vs Generic<T> Zero-GC 비교 측정
├── Week03/
│   └── EventMemoryTester.cs  # Delegate 결합(+=) GC 할당 vs Event Invoke 비교 측정
├── Week04/
│   └── LinqClosureTester.cs  # LINQ/람다 클로저 GC 할당 vs 일반 for문 비교 측정
└── README.md
```