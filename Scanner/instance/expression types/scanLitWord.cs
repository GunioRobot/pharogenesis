scanLitWord
	"Accumulate keywords and asSymbol the result."

	| t |
	[(typeTable at: hereChar asciiValue ifAbsent: [#xLetter]) = #xLetter] whileTrue: [
		t _ token.
		self xLetter.
		token _ t , token
	].
	token _ token asSymbol.
