rotated
	" Return the dual of the current edge, directed from its right to its left"
	^quadEdge edges at: (id < 4 ifTrue:[id+1] ifFalse:[id-3])