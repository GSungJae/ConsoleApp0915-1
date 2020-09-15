using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915_1
{
    public class BankAccount
    {
        private static double interest = 0.2;
        private string accNum = "";
        private string name;
        private int balance;
        Random RandomAcc = new Random();
        #region property
        public string AccNum
        {
            get
            { return accNum; }
            set
            {
                if (accNum == "")
                {
                    Console.Write(" 예금주명을 입력해주세요. : ");
                    Name = Console.ReadLine();
                    accNum = Convert.ToString(RandomAcc.Next(100, 1000));
                    accNum = accNum.Insert(accNum.Length, "-");
                    accNum = accNum.Insert(accNum.Length, Convert.ToString(RandomAcc.Next(100, 1000)));
                    accNum = accNum.Insert(accNum.Length, "-");
                    accNum = accNum.Insert(accNum.Length, Convert.ToString(RandomAcc.Next(10000, 100001)));
                }
                else
                    Console.WriteLine(" 이미 계좌가 있습니다.");
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Balance
        {
            get { return balance; }
        }
        // 프로퍼티
        #endregion

        #region ctor
        public BankAccount()
        {
            balance = 0;
        }
        public BankAccount(string accname)
        {
            Name = accname;
        }
        #endregion
        #region method
        /*
        public void OutputMoney(int amount) //  출금
        {
            if (balance < amount)
            {
                Console.WriteLine(" 잔액이 부족합니다.");
                return;
            }
            balance = balance - amount;
        }
        */
        public string OutputMoney(int amount) //  출금
        {
            if (balance < amount)
            {
                string msg = "\n 잔액이 부족합니다.";
                Console.WriteLine(msg);
                return msg;
            }
            else
            {
                balance = balance - amount;
                return "";
            }

        }
        public void InputMoney(int amount) // 예금
        {
                balance = balance + amount + (int)(amount * interest);
        }
        public void PrintAccInFo()  //계좌정보출력
        {

            Console.WriteLine($" 예금주 : {Name}");
            Console.WriteLine($" 계좌번호 : {AccNum}");
            Console.WriteLine($" 잔액 : {Balance}");
            Console.WriteLine($" 이자율 : {interest}");
        }
        public bool CheckAcc()
        {
            if (accNum == "")
            {
                Console.WriteLine(" 생성된 계좌가 없습니다.");
                return false;
            }
            else
            {
                return true;
            }
        }



        public static void SetInterest(double interest)//이자율 변경 메소드자체를 정적으로(static)으로 만들거나 클래스명.정적멤버 형식으로 접근하는 방법이 있음 정적은 정적만 접근 가능.
        {

            BankAccount.interest = interest;
        }
        //메서드
        #endregion

    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc0 = new BankAccount();  // ()안에 string 값이 들어가냐 안들어가냐에 따라서 달라짐.
            
            string set = "";
            
            acc0.AccNum = set;
            Console.WriteLine(acc0.AccNum);

            
            acc0.PrintAccInFo();
            acc0.InputMoney(125);
            acc0.OutputMoney(100);

            string errMsg = acc0.OutputMoney(4);

            if(errMsg.Length>0)
                Console.WriteLine(errMsg);
            else
                Console.WriteLine($" {acc0.Balance}");

            Console.WriteLine($" {acc0.Balance}");
             

        }
    }
}
