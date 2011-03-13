basicGetDistanceTo: aPlayer

	| i |
	i _ self index.
	^ ((aPlayer getX - ((turtles arrays at: 2) at: i)) squared + (aPlayer getY - ((turtles arrays at: 3) at: i)) squared) sqrt.
