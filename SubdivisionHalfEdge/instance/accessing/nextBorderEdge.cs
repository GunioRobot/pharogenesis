nextBorderEdge
	| edge |
	edge _ self originNext.
	[edge == self] whileFalse:[
		edge isBorderEdge ifTrue:[^edge symmetric].
		edge _ edge originNext].
	^nil