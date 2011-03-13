initializeWorld: aStarSqueakWorld who: anInteger

	| dims |
	dims := aStarSqueakWorld dimensions.
	world := aStarSqueakWorld.
	who := anInteger.
	x := world random: dims x - 1.
	y := world random: dims y - 1.
	wrapX := dims x asFloat.
	wrapY := dims y asFloat.
	headingRadians := ((self random: 36000) / 100.0) degreesToRadians.
	color := Color blue.
	penDown := false.
	nextTurtle := nil.
