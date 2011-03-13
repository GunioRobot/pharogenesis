getAngleTo: aPlayer

	| ret |
	ret _ ((aPlayer x - self x)@(aPlayer y - self y)) theta radiansToDegrees + 90.0.
	ret > 360.0 ifTrue: [^ ret - 360].
	^ ret.
