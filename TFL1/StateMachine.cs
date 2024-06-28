using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TFL1
{
    public class StateMachine
    {
        // Окончание
        List<string> ending = new List<string> { "ан", "ана", "ын", "ына", "ин", "ина", "ов", "ова", "ев", "ева", "ой", "ая", "их", "ых" };
        // Строчные буквы
        List<char> smallLetters = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        // Прописные буквы       
        List<char> largeLetters = new List<char> { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        // Символы
        List<char> symbols = new List<char> { ' ', '.', '-' };

        public bool State12(char currentSymbol)
        {
            if (largeLetters.Contains(currentSymbol)) return true;
            else return false;
        }
        public bool State1 (char currentSymbol)
        {
             if (smallLetters.Contains(currentSymbol)) return true;
             else return false;
        }

        public bool State2(string currentSymbols)
        {
            if (ending.Contains(currentSymbols)) return true;
            else return false;
        }

        public bool State3(char currentSymbol)
        {
            if (currentSymbol == ' ') return true;
            else return false;
        }

        public bool State4(char currentSymbol)
        {
            if (largeLetters.Contains(currentSymbol)) return true;
            else return false;
        }

        public bool State5(char currentSymbol)
        {
            if (currentSymbol == '.') return true;
            else return false;
        }

        public bool State6(char currentSymbol)
        {
            return State4(currentSymbol);
        }

        public bool State7(char currentSymbol)
        {
            return State5(currentSymbol);
        }

        public bool State8(char currentSymbol)
        {
            if (currentSymbol == '-') return true;
            else return false;
        }
        public bool State22(char currentSymbol)
        {
            return State4(currentSymbol);
        }
        public bool State9(char currentSymbol)
        {
            return State1(currentSymbol);
        }

        public bool State10(string currentSymbol)
        {
            return State2(currentSymbol);
        }
        public bool State13(char currentSymbol)
        {
            return State5(currentSymbol);
        }

        public bool State14(char currentSymbol)
        {
            return State4(currentSymbol);
        }

        public bool State15(char currentSymbol)
        {
            return State5(currentSymbol);
        }

        public bool State16(char currentSymbol)
        {
            return State3(currentSymbol);
        }
        public bool State23(char currentSymbol)
        {
            return State12(currentSymbol);
        }
        public bool State17(char currentSymbol)
        {
            return State1(currentSymbol);
        }

        public bool State18(string currentSymbols)
        {
            return State2(currentSymbols);
        }

        public bool State19(char currentSymbol)
        {
            return State8(currentSymbol);
        }
        public bool State24(char currentSymbol)
        {
            return State12(currentSymbol);
        }
        public bool State20(char currentSymbol)
        {
            return State1(currentSymbol);
        }

        public bool State21(string currentSymbols)
        {
            return State2(currentSymbols);
        }

    }
}
