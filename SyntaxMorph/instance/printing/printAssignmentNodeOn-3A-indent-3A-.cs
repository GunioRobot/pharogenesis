printAssignmentNodeOn: strm indent: level
	"sometimes an assignment is in parens"
	| parens above |

	parens _ submorphs size >= 3.
	parens ifTrue: [
		above _ self ownerPrecedence.	"high if not in an expression"
		parens _ above <= 3].	"assignment is a noun inside a message"
	parens ifTrue: [strm nextPut: $( ].
	self
		submorphsDoIfSyntax: [ :sub |
			sub printOn: strm indent: level.
			strm ensureASpace.
		]
		ifString: [ :sub |
			strm ensureNoSpace. 	"_ will have a leading space"
			self printSimpleStringMorph: sub on: strm
		].
	parens ifTrue: [strm ensureNoSpace; nextPut: $) ].
