placeEmbeddedObject: anchoredMorph
	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	anchoredMorph isMorph 
		ifTrue: [morphicOffset = (0@0) ifTrue:
					[anchoredMorph position: (destX - width)@lineY]]
		ifFalse: [destY _ lineY.
				height _ anchoredMorph height.
				runX _ destX.
				anchoredMorph displayOn: destForm at: destX - width@destY].
	^ true