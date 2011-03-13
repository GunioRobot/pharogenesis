matchKeyword
	"Return true if we are looking at a keyword (and its argument)."

	hereType == #word ifFalse: [^ false].
	tokenType == #leftParenthesis ifTrue: [^ true].
	tokenType == #leftBracket ifTrue: [^ true].
	tokenType == #leftBrace ifTrue: [^ true].
	^ false