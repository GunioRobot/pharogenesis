divideFastAndSecureBy: anObject
	"Answer the result of dividing receiver by aNumber"
	" Both operands are scaled to avoid arithmetic overflow. 
	  This algorithm works for a wide range of values, and it needs only three divisions.
	  Note: #reciprocal uses #/ for devision "
	 
	| r d newReal newImaginary |
	anObject isComplex ifTrue:
		[anObject real abs > anObject imaginary abs
		  ifTrue:
		    [r _ anObject imaginary / anObject real.
			d _ r*anObject imaginary + anObject real.
			newReal _ r*imaginary + real/d.
			newImaginary _ r negated * real + imaginary/d.
		    ]
		  ifFalse:
		    [r _ anObject real / anObject imaginary.
			d := r*anObject real + anObject imaginary.
			newReal _ r*real + imaginary/d.
			newImaginary _ r*imaginary - real/d.
		    ].
		
		^ Complex real: newReal imaginary: newImaginary].
	^ anObject adaptToComplex: self andSend: #/.