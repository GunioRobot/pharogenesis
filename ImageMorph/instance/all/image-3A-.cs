image: anImage

	| oldExtent |
	image == nil
		ifTrue: [oldExtent _ nil]
		ifFalse: [oldExtent _ image extent].
	self changed.
	anImage depth = 1
		ifTrue: [image _ ColorForm mappingWhiteToTransparentFrom: anImage]
		ifFalse: [image _ anImage].
	oldExtent = anImage extent
		ifFalse: [super extent: image extent].
