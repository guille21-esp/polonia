'''
a = 10
b = 20

print(a,b)

a, b = b, a


print(a, b)


a=1
b=4
c=6

def get_max(a, b, c):
    if(a<b):
        if(b<c):
            return c
        else:
            return c
    else:
        if(a<c):
            return c
        else:
            return a


print(get_max(100, -1, 20))

num_list = [100, -1, 200]

print(max(num_list))

num_list = []
 
for i in range(10):
    a= random.randint(0,100)
    num_list.append(a)
    
print(num_list)   

print("max number is :", max(num_list))
print("min number is: ", min(num_list))
'''
import random

NUM_THROWS= 1000000


stat = [0,0,0,0,0,0,0,0,0,0,0]

for i in range(NUM_THROWS):
    dice_1 = random.randint(1,6)
    dice_2 = random.randint(1,6)
    result= dice_1+dice_2
    stat[result-2]+=1

for i in range (len(stat)):
    print(i+2, ":", stat[i])



    