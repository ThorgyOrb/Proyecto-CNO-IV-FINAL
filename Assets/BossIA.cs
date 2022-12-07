using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIA : MonoBehaviour
{
    public int bossHealth = 300;
    public GameObject[] bossProjectiles;
    public GameObject[] bossDestruction;
    public GameObject shootPoint;
    public float[] bossAttackCooldown;
    public float currentAttackCooldown;
    public bool hasAttacked = false;
    public float firstAttackCooldown = 2f;
    public RainbowBloom rainbowBloom;
    public ShakeCamera shakeCamera;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        hasAttacked = true;
        StartCoroutine(FirstAttack());
    }

    // Update is called once per frame
    void Update()
    {
        //make the boss attack according to 3 states depending on the bossHealth
        if (bossHealth > 230 && !hasAttacked)
        {
            //set rainbowBloom hasGoodHealth to true
            rainbowBloom.hasGoodHealth = true;
            rainbowBloom.hasMediumHealth = false;
            rainbowBloom.hasBadHealth = false;
            //attack 1
            //Make bossDestruction[0] invisible
            bossDestruction[0].SetActive(false);
            bossDestruction[1].SetActive(false);
            bossDestruction[2].SetActive(false);
            StartCoroutine(Attack(0, 0));
        }
        else if (bossHealth > 150 && !hasAttacked)
        {
            //set rainbowBloom hasGoodHealth to false
            rainbowBloom.hasGoodHealth = true;
            rainbowBloom.hasMediumHealth = false;
            rainbowBloom.hasBadHealth = false;
            //make visible the bossDestruction[0]
            bossDestruction[0].SetActive(true);
            bossDestruction[1].SetActive(false);
            bossDestruction[2].SetActive(false);
            //attack 2
            StartCoroutine(Attack(1, 1));
        }
        else if (bossHealth > 100 && !hasAttacked)
        {
            //set rainbowBloom hasGoodHealth to false
            rainbowBloom.hasGoodHealth = false;
            //set rainbowBloom hasMediumHealth to true
            rainbowBloom.hasMediumHealth = true;
            rainbowBloom.hasBadHealth = false;
            //make visible the bossDestruction[1]
            bossDestruction[0].SetActive(true);
            bossDestruction[1].SetActive(true);
            bossDestruction[2].SetActive(false);
            //attack 3
            StartCoroutine(Attack(2, 2));
        }
        else if (bossHealth <= 100 && !hasAttacked)
        {
            //set rainbowBloom hasGoodHealth to false
            rainbowBloom.hasGoodHealth = false;
            //set rainbowBloom hasMediumHealth to false
            rainbowBloom.hasMediumHealth = false;
            //set rainbowBloom hasBadHealth to true
            rainbowBloom.hasBadHealth = true;
            //make visible the bossDestruction[2]
            bossDestruction[0].SetActive(true);
            bossDestruction[1].SetActive(true);
            bossDestruction[2].SetActive(true);
            //attack 3
            StartCoroutine(Attack(3, 3));
        }

        //if the bossHealth is 0, destroy the boss
        if (bossHealth <= 0)
        {
            //shake the camera
            shakeCamera.Shake(1f);
            //destroy the boss
            StartCoroutine(DestroyBoss());
        }
    }

    IEnumerator Attack(int attack, int cooldown)
    {
        if (attack == 3){
            //spawn the projectile on y = -3.5 and X randomly between -11 and 13
            Instantiate(bossProjectiles[attack], new Vector3(Random.Range(-11, 13), -3.5f, 0), shootPoint.transform.rotation);
        }else{
            //spawn the projectile at the shootPoint
            Instantiate(bossProjectiles[attack], shootPoint.transform.position, shootPoint.transform.rotation);
        }
        //set the cooldown
        currentAttackCooldown = bossAttackCooldown[cooldown];
        //set hasAttacked to true
        hasAttacked = true;
        //wait for the cooldown
        yield return new WaitForSeconds(currentAttackCooldown);
        //set hasAttacked to false
        hasAttacked = false;
    }

    IEnumerator FirstAttack()
    {
        //wait for the firstAttackCooldown
        yield return new WaitForSeconds(firstAttackCooldown);
        //set hasAttacked to false
        hasAttacked = false;
    }

    IEnumerator DestroyBoss()
    {
        //wait for 1 second
        yield return new WaitForSeconds(1);
        //activate the explosion
        explosion.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        //destroy the boss
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the boss collides with a projectile, decrease the bossHealth
        if (collision.gameObject.tag == "Playerbullet")
        {
            bossHealth -= 10;
        }
    }
}
