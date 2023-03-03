using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControl : MonoBehaviour
{
    //HP�񕜐H�ו�

    GameObject player;
    PlayerControl script;

    private float recovery=30.0f;//�񕜗�

    //���ʉ�
    public GameObject foodSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //HP��
            if (script.HPLimit - script.HP > recovery ) {
                script.HP += recovery;
            }
            else if (script.HPLimit - script.HP > 0)
            {
                script.HP = script.HPLimit;
            }
            Instantiate(foodSound, this.transform.position, this.transform.rotation);//���ʉ�
            Destroy(gameObject);
        }

    }
}
