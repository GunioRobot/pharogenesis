isNilStmtListNode

	|stmt|
	statements size = 1 ifFalse: [^false].
	stmt _ statements at: 1.
	^ stmt isVariable and: [stmt name = 'nil']