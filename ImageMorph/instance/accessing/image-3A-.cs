image: anImage

	self changed.
	anImage depth = 1
		ifTrue: [image _ ColorForm mappingWhiteToTransparentFrom: anImage]
		ifFalse: [image _ anImage].
	super extent: image extent.
