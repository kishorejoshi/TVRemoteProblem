using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TVRemote
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyboard = new VirtualKeyBoard();
            Console.WriteLine(keyboard.GetActionSequence("dog"));
            Console.ReadLine();
        }
    }

    class VirtualKeyBoard
    {
        Hashtable hashX = new Hashtable();
        Hashtable hashY = new Hashtable();

        public VirtualKeyBoard()
        {
            var alphabets = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int i = 0;
            int j = 0;
            for (int k = 0; k < alphabets.Length; k++)
            {
                if ((k + 1) % 6 == 0)
                {
                    i = 0;
                    j++;
                }
                hashX.Add(alphabets[k], i++);
                hashY.Add(alphabets[k], j);
            }
        }

        public void PrintKeyboard()
        {
            Console.WriteLine("THe values in X HashTable is");
            foreach( var keys in hashX.Keys)
                Console.WriteLine("Vlaue= {0}  Index = {1}",keys,hashX[keys]);
            Console.WriteLine("THe values in Y HashTable is");
            foreach (var keys in hashY.Keys)
                Console.WriteLine("Vlaue= {0}  Index = {1}", keys, hashY[keys]);

        }

        public string GetActionSequence(string str)
        {
            StringBuilder sb = new StringBuilder();

            var characters = str.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 0)
                    sb.Append(ActionSequence(characters[i], 0, 0));
                else
                    sb.Append(ActionSequence(characters[i],Convert.ToInt32(hashX[characters[i-1]]), Convert.ToInt32(hashY[characters[i-1]])));
                sb.Append('s');
            }

            return sb.ToString();
        }

        public string ActionSequence(char destinationAlphabet, int startX, int startY)
        {
            StringBuilder sb = new StringBuilder();
            int endX = Convert.ToInt32(hashX[destinationAlphabet]);
            int endY = Convert.ToInt32(hashY[destinationAlphabet]);

            if (endX > startX)
                while (endX > startX)
                {
                    sb.Append('r'); endX--;
                }
            else
                while (endX < startX)
                {
                    sb.Append('l'); startX--;
                }

            if (endY > startY)
                while (endY > startY)
                {
                    sb.Append('d'); endY--;
                }
            else
                while (endY < startY)
                {
                    sb.Append('u'); startY--;
                }

            return sb.ToString();
        }

    }
}
