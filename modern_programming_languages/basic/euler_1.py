cont =0
total=0
for x in range(0, 1000):
    if(x%3==0 or x%5==0):
        total=total+x
        print(x)
        cont=cont+1
print(total)