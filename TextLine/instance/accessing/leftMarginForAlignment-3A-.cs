leftMarginForAlignment: alignmentCode
	alignmentCode = 1 ifTrue: [^ self left + paddingWidth].  "right flush"
	alignmentCode = 2 ifTrue: [^ self left + (paddingWidth//2)].  "centered"
	^ self left  "leftFlush and justified"