nextTag
	"Read the next tag. Return an association with the key being the tag id and its value the contents of the chunk following."
	| word tag length |
	word _ self nextWord.
	"Extract tag and length from the word"
	length _ word bitAnd: 16r3F.
	tag _ word bitShift: -6.
	"Check if an extra word follows"
	length = 16r3F ifTrue:[length _ self nextULong].
	^Association key: tag value: (self nextBytes: length).