using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSpeedBook : MonoBehaviour
{
    //�U�����xUP

    GameObject player;
    PlayerControl script;

    //���ʉ�
    public GameObject bookSound;

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
            Instantiate(bookSound, this.transform.position, this.transform.rotation);//���ʉ�
            script.TimeGun-=0.4f;
            script.Ui = "�U�����xUP";
            script.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
