stepInY
	"Step to the next y value"
	inFirstRegion ifTrue:[
		"In the upper region we must step until we reach the next y value"
		[(aSquared * (y-0.5)) > (bSquared * (x+1))] whileTrue:[
			d1 < 0.0
				ifTrue:[d1 _ d1 + (bSquared * (2*x+3)).
						x _ x + 1]
				ifFalse:[d1 _ d1 + (bSquared * (2*x+3)) + (aSquared * (-2*y+2)).
						y _ y - 1.
						^x _ x + 1]].
		"Stepping into second region"
		d2 _ (bSquared * (x + 0.5) squared) + (aSquared * (y-1) squared) - (aSquared * bSquared).
		inFirstRegion _ false.
	].
	"In the lower region each step is a y-step"
	d2 < 0.0
		ifTrue:[d2 _ d2 + (bSquared * (2*x+2)) + (aSquared * (-2*y+3)).
				x _ x + 1]
		ifFalse:[d2 _ d2 + (aSquared * (-2*y+3))].
	y _ y - 1.
	^x