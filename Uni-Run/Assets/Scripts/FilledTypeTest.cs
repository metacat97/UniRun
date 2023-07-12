using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FilledTypeTest : MonoBehaviour
{
    public Image filledTypeImg;

    private void Awake()
    {
        filledTypeImg.fillAmount = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        //filledTypeImg.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        
        
    }

    private IEnumerator PassedCoolTime(float cooltimeDelay)
    {
        //�� �ð��� ��ŭ �� �� �ִ��� 
        float cooltimePercent = 1/100f;
        while (0< filledTypeImg.fillAmount)
        {
            //�̸�ŭ �ð��� �ɸ���.
            yield return new WaitForSeconds(cooltimeDelay);

            //�ð��� ������ ������ ó���Ѵ�.
            filledTypeImg.fillAmount -= cooltimePercent;
        }
    }

}
