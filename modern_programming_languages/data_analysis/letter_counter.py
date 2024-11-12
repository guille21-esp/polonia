text_es = '''Doña Uzeada de Ribera Maldonado de Bracamonte, Krakowia y Anaya era baja, rechoncha, abigotada. Ya no existia razon para llamar talle al suyo. Sus colores vivos, sanos, podian mas que el albayalde y el soliman del afeite, con que se blanqueaba por simular melancolias. Gastaba dos parches oscuros, adheridos a las sienes y que fingian medicamentos. Tenia los ojitos ratoniles, maliciosos. Sabia dilatarlos duramente o desmayarlos con recato o levantarlos con disimulo. Caminaba contoneando las imposibles caderas y era dificil, al verla, no asociar su estampa achaparrada con la de ciertos palmipedos domesticos. Sortijas celestes y azules le ahorcaban las falanges'''
text_es.lower()
#print(text_es)
letras=[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
letters= sorted(list(set(list(text_es.lower()))))
print(letters)

#for x in range(len(text_es)):
    
for char in text_es:
    match char:
        case 'a':
            letras[0]=letras[0]+1
        case "b":
            letras[1]=letras[1]+1
        case "c":
            letras[2]=letras[2]+1
        case "d":
            letras[3]=letras[3]+1
        case "e":
            letras[4]=letras[4]+1
        case "f":
            letras[5]=letras[5]+1
        case "g":
            letras[6]=letras[6]+1
        case "h":
            letras[7]=letras[7]+1
        case "i":
            letras[8]=letras[8]+1
        case "j":
            letras[9]=letras[9]+1
        case "k":
            letras[10]=letras[10]+1
        case "l":
            letras[11]=letras[11]+1
        case "m":
            letras[12]=letras[12]+1
        case "n":
            letras[13]=letras[13]+1
        case "o":
            letras[14]=letras[14]+1
        case "p":
            letras[15]=letras[15]+1
        case "q":
            letras[16]=letras[16]+1
        case "r":
            letras[17]=letras[17]+1
        case "s":
            letras[18]=letras[18]+1
        case "t":
            letras[19]=letras[19]+1
        case "u":
            letras[20]=letras[20]+1
        case "v":
            letras[21]=letras[21]+1
        case "w":
            letras[22]=letras[22]+1
        case "x":
            letras[23]=letras[23]+1
        case "y":
            letras[24]=letras[24]+1
        case "z":
            letras[25]=letras[25]+1
        case "ñ":
            letras[26]=letras[26]+1
           
for i in range(len(letras)):
    print(letters[i+3] + ": " + str(letras[i]))
        
