using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRecoveryBook : MonoBehaviour
{
    //HP������

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
            script.Rec=true;
            script.Ui = "HP������GET";
            script.UiDecision = true;
            Destroy(gameObject);
        }

    }
}
