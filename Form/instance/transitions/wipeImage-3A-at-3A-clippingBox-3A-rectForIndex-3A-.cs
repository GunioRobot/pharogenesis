wipeImage: otherImage at: topLeft clippingBox: clipBox rectForIndex: rectForIndexBlock
	| index thisRect clipRect |
	index _ 0.
	clipRect _ topLeft extent: otherImage extent.
	clipBox ifNotNil: [clipRect _ clipRect intersect: clipBox].
	[(thisRect _ rectForIndexBlock value: (index _ index+1)) == nil]
	whileFalse:
		[thisRect do:
			[:r | self copyBits: r from: otherImage at: topLeft + r topLeft
				clippingBox: clipRect rule: Form over fillColor: nil.
			Smalltalk forceDisplayUpdate]].