cDigitCompare: pFirst with: pSecond len: len 
	"Precondition: pFirst len = pSecond len."
	| secondDigit ix firstDigit |
	self var: #pFirst declareC: 'unsigned char * pFirst'.
	self var: #pSecond declareC: 'unsigned char * pSecond'.
	ix _ len - 1.
	[ix >= 0]
		whileTrue: 
			[(secondDigit _ pSecond at: ix) ~= (firstDigit _ pFirst at: ix)
				ifTrue: [secondDigit < firstDigit
						ifTrue: [^ 1]
						ifFalse: [^ -1]].
			ix _ ix - 1].
	^ 0