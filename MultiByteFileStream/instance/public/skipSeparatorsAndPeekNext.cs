skipSeparatorsAndPeekNext

	"A special function to make nextChunk fast"
	| peek save |
	[self atEnd] whileFalse: [
		save _ converter saveStateOf: self.
		(peek _ self next) isSeparator ifFalse: [
			converter restoreStateOf: self with: save.
			^ peek.
		].
	].
