initializeWorld: aStarSqueakWorld who: anInteger

	| dims |
	dims _ aStarSqueakWorld dimensions.
	world _ aStarSqueakWorld.
	who _ anInteger.
	x _ world random: dims x - 1.
	y _ world random: dims y - 1.
	wrapX _ dims x asFloat.
	wrapY _ dims y asFloat.
	headingRadians _ ((self random: 36000) / 100.0) degreesToRadians.
	color _ Color blue.
	penDown _ false.
	nextTurtle _ nil.
