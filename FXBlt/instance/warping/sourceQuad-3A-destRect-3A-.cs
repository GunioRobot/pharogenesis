sourceQuad: pts destRect: aRectangle
	| fixedPt1 |
	sourceX _ sourceY _ 0.
	self destRect: aRectangle.
	fixedPt1 _ (pts at: 1) x isInteger ifTrue: [16384] ifFalse: [16384.0].
	warpQuad _ pts collect:[:pt| pt * fixedPt1].