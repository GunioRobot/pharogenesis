reciprocal
	#Numeric.
	"Changed 200/01/19 For ANSI <number> support."
	self = 0 ifTrue: ["<- Chg"
		^ (ZeroDivide dividend: self) signal"<- Chg"].
	"<- Chg"
	^ 1.0 / self