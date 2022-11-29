using MultizLingual_ATM_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLingual_ATM_Module
{
    internal class AtmOperation
    {
        long _cardNumber;
        long _cardPin;
        public void Begin()
        {
            try
            {

                if (Global.PreferredLanguage == (int)SelectedLanguage.English)
                {
                    Console.WriteLine("Welcome to Zenith Bank Atm Machine");
                   
                    Reenter_CardNumber:
                    Console.WriteLine("Enter your Card number");

                    if (!long.TryParse(Console.ReadLine(), out _cardNumber))
                    {
                        Console.WriteLine("The Card Number entered is not valid!");
                        goto Reenter_CardNumber;
                    }
                   
                   
                 

                    Reenter_CardPin:
                    Console.WriteLine("Enter your Card pin");

                    if (!long.TryParse(Console.ReadLine(), out _cardPin))
                    {
                        Console.WriteLine("The Card Pin entered is not valid!");
                        goto Reenter_CardPin;
                    }

                  

                    if (_cardNumber != 0 && _cardPin != 0)
                    {
                        AccountUser accountUser = new AccountUser();
                        accountUser = accountUser.UserStore().FirstOrDefault(User => User.CardNumber == _cardNumber);

                        if (accountUser != null)
                        {
                            Console.WriteLine($"Welcome {accountUser.FullName}");

                            if (accountUser.CardPin == _cardPin)
                            {
                                AtmMenu(accountUser);
                            }
                            else
                            {
                                Console.WriteLine("Account Pin is not correct");
                                goto Reenter_CardPin;
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                            goto Reenter_CardNumber;
                        }


                    }




                }
                else 
                {
                    Console.WriteLine("Welcome to Zenith Bank Atm Machine");

                    Reenter_CardNumber:
                    Console.WriteLine("Enter your Card number");

                    if (!long.TryParse(Console.ReadLine(), out _cardNumber))
                    {
                        Console.WriteLine("The Card Number entered is not valid!");
                        goto Reenter_CardNumber;
                    }




                    Reenter_CardPin:
                    Console.WriteLine("Enter your Card pin");

                    if (!long.TryParse(Console.ReadLine(), out _cardPin))
                    {
                        Console.WriteLine("The Card Pin entered is not valid!");
                        goto Reenter_CardPin;
                    }



                    if (_cardNumber != 0 && _cardPin != 0)
                    {
                        AccountUser accountUser = new AccountUser();
                        accountUser = accountUser.UserStore().FirstOrDefault(User => User.CardNumber == _cardNumber);

                        if (accountUser != null)
                        {
                            Console.WriteLine($"Welcome {accountUser.FullName}");

                            if (accountUser.CardPin == _cardPin)
                            {
                                AtmMenu(accountUser);
                            }
                            else
                            {
                                Console.WriteLine("Account Pin is not correct");
                                goto Reenter_CardPin;
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                            goto Reenter_CardNumber;
                        }


                    }




                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred" + ex.Message);
            }

  
        }

           
        public  void AtmMenu(AccountUser currentUser)
            {


            try
            {
                Console.Clear();
                Console.WriteLine("Which operation do you want to perform? \n Reply with the appropraite number" +
                                   "\n 1. Withdraw  \n 2. Check Balance  \n 3. Change Pin \n 4. Transfer Money \n 5. End Session " 
                                   );

                int _selectedMenu;

                Renter_Menu:
                if (int.TryParse(Console.ReadLine(), out _selectedMenu)) {
                    Console.WriteLine("Invalid reply! Enter a valid number from 1- 5");
                    goto Renter_Menu;
                }
               

                switch (_selectedMenu)
                {
                    case 1:
                        Withdraw(currentUser);
                        break;
                    case 2:
                        CheckAccountBalance(currentUser);
                        break;

                    case 3:
                        // Change pin
                        break;
                    case 4:
                        // Transfer pin
                        break;

                    default:
                        Console.WriteLine("Invalid reply! Enter a valid number from 1 - 5");
                        goto Renter_Menu;
                        break;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred" + ex.Message);
            }
               

            }


        public void Withdraw(AccountUser currentUser)
        {
              

            try
            {
                Console.WriteLine("Type in the amount to withdraw");

                int amountToWithdraw = int.Parse(Console.ReadLine());


                while (!(amountToWithdraw != null && amountToWithdraw != 0))
                {
                    Console.WriteLine("Type in the amount to withdraw");

                    amountToWithdraw = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Select your account type: Savings or Current?");

                string accountType = Console.ReadLine();

                while (!(accountType.ToUpper() == currentUser.AccountType.ToUpper()))
                {
                    Console.WriteLine("Sorry your selected account type does not match the account type on your account!");
                    Console.WriteLine("Select your account type");

                    accountType = Console.ReadLine();
                }

                Console.WriteLine("Do you need a receipt for this transaction? Reply Yes or No");
                string response = Console.ReadLine();

                while (!(response != null && (response.ToUpper().Contains("YES") || response.ToUpper().Contains("NO"))))
                {
                    Console.WriteLine("Your reply is not in the valid format.");
                    Console.WriteLine("Do you need a receipt for this transaction? Reply Yes or No");
                    response = Console.ReadLine();
                }

                Console.WriteLine("Transaction in progress ....");
                Console.Beep(3000, 2000);

                if (amountToWithdraw > currentUser.AccountBalance)
                {
                    Console.WriteLine("Oops! Your account balance is not sufficient to process the amount selected.");
                    while (!(amountToWithdraw != 0))
                    {
                        Console.WriteLine("Type in the amount to withdraw");

                        amountToWithdraw = int.Parse(Console.ReadLine());
                    }
                }
                else
                {
                    currentUser.AccountBalance -= amountToWithdraw;
                    Console.WriteLine($"Your account has successsfully been debited of NGN{amountToWithdraw} and your account balance is {currentUser.AccountBalance}");
                    Console.Write("Counting cash...");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        Console.Write("...");
                    }
                    Console.Beep(3000, 2000);
                    Console.WriteLine(" \n Take your Cash!");
                    Console.WriteLine("Do you want to perform another transaction?");


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred" + ex.Message);
            }
           



        }


        public void CheckAccountBalance(AccountUser currentUser)
        {

            try
            {
                Console.WriteLine("Check account balance");

                Console.WriteLine("Select your account type: Savings or Current?");

                string accountType = Console.ReadLine();

                while (!(accountType.ToUpper() == currentUser.AccountType.ToUpper()))
                {
                    Console.WriteLine("Sorry your selected account type does not match the account type on your account!");
                    Console.WriteLine("Select your account type");

                    accountType = Console.ReadLine();
                }

                Console.WriteLine($"Your account balance is {currentUser.AccountBalance}");

            }
            catch (Exception ex )
            {

                Console.WriteLine("An error occurred" + ex.Message);
            }
         
        }


        public enum SelectedLanguage
            {
                English = 1,
                Pidgin,
                Igbo

            }
        
    }
}




