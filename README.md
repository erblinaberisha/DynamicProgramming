# DynamicProgramming

##Problem:
A letter in a string has a twin if it has the same letter immediately to its left or immediately to its
right (or both). For example, in the string "AARDVARK" each of the first two 'A' has a twin (but the third 'A'
does not) and in the string "FLUSSSAND" each of the three 'S' has a twin. Elly has a String S containing at
least two characters. The girl can alter her string as many times as she likes. In each operation she chooses
one valid index i and either increments or decrements the letter S[i]. Incrementing a letter changes it to
the next letter in the alphabet (e.g., 'A' to 'B', 'L' to 'M', and 'Y' to 'Z'). Decrementing a letter changes it to
the previous letter in the alphabet (e.g., 'B' to 'A', 'M' to 'L', and 'Z' to 'Y'). The letter 'A' cannot be
decremented and the letter 'Z' cannot be incremented. Multiple operations may be applied to the same
index. Thus, S can be transformed into any other string of the same length. Elly wants to alter her S into a
string in which each letter has a twin. Please find and return the minimal number of operations needed.


##Examples:
Input: "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
Output: 13
Each letter on an even position (counting from zero) can be incremented, achieving
"BBDDFFHHJJLLNNPPRRTTVVXXZZ". We have incremented once 13 letters, thus the
number of operations we have used is 13. This is the minimal number of operations for this
test.
Input: "ESPRIT"
Output: 25
Input: “NOZAPHODJUSTVERYVERYIMPROBABLE”
Output: 93


##Requirements:
1. Implement two different approaches to solve the problem.
2. Each approach should result in different time/space complexity combinations. Therefore, the
two approaches can have different time complexity, space complexity or both.
3. One of the approaches must use dynamic programming.
