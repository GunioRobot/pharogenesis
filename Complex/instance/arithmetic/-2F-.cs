/ anObject
	"Answer the result of dividing receiver by aNumber"
	| a b c d newReal newImaginary |
	anObject isComplex ifTrue:
		[a _ self real.
		b _ self imaginary.
		c _ anObject real.
		d _ anObject imaginary.
		newReal _ ((a * c) + (b * d)) / ((c * c) + (d * d)).
		newImaginary _ ((b * c) - (a * d)) / ((c * c) + (d * d)).
		^ Complex real: newReal imaginary: newImaginary].
	^ anObject adaptToComplex: self andSend: #/.