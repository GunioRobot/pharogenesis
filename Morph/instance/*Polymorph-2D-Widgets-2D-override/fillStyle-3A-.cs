fillStyle: aFillStyle
	"Set the current fillStyle of the receiver.
	Optimized for no change."
	
	(self valueOfProperty: #fillStyle ifAbsent: []) = aFillStyle
		ifTrue: [^self]. "no change optimization"
	self setProperty: #fillStyle toValue: aFillStyle.
	"Workaround for Morphs not yet converted"
	color := aFillStyle asColor.
	self changed.