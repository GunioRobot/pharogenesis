nextSpaces
	"read in as many consecutive space characters as possible"
	| start end |

	"short cut for a common case"
	self peekChar isSeparator not ifTrue: [ ^'' ].

	"find the start and end of the sequence of spaces"
	start _ pos.
	end _ text indexOfAnyOf: CSNonSeparators startingAt: start ifAbsent: [ text size + 1 ].
	end _ end - 1.

	"update pos and return the sequence"
	pos _ end + 1.
	^text copyFrom: start to: end