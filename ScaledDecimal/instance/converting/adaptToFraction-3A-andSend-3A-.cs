adaptToFraction: receiver andSend: arithmeticOpSelector 
	"Convert me to a Fraction and do the arithmetic. 
	receiver arithmeticOpSelector self."
	^ receiver perform: arithmeticOpSelector with: fraction