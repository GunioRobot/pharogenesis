computeBounds
	bounds := self transform localBoundsToGlobal: (shape bounds).
	fullBounds := nil.