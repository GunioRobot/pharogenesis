skipSeparatorsAndPeekNext

	"A special function to make nextChunk fast"
	| peek save |
	[self atEnd] whileFalse: [
		save := converter saveStateOf: self.
		(peek := self next) isSeparator ifFalse: [
			converter restoreStateOf: self with: save.
			^ peek.
		].
	].
