- anObject
	"Answer the difference between the receiver and aNumber."
	| a b c d newReal newImaginary |
	anObject isComplex
		ifTrue:
			[a _ self real.
			b _ self imaginary.
			c _ anObject real.
			d _ anObject imaginary.
			newReal _ a - c.
			newImaginary _ b - d.
			^ Complex real: newReal imaginary: newImaginary]
		ifFalse:
			[^ anObject adaptToComplex: self andSend: #-]