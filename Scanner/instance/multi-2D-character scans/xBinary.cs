xBinary

	tokenType := #binary.
	token := String with: self step.
	[hereChar ~~ $- and: [(self typeTableAt: hereChar) == #xBinary]] whileTrue:
		[token := token, (String with: self step)].
	token := token asSymbol