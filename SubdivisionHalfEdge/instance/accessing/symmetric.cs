symmetric
	"Return the edge from the destination to the origin of the current edge."
	^quadEdge edges at:(id < 3 ifTrue:[id+2] ifFalse:[id - 2]).