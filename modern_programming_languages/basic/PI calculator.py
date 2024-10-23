result=0
#calcular pi(funciona)
'''       
for i in range (1000000):
    if (i%2==0):
        result=result+(1/(1+(i*2)))
    else:
        result=result-(1/(1+(i*2)))
        
print(result*4)
'''
#calcular cuantas iteraciones son necesarias para 
#calcular un pi de una determinada precision(funciona)
cont =0
i=0
EXACT_VALUE=3.1415
PRECISION=0.0001
while(abs(result*4-EXACT_VALUE) > PRECISION):
    if (i%2==0):
        result=result+(1/(1+(i*2)))
    else:
        result=result-(1/(1+(i*2)))
        
    cont= cont+1
    i=i+1
    print(result*4, cont)
    
print(cont)
