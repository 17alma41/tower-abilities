using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    LinearMovement linearMovement;
    [SerializeField] List<ClasePadre> abilities;
    int selectedAbilityIndex = 0;

    CoolDown cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = GetComponent<CoolDown>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedAbilityIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedAbilityIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedAbilityIndex = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selectedAbilityIndex = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            selectedAbilityIndex = 4;

        Vector3 mousePos = new Vector3(0, 0, 0);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 targetDir = (mousePos - transform.position).normalized;
        float angle = Vector3.SignedAngle (Vector3.up, targetDir, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            abilities[selectedAbilityIndex].Trigger(targetDir);
            cooldown.StartCooldown();
        }

    }
}
