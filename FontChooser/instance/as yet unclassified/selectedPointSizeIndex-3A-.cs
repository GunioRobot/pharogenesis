selectedPointSizeIndex: anIndex

	anIndex = 0
		ifTrue: [^self].
	pointSize := (self pointSizeList at: anIndex) withBlanksTrimmed asNumber.
	self changed: #pointSize