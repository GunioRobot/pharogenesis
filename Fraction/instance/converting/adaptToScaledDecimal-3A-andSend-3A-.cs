adaptToScaledDecimal: receiverScaledDecimal andSend: arithmeticOpSelector 
	"Convert receiverScaledDecimal to a Fraction and do the arithmetic. 
	receiverScaledDecimal arithmeticOpSelector self."
	#Numeric.
	"add 200/01/19 For ScaledDecimal support."
	^ receiverScaledDecimal asFraction perform: arithmeticOpSelector with: self