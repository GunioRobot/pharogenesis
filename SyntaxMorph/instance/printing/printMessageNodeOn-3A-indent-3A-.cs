printMessageNodeOn: strm indent: level

	| parens me above |

	parens _ parseNode receiver notNil.
	parens ifTrue: [me _ self selector precedence.
		above _ self ownerPrecedence.	"high if not in an expression"
		parens _ me > above].
	parens ifTrue: [strm nextPut: $( ].
	self
		submorphsDoIfSyntax: [ :sub |
			sub printOn: strm indent: level.
			strm ensureASpace.
		]
		ifString: [ :sub |
			self printSimpleStringMorph: sub on: strm
		].
	parens ifTrue: [strm ensureNoSpace; nextPut: $) ].
