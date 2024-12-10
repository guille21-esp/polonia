
#include <iostream>

using namespace std;

int main()
{
    int cont=0;
    int total=0;
    for(int i=0; i<1000; i++){
        if(i%3==0 || i%5==0){
            total=total+i;
            cout << i << endl;
            cont++;
        }
    }
    cout << total;
}