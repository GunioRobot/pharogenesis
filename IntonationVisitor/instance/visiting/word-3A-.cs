word: aWord
	| accent |
	super word: aWord.

	((self functionWords includes: word string asLowercase) and: [phrase words first ~~ word]) ifTrue: [^ self].
	self isYesNoQuestionClause ifTrue: [accent _ 'L*'] ifFalse: [accent _ 'H*'].
	(word syllables detect: [ :one | one stress > 0] ifNone: [word syllables first]) accent: accent