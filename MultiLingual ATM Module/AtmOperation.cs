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
        int _cardPin;
        public void Begin()
        {
            try
            {

                if (Global.PreferredLanguage == (int)SelectedLanguage.English)
                {
                    Console.WriteLine("Welcome to Zenith Bank Atm Machine");
                    Console.WriteLine("Enter your Card number");

                    _cardNumber = long.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your Card pin");
                    _cardPin = int.Parse(Console.ReadLine());

                    if (_cardNumber != null && _cardPin != null)
                    {
                        AccountUser accountUser = new AccountUser();
                        accountUser = accountUser.GenerateRandomUsers().Find(User => User.CardNumber == _cardNumber);

                        if (accountUser != null)
                        {
                            Console.WriteLine($"Welcome {accountUser.FullName}");

                            if (accountUser.CardPin == _cardPin)
                            {
                                AtmAction(accountUser);
                            }
                            else
                            {
                                Console.WriteLine("Account Pin is not correct");
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                        }


                    }




                }
                else
                {
                    Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "Welcome to Zenith Bank Atm Machine"));

                    Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "Enter your Card number"));



                    _cardNumber = long.Parse(Console.ReadLine());

                    Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "Enter your Card pin"));

                    _cardPin = int.Parse(Console.ReadLine());

                    if (_cardNumber != null && _cardPin != null)
                    {
                        AccountUser accountUser = new AccountUser();
                        accountUser = accountUser.GenerateRandomUsers().Find(User => User.CardNumber == _cardNumber);

                        if (accountUser != null)
                        {
                            Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "Account Found"));

                            if (accountUser.CardPin == _cardPin)
                            {
                                AtmAction(accountUser);
                            }
                            else
                            {
                                Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "Account Pin is not correct"));
                            }
                        }
                        else
                        {
                            Console.WriteLine(Language.Translate(Global.TargetLanguageCode, "User not found"));
                        }


                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred" + ex.Message);
            }




        }

           
        public  void AtmAction(AccountUser currentUser)
            {


            try
            {
                Console.WriteLine("Which operation do you want to perform? \n Reply with the appropraite number" +
                                   "\n 1. Withdraw  \n  2. Check Balance  \n 3. Change Pin \n4. Transfer Money "
                                   );

                int _selectedOperation = int.Parse(Console.ReadLine());

                switch (_selectedOperation)
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




