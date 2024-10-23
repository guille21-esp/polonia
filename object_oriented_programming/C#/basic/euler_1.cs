using System;
//1011580

class multiples {
    static void Main(){
        int cont=0;
        int total=0;
        for(int i=0; i<1000; i++){
            if(i%3==0 || i%5==0){
                total=total+i;
                Console.WriteLine(i);
                cont++;
            }
        }
        Console.WriteLine(total);
        //Console.WriteLine(cont);
    }
}