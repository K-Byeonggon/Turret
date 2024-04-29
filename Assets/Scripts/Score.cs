using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    [SerializeField] private bool invincible = false;
    

    private IEnumerator Invincible()
    {
        int countTime = 0;
        float maxCount = 10;
        invincible = true;
        while (countTime < maxCount)
        {
            if (countTime % 2 == 0)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 90);
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0, 180);
            }
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        invincible = false;
        gameObject.GetComponent<MeshRenderer>().material.color = new Color32(255, 0, 0, 255);
    }

    private void Start()
    {
        
        StartCoroutine(Invincible());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            if (invincible) return;
            //���� ���ϱ�
            GameManager.Instance.score += 10;

            //�������ϱ�
            GameObject newEnemy = Instantiate(gameObject, new Vector3(0, 0.5f, 4), Quaternion.identity);
            GameManager.Instance.enemy = newEnemy.transform;
            //�ױ�
            Destroy(gameObject);

        }
    }

}
