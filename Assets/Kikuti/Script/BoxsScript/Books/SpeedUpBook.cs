using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBook : MonoBehaviour
{
    //�ړ����xUP

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
            script.Speed += (script.Speed*0.05f);
            script.Ui = "�ړ����xUP";
            script.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
