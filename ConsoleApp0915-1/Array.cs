using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915_1
{
    class ArrayManager
    {
        BankAccount ba1 = new BankAccount();
        string accNum;

        public void PrintMenu()
        {
            Console.WriteLine("\n---Menu-------");
            Console.WriteLine("1. 계좌개설");
            Console.WriteLine("2. 입금");
            Console.WriteLine("3. 출금");
            Console.WriteLine("4. 잔액 조회");
            Console.WriteLine("5. 프로그램 종료");
            Console.WriteLine("----------------\n");
        }
        public void MakeAccount() // 1번
        {
            ba1.AccNum = accNum;
        }
        public void Deposit() // 2번
        {
            if (ba1.CheckAcc() == true)
            {
                Console.Write(" 입금 금액을 입력해주세요: ");
                int input = Convert.ToInt32(Console.ReadLine());
                ba1.InputMoney(input);
            }
            else
                return;
        }
        public void Withdaw() // 3번
        {
            if (ba1.CheckAcc() == true)
            {
                Console.Write(" 출금 금액을 입력해주세요: ");
                int input = Convert.ToInt32(Console.ReadLine());
                ba1.OutputMoney(input);

            }
            else
                return;
        }
        public void ViewMoney() // 4번
        {
            if (ba1.CheckAcc() == true)
            {
                ba1.PrintAccInFo();
            }
        }
        public void SelectAcc() // 5번
        {
            if (ba1.CheckAcc() == true)
            {
                ba1.PrintAccInFo();
            }
        }
    }
    class Array
    {
        static void Main()
        {
            ArrayManager manager = new ArrayManager();
            Console.WriteLine(manager.ToString());
            int choice = 0;

            while (true)
            {
                manager.PrintMenu();
                Console.Write("선택 : ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        manager.MakeAccount();
                        break;
                    case 2:
                        manager.Deposit();
                        break;
                    case 3:
                        manager.Withdaw();
                        break;
                    case 4:
                        manager.ViewMoney();
                        break;
                    case 5:
                        manager.SelectAcc();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine(" 1~5 사이의 숫자를 입력해주세요");
                        break;
                }
            }
        }
    }
}
