import random

a= random.randint(0,100)

guess=int(input("try to guess the number: "))

while(guess != a):
    if(guess > a):
        print("too big")
        
    else:
        print("too small")
    
    guess=int(input("try to guess the number: "))
    
print("You won")


