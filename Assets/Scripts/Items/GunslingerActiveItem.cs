using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunslingerActiveItem : MonoBehaviour
{
    [SerializeField] Animator activeItemFrameAnimator;
    PlayerController controller;

    bool activation = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateItem()
    {
        if(!activation)
        {
            activation = true;
            StartCoroutine(Activation());
        }
        else
        {
            Debug.Log("ON COOLDOWN");
        }
    }

    IEnumerator Activation()
    {
        float defaultValue = controller.playerDamage;
        controller.playerDamage += 10000;
        activeItemFrameAnimator.SetBool("IsActive", true);
        yield return new WaitForSeconds(10);
        activeItemFrameAnimator.SetBool("IsActive", false);
        activeItemFrameAnimator.SetBool("IsCooldown", true);
        controller.playerDamage -= 20000;
        yield return new WaitForSeconds(10);
        controller.playerDamage = defaultValue;
        activeItemFrameAnimator.SetBool("IsCooldown", false);
        activation = false;
    }
}
