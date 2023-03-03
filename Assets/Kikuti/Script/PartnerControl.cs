using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerControl : MonoBehaviour
{
    //����

    [SerializeField] private Transform playerTrans;
    [SerializeField] private float speed;

    private float interval=4;//�Ǐ]�Ԋu

    private float timeGun = 4;//�U�����x
    private float timeElapsed;
    public GameObject partnerGun;

    GameObject player;
    PlayerControl script;

    //���ʉ�
    public GameObject partnerSound;
    private bool sound=true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();


    }

    // Update is called once per frame
    void Update()
    {
        //�Ǐ]�J�n
        if (script.OnParther == true) {
            if(sound==true)
            {
                Instantiate(partnerSound, this.transform.position, this.transform.rotation);//���ʉ�
                sound=false;
            }

            //�U���e����
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeGun)
            {
               Instantiate(partnerGun, transform.position, transform.rotation);
               timeElapsed = 0.0f;
            }

            //�ړ�
            if (script.Direction == PlayerControl.PlayerDirection.RIGHT)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x - interval, playerTrans.position.y + interval), speed);
               
            }
            else if (script.Direction == PlayerControl.PlayerDirection.LEFT)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x + interval, playerTrans.position.y - interval), speed);
                
            }
            else if (script.Direction == PlayerControl.PlayerDirection.UP)
            {
                this.transform.position =
                  Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x - interval, playerTrans.position.y - interval), speed);
                
            }
            else if (script.Direction == PlayerControl.PlayerDirection.DOWN)
            {
                this.transform.position =
                 Vector2.MoveTowards(this.transform.position, new Vector2(playerTrans.position.x + interval, playerTrans.position.y + interval), speed);
                
            }
        }

       

    }
 

}
