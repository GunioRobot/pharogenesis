clipByX1: x1 y1: y1 x2: x2 y2: y2
	| right bottom |
	right _ clipX + clipWidth.
	bottom _ clipY + clipHeight.
	x1 > clipX ifTrue:[clipX _ x1].
	y1 > clipY ifTrue:[clipY _ y1].
	x2 < right ifTrue:[right _ x2].
	y2 < bottom ifTrue:[bottom _ y2].
	clipWidth _ right - clipX.
	clipHeight _ bottom - clipY.
	clipWidth < 0 ifTrue:[clipWidth _ 0].
	clipHeight < 0 ifTrue:[clipHeight _ 0].