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
| **Week 01** | **Stack vs Heap & 박싱(Boxing)** | 박싱 제거 및 `StringBuilder` 버퍼 재사용 실험<br>*(GC 감소 검증 및 `int.ToString()` 내부 할당 원인 분석)* | [📝 벨로그 보러가기](https://velog.io/@c101892/posts) |
| **Week 02** | **Class vs Struct & Generic `<T>`** | 값/참조 복사 차이 분석 및 `Generic<T>`을 통한 구조체 박싱 원천 차단<br>*(프레임당 GC Alloc **39.1KB ➔ 0B** 달성)* | [📝 벨로그 보러가기](https://velog.io/@c101892/posts) |

<br>

## 📂 폴더 구조 (Directory Structure)
```text
CSharp-Memory-Lab/
├── Week01/
│   └── MemoryTester.cs     # 박싱(Boxing) 및 StringBuilder GC 할당 측정
├── Week02/
│   └── GenericTester.cs    # Object 박싱 vs Generic<T> Zero-GC 비교 측정
└── README.md
```