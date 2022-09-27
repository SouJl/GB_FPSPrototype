using System;
using TMPro;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class AssaltRifle : BaseWeapon
    {
        private TextMeshProUGUI _ammoText;

        public TextMeshProUGUI AmmoText { get => _ammoText; set => _ammoText = value; }

        public AssaltRifle(WeaponView view) : base(view)
        {
            AmmoText = view.AmmoText;
            UpdateUI();
        }

        private bool CanShoot() => !IsReloading && TimeBeforeShoot > 1f / (FireRate / 60f);

        public override void Shoot()
        {
            if (!(CurrentAmmo > 0 && CanShoot())) return;

            if(ShootingSystem) ShootingSystem.Play();

            if (Physics.Raycast(Muzzle.position, Muzzle.forward, out RaycastHit hitinfo, Distance))
            {
                Debug.Log(hitinfo.collider.gameObject.tag);

                TrailRenderer trail = CoroutineProcesses.Instance.SpawnObject(BulletTrail, ShootingSystem.transform.position);

                CoroutineProcesses.Instance.WaitTrailDone(trail, hitinfo, ImpacBulletSystem);

                if (hitinfo.collider.gameObject.tag == "Enemy")
                {
                    IDamageable damageable = hitinfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(Damage);
                }

            }

            CurrentAmmo--;
            TimeBeforeShoot = 0;
            UpdateUI();
        }


        public override void Reload()
        {
            if (!IsReloading)
            {
                Debug.Log("Reload");
                ReloadStart();
            }
        }

        private void ReloadStart()
        {
            IsReloading = true;
            CoroutineProcesses.Instance.WaitDelayCallBack(ReloadTime, ReloadEnd);
        }

        private void ReloadEnd(bool state)
        {
            CurrentAmmo = MagSize;
            IsReloading = false;
            UpdateUI();
        }

        private void UpdateUI()
        {
            AmmoText.text = $"{CurrentAmmo}";
        }

        private Vector3 GetDirection()
        {
            Vector3 direction = Muzzle.forward;

            return direction;
        }
    }
}
