asScaledDecimal: scaleNotUsed 
	"The number of significant digits of the answer is the same as the 
	number of decimal digits in the receiver.  The scale of the answer is 0."
	#Numeric.
	"add 200/01/19 For <integer> protocol."
	^ ScaledDecimal newFromNumber: self scale: 0