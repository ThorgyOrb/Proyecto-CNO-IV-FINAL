using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use TMPRo
using TMPro;

public class BossBattleManager : MonoBehaviour
{
    public float bossTimer = 60f;
    public float bossTimerCountdown;
    public TextMeshProUGUI bossTimerText;
    public bool bossBattle = false;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        bossTimerCountdown = bossTimer;
        //StartCoroutine(BossBattle());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //update the bossTimerText to show the remaining time
        bossTimerText.text = "Showdown: " + bossTimerCountdown.ToString("0");
        if (bossBattle == false)
        {
            bossTimerCountdown -= Time.deltaTime;
        }
        if (bossTimerCountdown <= 0)
        {
            bossBattle = true;
            boss.SetActive(true);
        }
    }


    /*Creata coroutine that will spawn the boss after bossTimer seconds and will change the bossTimerText to remaining time
    IEnumerator BossBattle()
    {
        yield return new WaitForSeconds(bossTimer);
        bossBattle = true;
    }*/
}