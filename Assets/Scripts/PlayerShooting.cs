using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Gun gun;
    private bool isHoldingShoot = false;

    void OnShoot()
    {
        isHoldingShoot = true;
    }

    void OnShootRelease()
    {
        isHoldingShoot = false;
    }

    void OnReload()
    {
        if (gun)
        {
            gun.TryReload();
        }
    }

    void Update()
    {
        if (isHoldingShoot && gun)
        {
            gun.Shoot();
        }
    }
}
