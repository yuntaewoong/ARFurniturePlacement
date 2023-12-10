# ARFurniturePlacement
- 개발 기간: 2023.09.18 ~ 2023.12.03
- 유니티 버전: 2022.3.10 LTS
- 실행 Device: Meta Quest 3
  
# 프로젝트 소개
2023년 2학기 졸업프로젝트에서 진행한 프로젝트입니다.  
Amazon,IKEA등에서 제공하는 AR 가구 배치 서비스의 기능을 개선하는 것이 목표입니다.  
[소개 유튜브 영상](https://www.youtube.com/watch?v=eDFdzBcUpvk)


# 프로젝트 실행방법
1. Git Clone
2. Unity 2022.3.10 LTS버전으로 프로젝트 실행
3. 안드로이드 apk 빌드
4. SideQuest, Meta Quest Developer Hub같은 툴을 이용해서 Meta Quest3에 APK 설치
5. 실행

# 기존 AR 가구 배치 서비스와의 차별점
- Depth센서를 이용한 현실 조명효과
  구현 방법: Oculus Intergration SDK의 Mesh API를 이용해서   
  사용자의 방 Mesh를 로딩하고  
  로딩된 Mesh에 조명효과를 적용해주는 Custom Shader적용
- Occlusion효과  
  구현 방법: Oculus Intergration SDK의 Depth API를 이용해서 구현


# 최종 논문
[최종논문.pdf](https://github.com/yuntaewoong/ARFurniturePlacement/Paper/2018102213윤태웅_최종보고서.pdf)
