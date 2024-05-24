using System;

namespace testeBenner
{
    public class Network
    {
        private int[] conj1;
        private int[] conj2;

        public Network(int qtdConj)
        {
            if (qtdConj > 0)
            {
                conj1 = new int[qtdConj];
                conj2 = new int[qtdConj];

                for (int i = 0; i < qtdConj; i++)
                {
                    conj1[i] = i;
                    conj2[i] = 0;
                }
            }
            else
            {
                throw new ArgumentException("Number of elements must be positive.");
            }
        }

        public void Connect(int a, int b)
        {
            if (a < 0 || a >= conj1.Length || b < 0 || b >= conj1.Length)
                throw new ArgumentException("Erro ao achar indice");

            int conjX = Achou(a);
            int conjY = Achou(b);

            if (conjX != conjY)
            {
                
                if (conj2[conjX] > conj2[conjY])
                {
                    conj1[conjY] = conjX;
                }
                else if (conj2[conjX] < conj2[conjY])
                {
                    conj1[conjX] = conjY;
                }
                else
                {
                    conj1[conjY] = conjX;
                    conj2[conjX]++;
                }
            }
        }

        public bool Query(int a, int b)
        {
            if (a < 0 || a >= conj1.Length || b < 0 || b >= conj1.Length)
                throw new ArgumentException("Erro ao achar indice");

            return Achou(a) == Achou(b);
        }

        private int Achou(int x)
        {
            if (conj1[x] != x)
            {
                conj1[x] = Achou(conj1[x]); 
            }
            return conj1[x];
        }
    }

    class testeProgram
    {
        static void Main()
        {
            Network network = new Network(9);
            network.Connect(1, 2);
            network.Connect(6, 2);
            network.Connect(2, 4);
            network.Connect(8, 7);
            network.Connect(3, 5);
            network.Connect(6, 4);
            network.Connect(7, 4);
            network.Connect(2, 6);
            network.Connect(1, 5);
           

            Console.WriteLine(network.Query(1, 6)); 
            Console.WriteLine(network.Query(6, 4)); 
            Console.WriteLine(network.Query(7, 4)); 
            Console.WriteLine(network.Query(1, 3)); 
            Console.WriteLine(network.Query(2, 8));
            Console.WriteLine(network.Query(4, 1));
            Console.WriteLine(network.Query(1, 2));
            Console.WriteLine(network.Query(4, 8));
        }
    }
}
