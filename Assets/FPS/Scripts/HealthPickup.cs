using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public float healAmount = 100.0f;

    public Pickup m_Pickup;
    WeaponController weapon_controller = null;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        weapon_controller = FindObjectsOfType<WeaponController>()[0];

        // Subscribe to pickup action
        //m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.canPickup())
        {
            playerHealth.Heal(healAmount);
            weapon_controller.m_CurrentAmmo = 100.0f;

            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        }
    }
}
