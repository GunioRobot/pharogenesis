skipSeparatorsAndPeekNext

	"A special function to make nextChunk fast"
	| peek pos |
	[self atEnd] whileFalse: [
		pos _ self position.
		(peek _ self next) isSeparator ifFalse: [
			self position: pos.
			^ peek.
		].
	].
