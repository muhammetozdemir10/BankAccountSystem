using BankAccountSystem.Models;
using System.Security.Principal;

namespace BankAccountSystem
{
    internal class Program
    {
        static List<BankAccount> accounts = new();
        static private BankAccount? SelectedAccount { get; set; } = null;

        enum MenuOptions
        {
            ListAllAccountsDetails = 1,
            ListAccountDetails = 2,
            DepositMoney = 3,
            WithdrawMoney = 4,
        }

        static void Data()
        {
            accounts.Add(new BankAccount()
            {
                AccountNo = 1,
                Name = "Muhammet",
                Surname = "Ozdemir",
                Balance = 1600.00
            });
            accounts.Add(new BankAccount()
            {
                AccountNo = 2,
                Name = "Enes",
                Surname = "Kirgil",
                Balance = 950.00
            });
            accounts.Add(new BankAccount()
            {
                AccountNo = 3,
                Name = "Huseyin",
                Surname = "Balaban",
                Balance = 1000.00
            });
            accounts.Add(new BankAccount()
            {
                AccountNo = 4,
                Name = "Abdulrahman",
                Surname = "Elheyb",
                Balance = 190.00
            });
        }

        static void Main(string[] args)
        {
            Data();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--- Banka hesap yonetim sistemine hos geldiniz. ---");
            Console.ResetColor();
            Menu();
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Asagidaki islemlerden birini secmek icin numarasini giriniz.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. Tum Banka Hesaplari Listele");
            Console.WriteLine("2. Hesap Bilgileri Listele");
            Console.WriteLine("3. Hesaba Para Yatir");
            Console.WriteLine("4. Hesaptan Para Cek");
            Console.ResetColor();

            try
            {
                MenuOptions response = (MenuOptions)Convert.ToInt32(Console.ReadLine());
                switch (response)
                {
                    case MenuOptions.ListAllAccountsDetails:
                        ListAllAccountsDetails();
                        AskIfHasMoreOperations();
                        break;
                    case MenuOptions.ListAccountDetails:
                        ListAccountDetails();
                        AskIfHasMoreOperations();
                        break;
                    case MenuOptions.DepositMoney:
                        DepositMoney();
                        AskIfHasMoreOperations();
                        break;
                    case MenuOptions.WithdrawMoney:
                        WithdrawMoney();
                        AskIfHasMoreOperations();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yanlis girdiniz lutfen tekrar deneyiniz");
                        Console.ResetColor();
                        AskIfHasMoreOperations();
                        break;
                }


            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yanlis girdiniz lutfen tekrar deneyiniz");
                Console.ResetColor();
            }
        }

        static void ListAllAccountsDetails()
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Account no: {account.AccountNo}");
                Console.WriteLine($"Account name: {account.Name}");
                Console.WriteLine($"Account surname: {account.Surname}");
                Console.WriteLine($"Account balance: {account.Balance}");
                Console.WriteLine("----------------------------------");
            }
        }

        static void ListAccountDetails()
        {
            SelectAccount();
            if (SelectedAccount != null)
            {
                Console.WriteLine($"Account no: {SelectedAccount.AccountNo}");
                Console.WriteLine($"Account name: {SelectedAccount.Name}");
                Console.WriteLine($"Account surname: {SelectedAccount.Surname}");
                Console.WriteLine($"Account balance: {SelectedAccount.Balance}");
            }
        }

        static void SelectAccount()
        {
            Console.WriteLine("Lutfen bir hesap no secin:");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Account no: {account.AccountNo}");
                Console.WriteLine($"Account name: {account.Name}");
                Console.WriteLine($"Account surname: {account.Surname}");
                Console.WriteLine($"----------------------------------");
            }


            try
            {
                int selectedAccountNo = Convert.ToInt32(Console.ReadLine());
                BankAccount? account = accounts.Find((account) => account.AccountNo == selectedAccountNo);
                if (account != null)
                {
                    SelectedAccount = account;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Yanlis girdiniz lutfen tekrar deneyiniz");
                Console.ResetColor(); 
                SelectAccount();
            }

        }

        static void AskIfHasMoreOperations()
        {
            Console.WriteLine("Yapmak istediginiz baska bir islem varmi?");
            Console.WriteLine("Evet ise  \"Enter\" basin eger hayir ise \"ESC\" basin");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:

                    Menu();
                    break;
                case ConsoleKey.Escape:
                    break;

                default:
                    break;
            }
        }

        static void DepositMoney()
        {
            SelectAccount();
            if (SelectedAccount != null)
            {
                Console.WriteLine("lutfen yatirmak istediginiz miktari giriniz:");
                try
                {
                    double depositInput = Convert.ToDouble(Console.ReadLine());
                    SelectedAccount.Balance += depositInput;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Islem tamamlandi.");
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Yanlis girdiniz lutfen tekrar deneyiniz");
                    Console.ResetColor();
                }
                
            }
        }

        static void WithdrawMoney()
        {
            SelectAccount();
            if (SelectedAccount != null)
            {
                Console.WriteLine("Lutfen cekmek istediginiz miktari giriniz");
                try
                {
                    double withdrawInput = Convert.ToDouble(Console.ReadLine());
                    if (SelectedAccount.Balance >= withdrawInput)
                    {
                        SelectedAccount.Balance -= withdrawInput;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Islem tamamlandi.");
                        Console.ResetColor();
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yetersiz bakiye");
                        Console.ResetColor();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Yanlis girdiniz lutfen tekrar deneyiniz");
                    Console.ResetColor();
                }
            }
        }
    }
}