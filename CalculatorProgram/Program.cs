using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace CalculatorProgram
{
    class Program
    {
        Dictionary<char, string> Operator = new Dictionary<char, string>()
        {
            ['+'] = "plus",
            ['-'] = "minus",
            ['*'] = "multiply",
            ['/'] = "divide",
            ['(']= "left bracket",
            [')']="right bracket",

        };
        static void ArrangeInRPM()
        {

        }

        static string ShuntingYard(Stack<string> Operators, Queue<int> Output, string[] Expression)
        {
            int index = 0;

            for (int i = 0; i < Expression.Length; i++)
          
            {
                if(int.TryParse(Expression[index], out int j)) //if its number add it to queue
                {
                    Output.Enqueue(int.Parse(Expression[index]));
                }
                if (Expression[index].Equals(Operator.Values)) //if its operator, 
                {
                    while (Expression[index].Equals("("))
                    {
                        Operators.Pop();
                    }
                    Operators.Push(Expression[index]);
                }
                if(Expression[index].Equals("(")) //if left bracket, push to stack
                {
                    Operators.Push(Expression[index]);
                }
                if(Expression[index].Equals(")")) //if right bracket, 
                {
                    while(Operators.Peek() != "(")//while there is NOT left bracket on top of stack, 
                    {
                        Operators.Pop(); //pop operators from stack and add it to queue

                    }

                }
            }
            return Operators.Peek();
        }
        static void Main(string[] args)
        {
            Stack<string> Operators = new Stack<string>();
            Queue<int> Output = new Queue<int>();
            string[] Expression= { "12", "+"," 6"," -"," 3"," /"," 2"," *"," 8" };

            ArrangeInRPM();

            ShuntingYard(Operators, Output,Expression);
            
        }
    }
}
