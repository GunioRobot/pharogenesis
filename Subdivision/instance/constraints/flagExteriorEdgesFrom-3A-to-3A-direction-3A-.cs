flagExteriorEdgesFrom: lastEdge to: nextEdge direction: thisWay
	| tmpEdge |
	lastEdge isBorderEdge ifFalse:[self error: 'not border'].
	nextEdge isBorderEdge ifFalse:[self error: 'not border'].
	tmpEdge := lastEdge.
	thisWay ifTrue:[
		[tmpEdge := tmpEdge originNext.
		tmpEdge == nextEdge] whileFalse:[
			tmpEdge isBorderEdge ifTrue:[self error: 'border'].
			tmpEdge isExteriorEdge: true.
		].
	] ifFalse:[
		[tmpEdge := tmpEdge originPrev.
		tmpEdge == nextEdge] whileFalse:[
			tmpEdge isBorderEdge ifTrue:[self error: 'border'].
			tmpEdge isExteriorEdge: true.
		].
	].