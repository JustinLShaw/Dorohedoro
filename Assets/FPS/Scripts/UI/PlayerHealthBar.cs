using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [Tooltip("Image component dispplaying current health")]
    public Image healthFillImage;

    public Image num1;
    public Image num2;
    public Image num3;
    public Sprite[] nums;

    Health m_PlayerHealth;

    private void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

        m_PlayerHealth = playerCharacterController.GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this, playerCharacterController.gameObject);
    }

    void Update()
    {
        // update health bar value
        healthFillImage.fillAmount = m_PlayerHealth.currentHealth / m_PlayerHealth.maxHealth;

        if(m_PlayerHealth.currentHealth == 100){
            num1.color = new Color(255, 255, 255, 1);
            num2.color = new Color(255, 255, 255, 1);
            num3.color = new Color(255, 255, 255, 1);

            num1.sprite = nums[1];
            num2.sprite = nums[0];
            num3.sprite = nums[0];
        } else {

            num1.color = new Color(0, 0, 0, 0);

            int curHealth = (int) m_PlayerHealth.currentHealth;

            if(curHealth/10 == 0){
                num2.color = new Color(0, 0, 0, 0);
            } else {
                num2.color = new Color(255, 255, 255, 1);
            }

            num3.sprite = nums[curHealth%10];

            curHealth /= 10;

            num2.sprite = curHealth%10 != 0 ? nums[curHealth%10] : null;
        }
    }
}
