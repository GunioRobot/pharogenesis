nextTag
	"Read the next tag. Return an association with the key being the tag id and its value the contents of the chunk following."
	| word tag length |
	word := self nextWord.
	"Extract tag and length from the word"
	length := word bitAnd: 16r3F.
	tag := word bitShift: -6.
	"Check if an extra word follows"
	length = 16r3F ifTrue:[length := self nextULong].
	^Association key: tag value: (self nextBytes: length).