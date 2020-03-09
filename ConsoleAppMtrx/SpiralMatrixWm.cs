using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralMatrixConsoleApp
{
    public static class SpiralMatrixWm
    {  
        /// <summary> 
        /// Preenche matrix quadrada N * N espiral. 
        /// Os ponteiros de referencia posicional dos limites da matriz aumentam sequencialmente à medida 
        /// que se percorre as bordas da mesma espiralando para dentro ate se encotrar o ponto central. 
        /// </summary>
        /// <param name="mtrx"> Estrutura muiltidimensional a ser preenchida </param>
        /// <param name="rowIdx"> index da borda horizontal </param>
        /// <param name="rowSize"> Limite da borda horizontal</param>
        /// <param name="colIdx">Index da borda vertical </param>
        /// <param name="colSize">limite da borda vertical </param>
        /// <param name="incValue"> valor </param>
        private static void SpiralRecursive(int[,] mtrx, int rowIdx, int rowSize, int colIdx, int colSize, int incValue = 0)
        {
            //preenche topo (horizontal asc)
            for (int i = rowIdx; i < colSize; i++)
            {
                mtrx[rowIdx, i] = (incValue + 1);
                incValue++;
            }

            // preenche direita vertical asc
            for (int i = rowIdx + 1; i < colSize; i++)
            {
                mtrx[i, colSize - 1] = incValue + 1;
                incValue++;
            }

            //Preenche fundo (horizontal desc)
            if (rowIdx + 1 < rowSize)
            {
                int idx = colSize - 2;
                for (int i = idx; i >= colIdx; i--)
                {
                    mtrx[rowSize - 1, i] = incValue + 1;
                    ++incValue;
                }
            }

            //Preenche esquerda (vertical - asc)  
            if (colIdx + 1 < colSize)
            {
                int idx = rowSize - 2;
                for (int i = idx; i > rowIdx; i--)
                {
                    mtrx[i, colIdx] = incValue + 1;
                    incValue++;
                }
            }

            // verifica por meio dos ponteiros de fronteira se alcancou o centro da aspiral
            if (rowIdx < rowSize && colIdx < colSize)
                SpiralRecursive(mtrx, rowIdx + 1, rowSize - 1, colIdx + 1, colSize - 1, incValue);

        }

        /// <summary>
        /// Retorna matriz N*N espiral.
        /// </summary>
        /// <param name="N"> Dimensao da matriz N*N</param>
        /// <returns></returns>
        public static int[,] SpiralRecursive(int N)
        {
            var mtrx = new int[N, N];

            int rowIdx = 0;
            int rowSize = mtrx.GetLength(0);
            int colIdx = 0;
            int colSize = mtrx.GetLength(1);
            int incValue = 0;

            SpiralRecursive(mtrx, rowIdx, rowSize, colIdx, colSize, incValue);

            return mtrx;
        }
        
        public static void PrintArray(int[,] array)
        {
            int n = (array.GetLength(0) * array.GetLength(1) - 1).ToString().Length + 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j].ToString().PadLeft(n, ' '));
                }
                Console.WriteLine();
            }
        }



    }



}
