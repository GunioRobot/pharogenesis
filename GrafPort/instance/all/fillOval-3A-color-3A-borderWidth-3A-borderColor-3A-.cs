fillOval: rect color: fillColor borderWidth: borderWidth borderColor: borderColor
	"Possible future optimizations:
	Ä Compute an inset rectangle - if clipRect inside, then just paint with fillCOlor!
	Ä Note quadrants of clipRect, and only run code for those quadrants."
	| wp fillTone w borderTone centerX centerY centerYBias centerXBias radiusSquared xOverY maxy dxs dx prevLeft left |
	rect area <= 0 ifTrue: [^ self].
	wp _ borderWidth asPoint.
	sourceForm _ nil. 
	height _ 1.
	fillColor == nil
		ifTrue: [fillTone _ nil]
		ifFalse: [self fillColor: fillColor.  fillTone _ halftoneForm].
	(((w _ wp x) * wp y) = 0 or: [borderColor == nil])
		ifTrue: [borderTone _ nil]
		ifFalse: [self fillColor: borderColor.  borderTone _ halftoneForm].
	centerX _ rect center x.
	centerY _ rect center y.
	centerYBias _ rect height odd ifTrue: [0] ifFalse: [1].
	centerXBias _ rect width odd ifTrue: [0] ifFalse: [1].
	radiusSquared _ (rect height asFloat / 2.0) squared - 0.01.
	xOverY _ rect width asFloat / rect height asFloat.
	maxy _ rect height - 1 // 2.
	dxs _ Array new: maxy + 1.

	"First do the inner fill, and collect x values"
	0 to: maxy do:
		[:dy |
		dx _ ((radiusSquared - (dy * dy) asFloat) sqrt * xOverY) truncated.
		dxs at: dy+1 put: dx.
		fillTone == nil ifFalse:
			[halftoneForm _ fillTone.
			height _ 1.
			width _ dx + dx + centerXBias + 1.
			destX _ centerX - centerXBias - dx.
			destY _ centerY - centerYBias - dy.
			self copyBits.
			destY _ centerY + dy.
			self copyBits]].

	"Now do the border, using the same x values"
	borderTone ifNil: [^ self].
	prevLeft _ centerX.
	maxy to: 0 by: -1 do: [:dy |
		dx _ dxs at: dy+1.
		halftoneForm _ borderTone.
		height _ wp y.
		left _ centerX - centerXBias - dx.
		width _ prevLeft - left + w.
		destX _ left.
		destY _ centerY - centerYBias - dy.
		self copyBits.
		destX _ centerX + dx + 1 - width.
		self copyBits.
		destY _ centerY + dy - height + 1.
		self copyBits.
		destX _ left.
		self copyBits.
		prevLeft _ left].
