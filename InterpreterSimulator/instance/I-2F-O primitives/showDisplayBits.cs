showDisplayBits
	| displayObj destBits raster destDepth pixPerWord simDisp realDisp top bottom rect |
	displayObj _ self splObj: TheDisplay.
	self targetForm = displayObj ifFalse: [^ self].
	destBits _ self fetchPointer: 0 ofObject: displayObj.
	destDepth _ self fetchInteger: 3 ofObject: displayObj.
	pixPerWord _ 32 // destDepth.
	raster _ displayForm width + (pixPerWord - 1) // pixPerWord.
	simDisp _ Form new hackBits: memory.
	realDisp _ Form new hackBits: displayForm bits.
	top _ myBitBlt affectedTop.
	bottom _ myBitBlt affectedBottom.
	realDisp
		copy: (0 @ (top * raster) extent: 4 @ (bottom - top * raster))
		from: 0 @ (destBits + 4 // 4 + (top * raster))
		in: simDisp
		rule: Form over.
	rect _ 0 @ top corner: displayForm width @ bottom.
	Display
		copy: (rect translateBy: self displayLocation)
		from: rect topLeft
		in: displayForm
		rule: Form over