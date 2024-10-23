/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
class Fibonacci {
  static void Main(){
        int a=0;
        int b=1;
        int c=0;
        int total=0;
        int cont=0;
        while(c<4000000){
            c=a+b;
            //Console.Write(c);
            //Console.Write(" ");
            a=b;
            b=c;
            if(c%2==0){
                total=total+c;
            }
        }
        Console.Write(total);
    }
}