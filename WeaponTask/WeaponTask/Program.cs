using WeaponTask;

namespace WeaponTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int magazineCapacity = 0;
            Console.Write("Daragin tutumunu daxil edin(30 ,40 ,50 ,60 ): ");
            if (int.TryParse(Console.ReadLine(), out magazineCapacity) &&
                (magazineCapacity == 30 || magazineCapacity == 40 || magazineCapacity == 60 || magazineCapacity == 90))
            {
                Console.WriteLine("Daragin gulle tutumu: " + magazineCapacity);
            }
            else
            {
                throw new Exception("Yanlis deyer daxil edildi.Daragin tutumu yalniz 30,40,50,60 ola biler");
            }



            Console.Write("Daraqdaki gulle sayini daxil edin: ");
            int bulletsInMagazine = 0;
            if (int.TryParse(Console.ReadLine(), out bulletsInMagazine) &&
                (bulletsInMagazine <= magazineCapacity))
            {
                Console.WriteLine("Daraqdaki gulle sayi: " + bulletsInMagazine);
            }
            else
            {
                throw new Exception("Daraqdaki gulle sayi tutumundan cox ola bilmez.");
            }



            Console.Write("Select the firing mode (1 - Single, 2 - Burst, 3 - Automatic): ");
            string? input = Console.ReadLine();

            Weapon.FireMode mode = (Weapon.FireMode)int.Parse(input);
            if (input == "1" || input == "2" || input == "3")
            {
                Console.WriteLine("Secilmis atis modu: " + mode);

            }
            else
            {
                throw new Exception("Yanlis deyer daxil edildi.Atis modlari yalniz 1,2 ve 3 ola biler");
            }

            Weapon weapon = new Weapon(magazineCapacity, bulletsInMagazine, mode);





            Console.WriteLine("\n0 - İnformasiya almaq üçün");
            Console.WriteLine("1 - Shoot metodu üçün");
            Console.WriteLine("2 - Fire metodu üçün");
            Console.WriteLine("3 - GetRemainBulletCount metodu üçün");
            Console.WriteLine("4 - Reload metodu üçün");
            Console.WriteLine("5 - ChangeFireMode metodu üçün");
            Console.WriteLine("7 - Tutumu deyissin");
            Console.WriteLine("8 - Gulle sayi deyissin");
            Console.WriteLine("9 - Proqramdan çıxmaq üçün");


            while (true)
            {

                Console.Write("Seçiminizi edin: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine($"Darağın tutumu: {weapon.MagazineCapasity}");
                        Console.WriteLine($"Daraqdakı güllə sayı: {weapon.BulletsInMagazine}");
                        Console.WriteLine($"Atış modu: {weapon.Mode}");
                        break;
                    case 1:
                        weapon.Shot();
                        break;
                    case 2:
                        weapon.Fire();
                        break;
                    case 3:
                        Console.WriteLine("Tam doldurmaq üçün lazım olan güllə sayı: " + weapon.GetRemainBulletCount());
                        break;

                    case 4:
                        weapon.Reload();
                        break;

                    case 5:
                        weapon.ChangeFireMode();
                        break;

                    case 6:
                        Console.WriteLine("Proqram dayandırılır...");
                        return;

                    case 7:
                        Console.WriteLine("8 - Tutumu dəyişmək");
                        Console.WriteLine("9 - Güllə sayını dəyişmək");
                        break;

                    case 8:
                        Console.WriteLine("Yeni tutum daxil edin:");
                        int newCapacity = int.Parse(Console.ReadLine());
              

                        if(int.TryParse(Console.ReadLine(), out newCapacity) && 
                            (newCapacity == 30 || newCapacity == 40 || newCapacity == 60 || newCapacity == 90))
                        {
                            Console.WriteLine("Daragin yeni tutumu: " + newCapacity);
                        }
                        else
                        {
                            throw new Exception("Yanlis deyer daxil edildi.Daragin yeni tutumu yalniz 30,40,50,60 ola biler");
                        }

                        weapon.ChangeMagazineCapacity(newCapacity);
                        break;
                    case 9:
                        Console.Write("Yeni gulle sayini daxil edin: ");
                        int newBulletCount = int.Parse(Console.ReadLine());

                

                        if (int.TryParse(Console.ReadLine(), out newBulletCount) && 
                            (newBulletCount <= magazineCapacity))
                        {
                            Console.WriteLine("Daragdaki yeni gulle sayi: " + newBulletCount);
                        }
                        else
                        {
                            throw new Exception("Daraqdaki yeni gulle sayi tutumundan cox ola bilmez.");
                        }


                        weapon.ChangedBulletInMagazine(newBulletCount);
                        break;

                    default:
                        Console.WriteLine("Yanlış seçim! Yenidən cəhd edin.");
                        break;





                }
            }
        }
    }
}
