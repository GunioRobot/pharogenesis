classificationColor
	"Return the classification index of the receiver"
	| r g b |
	r _ self isInteriorEdge ifTrue:[1] ifFalse:[0].
	g _ self isExteriorEdge ifTrue:[1] ifFalse:[0].
	b _ self isBorderEdge ifTrue:[1] ifFalse:[0].
	^Color r: r g: g b: b.