basicGetAngleTo: player

	| ret i |
	i _ self index.
	ret _ ((player getX - ((turtles arrays at: 2) at: i))@(player getY - ((turtles arrays at: 3) at: i))) theta radiansToDegrees + 90.0.
	ret > 360.0 ifTrue: [^ ret - 360.0].
	^ ret.
