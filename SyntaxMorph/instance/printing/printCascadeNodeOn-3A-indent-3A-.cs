printCascadeNodeOn: strm indent: level

	| parens cnt me above |

	parens _ parseNode receiver notNil.
	parens ifTrue: [me _ self selector precedence.
		above _ self ownerPrecedence.	"high if not in an expression"
		parens _ me > above].
	parens ifTrue: [strm nextPut: $( ].
	cnt _ 0.
	self
		submorphsDoIfSyntax: [ :sub |
			cnt _ cnt + 1.
			"maybe we want to test sub isCascadePart for the following???"
			cnt > 2 ifTrue: [strm nextPutAll: '; '].
			sub printOn: strm indent: level.
			strm ensureASpace.
		]
		ifString: [ :sub |
			self printSimpleStringMorph: sub on: strm
		].
	parens ifTrue: [strm ensureNoSpace; nextPut: $) ].
