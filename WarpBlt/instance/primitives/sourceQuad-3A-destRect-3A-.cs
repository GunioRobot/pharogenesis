sourceQuad: pts destRect: aRectangle
	| fixedPt1 |
	sourceX _ sourceY _ 0.
	self destRect: aRectangle.
	fixedPt1 _ (pts at: 1) x isInteger ifTrue: [16384] ifFalse: [16384.0].
	p1x _ (pts at: 1) x * fixedPt1.
	p2x _ (pts at: 2) x * fixedPt1.
	p3x _ (pts at: 3) x * fixedPt1.
	p4x _ (pts at: 4) x * fixedPt1.
	p1y _ (pts at: 1) y * fixedPt1.
	p2y _ (pts at: 2) y * fixedPt1.
	p3y _ (pts at: 3) y * fixedPt1.
	p4y _ (pts at: 4) y * fixedPt1.
	p1z _ p2z _ p3z _ p4z _ 16384.  "z-warp ignored for now"
