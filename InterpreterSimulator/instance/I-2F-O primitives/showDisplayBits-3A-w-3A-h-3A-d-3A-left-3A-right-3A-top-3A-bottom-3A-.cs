showDisplayBits: destBits w: w h: h d: d left: left right: right top: top bottom: bottom
	| raster pixPerWord simDisp realDisp rect |
	pixPerWord _ 32 // d.
	raster _ displayForm width + (pixPerWord - 1) // pixPerWord.
	simDisp _ Form new hackBits: memory.
	realDisp _ Form new hackBits: displayForm bits.
	realDisp
		copy: (0 @ (top * raster) extent: 4 @ (bottom - top * raster))
		from: 0 @ (destBits // 4 + (top * raster))
		in: simDisp
		rule: Form over.
	rect _ 0 @ top corner: displayForm width @ bottom.
	Display
		copy: (rect translateBy: self displayLocation)
		from: rect topLeft
		in: displayForm
		rule: Form over