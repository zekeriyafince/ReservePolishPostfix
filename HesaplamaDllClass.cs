using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesaplamaYapanDLL
{
    public class ClassHesaplama
    {
        public double HesaplaMatIfade(String infix)
        {
            String postfix = InfixToPostfix(infix);
            return PostfixIfadesiniHesapla(postfix);
        }
        static int OncelikDurum(string karakter)
        {
            if (karakter == "!")
            {
                return 4;
            }
            if (karakter == "^")
            {
                return 3;
            }
            else if (karakter == "*" || karakter == "/")
            {
                return 2;
            }
            else if (karakter == "+" || karakter == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static bool isOperator(string karakter)
        {
            if (karakter == "+" || karakter == "-" || karakter == "*" || karakter == "/" || karakter == "^" || karakter == "!")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Infix convert to Postfix
        static String InfixToPostfix(String infixIfadesi)
        {
            String tamIfadePostfix = "";

            string[] degerlerDizisi = infixIfadesi.Split(' ');

            Stack<string> stackYapisi = new Stack<string>();
            List<string> outputList = new List<string>();
            double doubleKontrolDeger;
            foreach (string deger in degerlerDizisi)
            {
                //double bir sayi ise direkt list'e ekle(operand)
                if (double.TryParse(deger.ToString(), out doubleKontrolDeger))
                {
                    outputList.Add(deger + " ");
                }
                //Acma parantez direkt stack yapisina eklenir
                if (deger == "(")
                {
                    stackYapisi.Push(deger);
                }
                //Eger kapatma parantezi gelirse acma parantezine kadar stack'den cıkar
                if (deger == ")")
                {
                    while (stackYapisi.Count != 0 && stackYapisi.Peek() != "(")
                    {
                        outputList.Add(stackYapisi.Pop() + " ");
                    }
                    //Acma parantezi de cikti
                    stackYapisi.Pop();
                }
                //Oparator olması halinde
                if (isOperator(deger) == true)
                {
                    ///Stack yapisi bos degilse ve stack'teki degerin onceligi buyukse esit olana kadar cikar list'e ekle
                    while (stackYapisi.Count != 0 && OncelikDurum(stackYapisi.Peek()) >= OncelikDurum(deger))
                    {
                        outputList.Add(stackYapisi.Pop() + " ");
                    }
                    stackYapisi.Push(deger);
                }
            }
            //Stackde eleman kalırsa son anda hepsini list'e ekle
            while (stackYapisi.Count != 0)
            {
                outputList.Add(stackYapisi.Pop() + " ");
            }
            //Tam degeri icin birlestir
            for (int i = 0; i < outputList.Count; i++)
            {
                //Console.Write("{0}", outputList[i]);
                tamIfadePostfix += outputList[i] + " ";
            }


            return tamIfadePostfix;
        }

        static double PostfixIfadesiniHesapla(String postfixIfade)
        {
            double cozumDeger;
            String[] postfixDizi = postfixIfade.Split(' ');
            
            double resultDeger = 0;
            double doubleKontrolDeger;

            Stack polishNotationStack = new Stack();
            foreach (string c in postfixDizi)
            {
                //Karakter numara ise (operand)
                if (double.TryParse(c, out doubleKontrolDeger))
                {
                    polishNotationStack.Push(doubleKontrolDeger);
                }
                //Operator isareti ise
                //Stack'ten deger cikar ve islem yap
                else
                {
                    if (c == "+")//Toplama
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        double y = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = x + y;//evaluate the values popped from the stack
                        polishNotationStack.Push(resultDeger);//push current result onto the stack
                    }
                    if (c == "-")//Cikarma
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        double y = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = y - x;
                        polishNotationStack.Push(resultDeger);
                    }
                    if (c == "*")//Carpma
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        double y = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = x * y;
                        polishNotationStack.Push(resultDeger);
                    }
                    if (c == "/")//Bolme
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        double y = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = y / x;
                        polishNotationStack.Push(resultDeger);
                    }
                    if (c == "^")//Us Alma
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        double y = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = Math.Pow(y, x);
                        polishNotationStack.Push(resultDeger);
                    }

                    if (c == "!")//Faktoriel
                    {
                        double x = Convert.ToDouble(polishNotationStack.Pop());
                        resultDeger = Factorial(x);
                        polishNotationStack.Push(resultDeger);
                    }
                }


            }

            
            cozumDeger = Convert.ToDouble(polishNotationStack.Peek());
            return cozumDeger;
        }

        static double Factorial(double sayi)
        {
            if (sayi < 0)
            {
                return -1;
            }
            else if (sayi == 1 || sayi == 0)
            {
                return 1;
            }
            else
            {
                return sayi * Factorial(sayi - 1);
            }
        }
    }
}
