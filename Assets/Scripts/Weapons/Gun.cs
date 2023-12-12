using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // Barrel position used for visual effects
    public Transform barrelOrigin;

    public LayerMask enemyLayer;

    public GunStats stats;

    Camera cam;
    float fov;

    bool firing;
    bool reloading;

    // Initialization
    private void Awake()
    {
        cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();

        firing = false;
        reloading = false;
    }
    private void Start()
    {
        stats.currentMag = stats.magazineSize;
        stats.currentAmmo = stats.maxAmmo;
        fov = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.automatic)
        {
            // Checks if the mouse button is still pressed to keep firing
            if (Input.GetMouseButton(0) && !firing && !reloading && stats.currentMag > 0)
            {
                Shoot();
            }
        }
        else
        {
            // Checks individual clicks for non-automatic weapons
            if (Input.GetMouseButtonDown(0) && !firing && !reloading && stats.currentMag > 0)
            {
                Shoot();
            }
        }

        // reload if reload button is pressed while current mag isn't full and not reloading
        // OR left mouse button is held down while an automatic weapon runs out of ammo
        // OR left mouse button is pressed while a non-automatic weapon's magazine is empty
        if ((Input.GetKeyDown(KeyCode.R) && stats.currentMag < stats.magazineSize && !reloading) 
            || (Input.GetMouseButton(0) && !reloading && stats.currentMag == 0 && stats.automatic)
            || (Input.GetMouseButtonDown(0) && !reloading && stats.currentMag == 0 && !stats.automatic))
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(1))
        {
            ToggleADS();
        }
    }

    public void Shoot()
    {
        PlayRandomSound(stats.soundBank);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, stats.range, enemyLayer))
        {
            if (hit.transform.gameObject.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                enemy.RecieveDamage(stats.damage);
            }
        }
        stats.currentMag--;
        stats.currentAmmo--;
        UpdateGunUI();
        firing = true;
        Invoke(nameof(RefreshFiring), stats.fireRate);
    }
    public void PlayRandomSound(AudioClip[] clips)
    {
        AudioSource.PlayClipAtPoint(clips[Random.Range(0, clips.Length - 1)], transform.position);
    }
    void Reload()
    {
        AudioSource.PlayClipAtPoint(stats.reloadSound, transform.position);
        reloading = true;
        Invoke(nameof(RefreshReload), stats.reloadTime);
    }

    void ToggleADS()
    {
        switch(Input.GetMouseButtonDown(1))
        {
            case false:
                cam.fieldOfView = fov;
                break;
            case true:
                cam.fieldOfView = fov / stats.scopeMultiplier;
                break;
        }
    }

    void RefreshFiring()
    {
        firing = false;
    }
    void RefreshReload()
    {
        reloading = false;
        stats.currentMag = stats.magazineSize;
        UpdateGunUI();
    }
    public void UpdateGunUI()
    {
        UIManager.Instance.SetAmmoText(stats.currentMag, stats.currentAmmo - stats.currentMag);
    }
}

