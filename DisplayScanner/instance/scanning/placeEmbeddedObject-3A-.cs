placeEmbeddedObject: anchoredMorph

	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	anchoredMorph isMorph ifTrue: [
		anchoredMorph position: ((destX - anchoredMorph width)@lineY) - morphicOffset
	] ifFalse: [
		destY _ lineY.
		runX _ destX.
		anchoredMorph 
			displayOn: bitBlt destForm 
			at: destX - anchoredMorph width @ destY
			clippingBox: bitBlt clipRect
	].
	^ true