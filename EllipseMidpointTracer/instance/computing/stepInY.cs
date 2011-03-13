stepInY
	"Step to the next y value"
	inFirstRegion ifTrue:[
		"In the upper region we must step until we reach the next y value"
		[(aSquared * (y-0.5)) > (bSquared * (x+1))] whileTrue:[
			d1 < 0.0
				ifTrue:[d1 := d1 + (bSquared * (2*x+3)).
						x := x + 1]
				ifFalse:[d1 := d1 + (bSquared * (2*x+3)) + (aSquared * (-2*y+2)).
						y := y - 1.
						^x := x + 1]].
		"Stepping into second region"
		d2 := (bSquared * (x + 0.5) squared) + (aSquared * (y-1) squared) - (aSquared * bSquared).
		inFirstRegion := false.
	].
	"In the lower region each step is a y-step"
	d2 < 0.0
		ifTrue:[d2 := d2 + (bSquared * (2*x+2)) + (aSquared * (-2*y+3)).
				x := x + 1]
		ifFalse:[d2 := d2 + (aSquared * (-2*y+3))].
	y := y - 1.
	^x