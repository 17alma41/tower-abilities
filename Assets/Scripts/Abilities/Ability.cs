using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject
{
    [SerializeField] string abilityName;
    public float cooldown;
    [HideInInspector] public float elapsedCooldown = 0f;
    protected bool isCooldown = false;

    protected Transform transform;

    public abstract void Trigger(Vector3 direction, MonoBehaviour mbCoroutine, List<Image> abilityIcon);

    public abstract void Transform(Transform player);


    public IEnumerator cooldownCouroutine(Image icon)
    {
        isCooldown = true;
        elapsedCooldown = 0f;

        while (elapsedCooldown <= cooldown)
        {
            elapsedCooldown += Time.deltaTime;
            icon.fillAmount = elapsedCooldown / cooldown;
            yield return null;  
        }

        isCooldown = false;
        icon.fillAmount = 1f;
    }


}
