* anObject
	"Answer the result of multiplying the receiver by aNumber."
	| a b c d newReal newImaginary |
	anObject isComplex
		ifTrue:
			[a _ self real.
			b _ self imaginary.
			c _ anObject real.
			d _ anObject imaginary.
			newReal _ (a * c) - (b * d).
			newImaginary _ (a * d) + (b * c).
			^ Complex real: newReal imaginary: newImaginary]
		ifFalse:
			[^ anObject adaptToComplex: self andSend: #*]