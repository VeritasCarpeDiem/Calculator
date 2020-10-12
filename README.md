# Calculator

- Reversh Polish Notation(RPM) and Shunting Yard Algorithm
- Based off this link:https://brilliant.org/wiki/shunting-yard-algorithm/

# DS-13: Write a calculator program that can parse and solve math expressions, such as:
12 + 6 - 3 / 2 * 8
12 + 3
18 / 3 * 2   ---> make sure this is right: the answer is 12, not 3! PEMDAS isn't exactly right!

## RULES:
 - Expression is guaranteed to be valid - no need to worry about validation.
 - Don't rely on spaces! Either one of these is valid: 12 + 3, 12+3, 12+    3
 - Don't use any built-in magic - DataTable.Compute is not an acceptable solution!
 - Don't worry about parenthesis for now. BONUS if you can handle them though!
 - Don't worry about the unary minus (negative numbers) for now. BONUS if you can handle it though!
 - There can be n operations - don't hard-code any specific number of operations or operands.
 - Math rules apply (remember, even though PEMDAS would make you think that Multiplication is before Division, that's actually wrong - both operations are left-associative, and should be parsed in the order they appear in the expression, unless that order is changed by Parenthesis).

## HINT:
 - Look up Reverse Polish Notation (RPN). It'll help. A lot!
 - Now that you looked up RPN, how do you get the math equation in that form? Look up Shunting Yard Algorithm (another cool algo by Dijkstra).

If you've done this in class in C#, try it in C++! The logic is the same, you can try porting your prior code!
