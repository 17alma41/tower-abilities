using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    [SerializeField] Image ability1;

    [SerializeField] float cooldownTime;
    float cooldownEndTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cooldownEndTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > cooldownEndTime)
        {
            ability1.fillAmount = 1f;
        }
        else
        {
            float timeRemaining = (cooldownEndTime - Time.time) / cooldownTime;
            ability1.fillAmount = Mathf.Clamp(1f - timeRemaining, 0f, 1f);
        }
    }

    public void StartCooldown()
    {
        cooldownEndTime = Time.time + cooldownTime; 
    }
}
