reciprocal
	"Answer 1 divided by the receiver. Create an error notification if the 
	receiver is 0."
	#Numeric.
	"Changed 200/01/19 For ANSI <number> support."
	self = 0 ifTrue: [^ (ZeroDivide dividend: self) signal"<- Chg"].
	^ 1 / self