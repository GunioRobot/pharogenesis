groupForward: dist

	| x y headingRadians |
	self size = 0 ifTrue: [^ self].

	x _ (arrays at: 2) first.
	y _ (arrays at: 3) first.
	headingRadians _ (arrays at: 4) first.
	self groupSetX: (x + (dist asFloat * headingRadians cos)).
	self groupSetY: (y - (dist asFloat * headingRadians sin)).
