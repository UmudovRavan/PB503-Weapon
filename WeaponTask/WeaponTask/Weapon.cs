using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponTask;

namespace WeaponTask
{
    public class Weapon
    {
        public enum FireMode
        {
            Single =1,
            Burst,
            Automatic
        }

        public int MagazineCapasity { get; private set; }
        public int BulletsInMagazine { get; private set; }

        public FireMode Mode { get; private set; }

        public Weapon(int magazineCapasity, int bulletInMagazine, FireMode mode)
        {
            if (magazineCapasity < 0)
            {
                throw new Exception("Daragin tutumu 0-dan boyuk olmalidir.");
            }


            if (bulletInMagazine > magazineCapasity || bulletInMagazine < 0)
            {
                throw new Exception("Daraqdaki gulle sayi duzgun teyin edilmeyib.");
            }

            MagazineCapasity = magazineCapasity;
            BulletsInMagazine = bulletInMagazine;
            Mode = mode;
        }

        public void Shot()
        {
            if (BulletsInMagazine > 0)
            {
                BulletsInMagazine--;
                Console.WriteLine("Bir gulle atildi qalan gulle sayi: " + BulletsInMagazine);
            }
            
            else
            {
                Console.WriteLine("Daraq bosdur yeniden doldurun.");
            }
        }

        public void Fire()
        {
            if (Mode == FireMode.Automatic)
            {
                if (BulletsInMagazine > 0)
                {
                    Console.WriteLine("Butun gulleler atilir.");
                    BulletsInMagazine = 0;
                    Console.WriteLine("Qalan gulle sayi: " + BulletsInMagazine);
                }
                else
                {
                    Console.WriteLine("Daraq bosdur yeniden doldurun.");
                }
            }
            else if (Mode == FireMode.Burst)
            {
                BurstShoot();
            }
            else
            {
                Console.WriteLine("Tekli modda Fire() istifade edile bilmez.Shoot() cagirin.");
            }
        }

        private void BurstShoot()
        {
            if (BulletsInMagazine >= 3)
            {
                BulletsInMagazine -= 3;
                Console.WriteLine("Uc gulle atildi.Qalan gulle sayi:" + BulletsInMagazine);
            }
            else if (BulletsInMagazine > 0)
            {
                Console.WriteLine($"Yalniz {BulletsInMagazine} gulle atildi.Daraq bosaldi.");
                BulletsInMagazine = 0;
            }
            else
            {
                Console.WriteLine("Daraq bosdur yeniden doldurun.");
            }
        }
        public int GetRemainBulletCount()
        {
            return MagazineCapasity - BulletsInMagazine;
        }

        public void Reload()
        {
            int bulletsNeed = GetRemainBulletCount();
            BulletsInMagazine += bulletsNeed;

            Console.WriteLine("Daraq dolduruldu.Movcud gulle sayi: " + BulletsInMagazine);

        }

        public void ChangeFireMode()
        {
            switch(Mode)
            {
                case FireMode.Single:
                    Mode = FireMode.Burst;
                    break;
                case FireMode.Burst:
                    Mode = FireMode.Automatic;
                    break;
                case FireMode.Automatic:
                    Mode = FireMode.Single;
                    break;
            }
            Console.WriteLine($"Atis modu deyisdi: {Mode}");
            
        }

        public void ChangeMagazineCapacity(int newCapacity)
        {
            if (MagazineCapasity > newCapacity)
                throw new Exception("Yeni tutum movcud gulle sayindan az ola bilmez.");
            MagazineCapasity = newCapacity;
            Console.WriteLine("Daragin gulle tutumu yenilendi: " + MagazineCapasity);
        }

        public void ChangedBulletInMagazine(int bullet)
        {
            if (bullet < 0 || bullet > MagazineCapasity)
                throw new Exception("Gulle sayi duzgun teyin edilmiyib.");
            BulletsInMagazine = bullet;
            Console.WriteLine("Daraqdaki gulle sayi yenilendi: " + BulletsInMagazine);
        }


    }
}

