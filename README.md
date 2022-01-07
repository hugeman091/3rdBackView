# 3rdBackView
<details>
  <summary> click </summary>
3인칭 백뷰

https://youtu.be/537B1kJp9YQ 참고

<img src="https://user-images.githubusercontent.com/84231954/145943447-132b7da4-872e-41ff-8990-26254e5736f2.gif">
</details>
 
# Loaming
<details>
  <summary> click </summary>
오브젝트 로밍
 
  
<img src="https://user-images.githubusercontent.com/84231954/145973894-48c9cbf4-27ff-4119-bb83-0062a377787a.gif">
</details>

# Channel ScriptableObject
<details>
  <summary> click </summary>
  
monobehaviour대신 사용하는 ScriptableObject를 이용한 decoupling 구조

https://youtu.be/WLDgtRNK2VE 참고

<img src="https://user-images.githubusercontent.com/84231954/146162376-de3ff9cf-7c7e-49a8-a86b-c66ce87ef2f0.gif">
</details>

# ScriptableObject with controller
<details>
  <summary> click </summary>

  scriptable object를 이용해 animation, move, input 같의 의존성을 최소화 한 구조
  
</details>

# Simple Object Pool
<details>
  <summary> click </summary>
  
심플한 오브젝트 풀

<img src="https://user-images.githubusercontent.com/84231954/147627491-27d1b13b-1131-410f-892d-036b32c1c134.gif">
</details>

# PlayerHP UI (ScriptableObject Variable / ScriptableObject Event)
<details>
  <summary> click </summary>
 
 scriptableObject를 이용한 HealthValue와 이벤트 콜백

<img src="https://user-images.githubusercontent.com/84231954/147641949-60e6ccfb-feca-4164-b4fc-a0af36db4dd4.gif">
<img src="https://user-images.githubusercontent.com/84231954/147641722-f23e0488-ff1a-4b96-b588-1aad9dc6c5a4.png">
<img src="https://user-images.githubusercontent.com/84231954/147641750-e407f6c1-711a-4cc9-9879-23e23aaf624c.png">
<img src="https://user-images.githubusercontent.com/84231954/147725970-fe557215-e342-4f77-851b-e81bc4aba0b2.png">
</details>


# Inventory 
<details>
  <summary> click </summary>

 InventoryContainer : Equip 이벤트 실행
  InventoryUI, EquipUI -> Equip 이벤트 Listen
<img src="https://user-images.githubusercontent.com/84231954/147725311-b6eed81e-2cc2-4c7f-abee-af2d24ddbd7c.gif">
<img src="https://user-images.githubusercontent.com/84231954/147725850-919d97c6-ece3-4588-988b-4cee2d48ec51.png">
<img src="https://user-images.githubusercontent.com/84231954/147725854-3baddd29-fa10-4683-b30c-89b14af4e373.png">
<img src="https://user-images.githubusercontent.com/84231954/147725875-a948e9df-8687-4b17-8470-156b7f183692.png">
<img src="https://user-images.githubusercontent.com/84231954/147725939-3a017229-06e9-44ca-b63f-7af17039739f.png">
  
</details>

# Convert scriptableobject to json 
<details>
  <summary> click </summary>

아이템 제작은 UnityClient에서 scriptableobject로 생산성 증가
서버에서도 같은 데이터 사용을 위해 json컨버팅작업
서버에서는 json데이터 파싱 후 사용

<img src="https://user-images.githubusercontent.com/84231954/147738590-e496d8ec-496d-44bd-b194-f9e06586651f.gif">
<img src="https://user-images.githubusercontent.com/84231954/147738454-9ba60af5-f1e0-4854-8cf1-fae0b317d72e.png">
<img src="https://user-images.githubusercontent.com/84231954/147738483-7fb4fa2c-ad66-43a3-89b3-8d0a4e360333.png">
<img src="https://user-images.githubusercontent.com/84231954/147739926-d58584ec-0e36-42d8-965d-2654a01bc741.png">

</details>


# ChangeScene
<details>
  <summary> click </summary>

  Scene 변경과 SceneStack으로 Scene돌아가기

<img src="https://user-images.githubusercontent.com/84231954/147807485-32a384e0-9efd-418d-a942-584e7262c793.gif">
<img src="https://user-images.githubusercontent.com/84231954/147807565-b9f527d0-079d-402d-b47d-9f58b52ccd99.png">
<img src="https://user-images.githubusercontent.com/84231954/147807596-b32e33f0-3f31-4389-a99d-bb4e67b69763.png">
<img src="https://user-images.githubusercontent.com/84231954/147807639-95f136a0-f7a8-43f9-8b1f-76fdc057ebfe.png">
<img src="https://user-images.githubusercontent.com/84231954/147807547-61ddd28e-98d5-4f3a-8e2b-88dac9a9070c.png">
</details>


# Player Currency UI
<details>
  <summary> click </summary>

  유저 재화 UI SO value 이용하여 하나의 SO value를 참조.
  서버를 고려하자면 Packet을 받았을때 SO value만 변경하면 UI에 자동으로 반영.
  
  왜 TMP_Pro.Text가 콜백으로 업데이트 되지 않는지는 모르겠으나 아쉬운대로 update에서 갱신해두록 변경
  Prefab은 NestedPrefab으로 제작 가능.
  
<img src="https://user-images.githubusercontent.com/84231954/147825288-dc6c3588-d816-40b2-b4a6-23a6877d99eb.gif">
<img src="https://user-images.githubusercontent.com/84231954/147825299-dcc8cd7a-222f-417b-bd54-4a6273a9c640.gif">
<img src="https://user-images.githubusercontent.com/84231954/147825313-15d50edd-5c86-43cc-abb0-ee40c7e46333.png">
<img src="https://user-images.githubusercontent.com/84231954/147825354-fab901f5-83de-4d93-a4a0-17f5660a5a0b.png">
<img src="https://user-images.githubusercontent.com/84231954/147825377-25e626fb-d424-4d72-8fb0-89f3c41151e4.png">

</details>


# Player Status
<details>
  <summary> click </summary>

  패킷으로 변경데이터를 받았다는 가정하에 SO유저데이터를 기반으로 각 UI들에 event를 보내서 갱신하도록 수정.
  EXP의 경우 경험치 테이블을 SO파일로 저장해서 사용.

<img src="https://user-images.githubusercontent.com/84231954/147881586-66b1f00e-77a2-45da-980b-3c77319c496b.gif">
<img src="https://user-images.githubusercontent.com/84231954/147881713-7354561a-e65e-45ab-9b18-e139c70dc5be.png">
  
</details>


# Basic combat system based on SO datatable
<details>
  <summary> click </summary>

  기본 전투 시스템에 데이터 테이블 적용.
  scriptableObject로 데이터 테이블, 데이터 컨테이너 사용.

<img src="https://user-images.githubusercontent.com/84231954/148046194-c452d4fe-43b0-4828-a766-c7535d967d90.gif">
<img src="https://user-images.githubusercontent.com/84231954/148046364-47a8b8af-33cf-4063-807c-6ab396c5a751.png">
<img src="https://user-images.githubusercontent.com/84231954/148046426-40e8757f-6372-4170-b04f-54689f87053d.png">

</details>


# Inventory2
<details>
  <summary> click </summary>

  아이템 테이블 기반 인벤토리 간단하게 만들어놓을 용도

<img src="https://user-images.githubusercontent.com/84231954/148187172-8b0a2414-7bcf-41f8-b777-bf07b76424d8.gif">
<img src="https://user-images.githubusercontent.com/84231954/148187286-49d59ce4-570b-457b-8cb0-8c0930c2964d.png">
<img src="https://user-images.githubusercontent.com/84231954/148187352-c67175e4-4a1a-4739-9e50-e19bdd07acaf.png">

</details>


# Unirx UICountdown
<details>
  <summary> click </summary>

  Unirx를 이용한 스킬 아이콘 countdown. milisecond단위까지 가니 느려졌다.

<img src="https://user-images.githubusercontent.com/84231954/148251675-f7031058-92a1-4c6c-9d26-8c28e6d54002.gif">

</details>


# Dotween UI Slider
<details>
  <summary> click </summary>

  Dotween slider애니메이션

<img src="https://user-images.githubusercontent.com/84231954/148338108-5468811a-52df-41d7-8b9b-a530b63d3d70.gif">

</details>


# UniTask RankingUI with RedisDB
<details>
  <summary> click </summary>

  ASP.NET WebAPI를 이용해 로컬 RedisDB와 연결.
  UniTask 사용하여 async로 클라이언트에서 서버로 redis 랭킹데이터 요청.
  파싱 후 랭킹 표시
  
  코드는 하드코딩좀 되어있는 상태

<img src="https://user-images.githubusercontent.com/84231954/148414323-ce9add51-2085-4c57-8572-01c3d57a3530.gif">
<img src="https://user-images.githubusercontent.com/84231954/148414373-f88e934d-89ea-4410-8b25-76ba17aa67f4.png">
<img src="https://user-images.githubusercontent.com/84231954/148414412-baa45851-dc39-4769-9f8a-ac12ee6f9170.png">

</details>


# ASP.NET + MSSQL
<details>
  <summary> click </summary>

  AccountServer 만드는 와중에 기존에 사용하던 EFCore는 제거하고 SqlClient사용해서 MSSQL연결
  웹 API Tester로 수신 테스트

<img src="https://user-images.githubusercontent.com/84231954/148585115-b080c6ec-5d1b-4bd7-b2f0-f263ef6c57e7.png">
<img src="https://user-images.githubusercontent.com/84231954/148585233-a48473c1-6b59-420a-a565-659faaca9785.png">
  
</details>
