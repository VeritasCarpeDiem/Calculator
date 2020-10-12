using Microsoft.VisualBasic.CompilerServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CalculatorProgram
{
    class Program
    {
        
        public enum OperatorPrecedence
        {
           multiply = 1, 
           divide, 
           add,
           subtract
        }

        static public Queue<char> ShuntingYard(char[] tokens)
        {
            //Stack<int> nums = new Stack<int>();
            Stack<char> operators = new Stack<char>();
            Queue<char> output = new Queue<char>();

            Dictionary<char, OperatorPrecedence> Operator = new Dictionary<char, OperatorPrecedence>()
            {
                ['+'] = OperatorPrecedence.add,
                ['-'] = OperatorPrecedence.subtract,
                ['*'] = OperatorPrecedence.multiply,
                ['/'] = OperatorPrecedence.divide,
                //['('] = "left bracket",
                //[')'] = "right bracket",

            };

            for (int i = 0; i < tokens.Length; i++)
            {

                if (char.IsDigit(tokens[i]))
                {
                    output.Enqueue(tokens[i]);
                }
                else
                {
                    //PEMDAS
                    while (operators.Count >0 &&(int)Operator[operators.Peek()] < 3 )
                    {
                       output.Enqueue(operators.Pop());
                    }
                    operators.Push(tokens[i]);
                }
            }
            while(operators.Count >0)
            {
                output.Enqueue(operators.Pop());
            }
            return output;
        }

        static public int Evaluate(char[] tokens)
        {
            Stack<int> nums = new Stack<int>();
            //Stack<string> operators = new Stack<string>();

            Queue<char> output = ShuntingYard(tokens);
            ;
            for (int i = 0; i < tokens.Length; i++)
            {
                int num1, num2;
                switch (output.Peek())
                {
                    case '+':
                        nums.Push(nums.Pop() +nums.Pop());
                        ;
                        output.Dequeue();
                        break;
                    case '-':
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        nums.Push(num2 - num1);
                        output.Dequeue();
                        break;
                    case '*':
                        nums.Push(nums.Pop()*nums.Pop());
                        output.Dequeue();
                        break;
                    case '/':
                        num1 = nums.Pop();
                        num2 = nums.Pop();
                        ;
                        nums.Push(num2 / num1);
                        output.Dequeue();
                        break;
                    default:
                        nums.Push((int)char.GetNumericValue(output.Dequeue()));
                        ;
                        break;
                }

            }
            return nums.Pop();
        }
        static void Main(string[] args)
        {
            char[] expression = { '2', '+', '5', '/', '8' };

            Queue<char> queue = ShuntingYard(expression);
            foreach (var item in queue)
            {
                Console.Write(item +" ");
            }
            Console.WriteLine();
            Console.WriteLine(Evaluate(expression));
        }
    }
}
