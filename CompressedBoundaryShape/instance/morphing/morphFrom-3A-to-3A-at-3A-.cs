morphFrom: srcShape to: dstShape at: ratio
	| scale unscale srcPoints dstPoints pt1 pt2 x y |
	scale _ (ratio * 1024) asInteger.
	scale < 0 ifTrue:[scale _ 0].
	scale > 1024 ifTrue:[scale _ 1024].
	unscale _ 1024 - scale.
	srcPoints _ srcShape points.
	dstPoints _ dstShape points.
	1 to: points size do:[:i|
		pt1 _ srcPoints at: i.
		pt2 _ dstPoints at: i.
		x _ ((pt1 x * unscale) + (pt2 x * scale)) bitShift: -10.
		y _ ((pt1 y * unscale) + (pt2 y * scale)) bitShift: -10.
		points at: i put: x@y].