def getFreq(text):
    text = text.lower()

    letters= sorted([char for char in set(text) if char.isalpha()])

    letter_dict = dict.fromkeys(letters, 0)

    for char in text:
        if char in letter_dict:
            letter_dict[char] +=1
    return letter_dict, letters
      
text_es ='''Doña Uzeada de Ribera Maldonado de Bracamonte y Anaya era baja, rechoncha, abigotada. Ya no existia razon para llamar talle al suyo. Sus colores vivos, sanos, podian mas que el albayalde y el soliman del afeite, con que se blanqueaba por simular melancolias. Gastaba dos parches oscuros, adheridos a las sienes y que fingian medicamentos. Tenia los ojitos ratoniles, maliciosos. Sabia dilatarlos duramente o desmayarlos con recato o levantarlos con disimulo. Caminaba contoneando las imposibles caderas y era dificil, al verla, no asociar su estampa achaparrada con la de ciertos palmipedos domesticos. Sortijas celestes y azules le ahorcaban las falanges'''      
text_pl ='''Każdego roku Mateusz nie może się doczekać tego dnia. Już wiele tygodni przed tą datą starannie planuje całe przyjęcie. Zaczyna od wyboru listy gości. Nie można oczywiście zapomnieć o rodzinie. Dlatego zawsze mile widziani są: mama, tata, brat oraz siostra. Czasem udaje się też zaprosić babcię, jeżeli dobrze się czuje. Przecież im więcej gości tym lepiej - nie tylko ze względu na prezenty. Oprócz gości będących osobami z jego rodziny, Mateusz nigdy nie zapomina też o swoich kolegach i przyjaciołach. Co to byłyby za urodziny, na których nie pojawiłby się Kacper, Ola, Wojtek albo'''
text_en ='''Ken Paxton, the attorney general of Texas, has asked a federal judge or an emergency order that would force the special counsel, Jack Smith, to preserve all of his investigative records even as Mr. Smith moves toward shutting down the criminal cases he has brought against President-elect Donald J. Trump. Mr. Paxton’s emergency request — filed on Monday in Federal District Court in Amarillo — came as some of Mr. Trump’s allies have said they want to hold the special counsel accountable for prosecuting Mr. Trump.'''

result_es, letters_es= getFreq(text_es)

print("---------------------spanish----------------")

for char in letters_es:
    print("%5s %5f" %(char, (100* result_es[char]/ len(text_es)))+ "%")
    
result_pl, letters_pl= getFreq(text_pl)

print("---------------------polish--------------------")

for char in letters_pl:
    print("%5s %5f" %(char, (100* result_pl[char]/ len(text_pl))) + "%")
    
result_en, letters_en= getFreq(text_en)

print("---------------------english----------------")

for char in letters_en:
    print("%5s %5f" %(char, (100*result_en[char]/ len(text_en)))+ "%")



