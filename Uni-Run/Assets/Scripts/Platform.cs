using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour 
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    public GameObject[] coins; //코인들
    public GameObject[] mushroom; //버섯들
    //public GameObject[] boxes; //박스들 

    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가


    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() 
    {
        // 발판을 리셋하는 처리
        stepped = false;
        // 장애물의 수만큼 루프
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
            coins[i].SetActive(false);
            mushroom[i].SetActive(false);
        }
        for (int i = 0; i < obstacles.Length; i++)
        {
            //현재 순번의 장애물을 1/5의 확률로 활성화
            if (Random.Range(0,5) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    coins[i].SetActive(true);
                }
                else if(Random.Range(0,1) == 0)
                {
                    mushroom[i].SetActive(true);
                }
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        stepped = true;
        GameManager.instance.AddScore(1);
    }
}