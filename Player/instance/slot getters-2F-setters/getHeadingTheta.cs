getHeadingTheta
	"Answer the angle, in degrees, between the positive x-axis and the receiver's heading vector"

	| aHeading excess normalized |
	aHeading _ self getHeadingUnrounded.
	excess _ aHeading - (aHeading rounded).

	normalized _ (450 - aHeading) \\ 360.
	^ normalized + excess