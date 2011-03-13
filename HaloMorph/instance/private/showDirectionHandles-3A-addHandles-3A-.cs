showDirectionHandles: wantToShow addHandles: needHandles

	wantToShow
		ifTrue: [directionArrowAnchor _ target referencePositionInWorld]  "not nil means show"
		ifFalse: [directionArrowAnchor _ nil].
	needHandles ifTrue: [self addHandles]
