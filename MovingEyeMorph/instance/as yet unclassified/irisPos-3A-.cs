irisPos: cp

	| a b theta x y |
	theta _ (cp - self center) theta.
	a _ inner width // 2.
	b _ inner height // 2.
	x _ a * (theta cos).
	y _ b * (theta sin).
	iris position: ((x@y) asIntegerPoint) + self center - (iris extent // 2).