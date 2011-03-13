fill: fillColor
	fillColor isSolidFill
		ifTrue: [self paint: fillColor asColor operation: #fill]
		ifFalse: [self preserveStateDuring: [:inner | inner clip; drawGradient: fillColor]]