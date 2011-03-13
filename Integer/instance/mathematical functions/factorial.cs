factorial
	"Answer the factorial of the receiver. Create an error notification if the 
	receiver is less than 0."

	self = 0 ifTrue: [^1].
	self < 0
		ifTrue: [self error: 'factorial invalid for: ' , self printString]
		ifFalse: [^self * (self - 1) factorial]