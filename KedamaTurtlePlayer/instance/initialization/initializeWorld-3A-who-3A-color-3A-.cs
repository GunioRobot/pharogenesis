initializeWorld: aStarSqueakWorld who: anInteger color: cPixel

	| dims |
	dims _ aStarSqueakWorld dimensions.
	world _ aStarSqueakWorld.
	who _ anInteger.
	x _ world random: dims x - 1.
	y _ world random: dims y - 1.
	headingRadians _ ((self random: 36000) / 100.0) degreesToRadians.
	color _ cPixel.
	self isGroup: false.
	self show.
