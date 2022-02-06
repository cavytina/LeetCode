using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBitset
{
    public class Bitset
    {
        HashSet<int> nonZeroIdxSet;
        int nonZeroCount = 0;
        bool isFliped = false;
        int count = 0;

        public Bitset(int size)
        {
            count = size;
            nonZeroIdxSet = new HashSet<int>();
        }

        public void Fix(int idx)
        {
            if (!isFliped)
                if (!nonZeroIdxSet.Contains(idx))
                {
                    
                    nonZeroIdxSet.Add(idx);
                }         
            else
                if(nonZeroIdxSet.Contains(idx))
                {
                    nonZeroCount++;
                    nonZeroIdxSet.Remove(idx);
                }        
        }

        public void Unfix(int idx)
        {
            if (!isFliped)
                if (nonZeroIdxSet.Contains(idx))
                {
                    nonZeroCount--;
                    nonZeroIdxSet.Remove(idx);
                }          
            else
                if (!nonZeroIdxSet.Contains(idx))
                {
                    nonZeroCount--;
                    nonZeroIdxSet.Add(idx);
                }               
        }

        public void Flip()
        {
            isFliped = !isFliped;

            nonZeroCount = count - nonZeroCount;
        }

        public bool All()
        {
            return nonZeroCount == count;
        }

        public bool One()
        {
            return nonZeroCount > 0;
        }

        public int Count()
        {
            return nonZeroCount;
        }

        public override string ToString()
        {
            var str = new char[count];
            char setByte = '1'; char unsetByte = '0';
            if (isFliped) { setByte = '0'; unsetByte = '1'; }
            for (var i = 0; i < count; ++i)
                str[i] = nonZeroIdxSet.Contains(i) ? setByte : unsetByte;
            return new string(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bitset obj = new Bitset(2);
            obj.Fix(0);
            obj.Unfix(1);
            obj.Flip();

            Console.Write(obj.ToString());

            Console.Read();
            
        }
    }
}
