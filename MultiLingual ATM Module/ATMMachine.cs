﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLingual_ATM_Module
{
    internal class ATMMachine
    {
        int _preferredLanguage;
      
        public void AtmBegin()
        {
            Console.WriteLine("Welcome to Zenith Bank");
            Console.WriteLine("Select your preferred language. Reply \n 1. For English Press 1 \n 2: Ichoro Asusu Igbo, pia abuo \n 3: Don zaɓar Hausa danna 3");
            _preferredLanguage = int.Parse(Console.ReadLine());


                 switch (_preferredLanguage)
                {
                    case ((int)SelectedLanguage.English):
                    Global.PreferredLanguage = _preferredLanguage;
                    Global.TargetLanguageCode = "en";
                    Console.WriteLine("You have Selected English as your preffered language");
                    break;

                    case ((int)SelectedLanguage.Igbo):
                    Global.PreferredLanguage = _preferredLanguage;
                    Global.TargetLanguageCode = "ig";
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("Ị họrọla Igbo dịka asụsụ kacha amasị gị");
                    break;

                    case ((int)SelectedLanguage.Hausa):
                    Global.PreferredLanguage = _preferredLanguage;
                    Global.TargetLanguageCode = "hs";
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine("Kun zabi Hausa a matsayin yaren da kuka fi so");
                    break;

                    default:
                        Console.WriteLine("The language selection is not valid");
                        Console.WriteLine("Select your preferred language. Reply \n 1: English \n 2: French \n 3: Igbo");
                    _preferredLanguage = int.Parse(Console.ReadLine());

                    break;
                }

            AtmOperation atmOperation = new AtmOperation();
            atmOperation.Begin();
            
        }

       public enum SelectedLanguage
        {
            English = 1,
            Igbo, 
            Hausa

        }


    }
}
