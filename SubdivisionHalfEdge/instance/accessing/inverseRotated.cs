inverseRotated
	" Return the dual of the current edge, directed from its left to its right."
	^quadEdge edges at: (id > 1 ifTrue:[id-1] ifFalse:[id+3])