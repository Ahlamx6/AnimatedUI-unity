using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playanimation : MonoBehaviour
{
    private Animator anim;
    private static readonly int isDying = Animator.StringToHash("isDead");
    private static readonly int BeingHit = Animator.StringToHash("BeingHit");
    private static readonly int isLaughing = Animator.StringToHash("Play");
    private static readonly int ColorChange = Animator.StringToHash("ColorChange");

    [SerializeField] private Transform boxSpawnpoint;
    [SerializeField] private GameObject Box;

    [SerializeField] private Image healthbar;
    [SerializeField] private float healthAmount;
    [SerializeField] private Animator ChangeColor;

    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        healthbar.fillAmount = healthAmount;

        if (Input.GetButtonDown("Fire1"))
          anim.SetTrigger("Play");

        if (Input.GetButtonDown("Jump"))
           Instantiate(Box, boxSpawnpoint.position, boxSpawnpoint.rotation);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger(BeingHit);
            healthAmount -=0.25f;
            //anim.SetTrigger(ColorChange);

            if(healthAmount <= 0)
            {
                anim.SetBool(isDying, true);
            }
        }
    }
}
