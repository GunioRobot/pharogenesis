= anObject
	anObject isComplex
		ifTrue: [^ (real = anObject real) & (imaginary = anObject imaginary)]
		ifFalse: [^ anObject adaptToComplex: self andSend: #=]