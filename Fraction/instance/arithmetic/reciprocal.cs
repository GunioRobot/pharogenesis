reciprocal
	"Refer to the comment in Number|reciprocal."
	#Numeric.
	"Changed 200/01/19 For ANSI <number> support."
	numerator = 0 ifTrue: [^ (ZeroDivide dividend: self) signal"<- Chg"].
	numerator = 1 ifTrue: [^ denominator].
	numerator = -1 ifTrue: [^ denominator negated].
	^ Fraction numerator: denominator denominator: numerator