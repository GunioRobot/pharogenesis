asHeading
	"Treating the receiver as a velocity (with negative y meaning up for the time being), return the heading, in degrees,  represented.  Returns an integer result in the range [0, 359]
	5/13/96 sw"
	
	| ans |
	x == 0 ifTrue:
		[^ y > 0 ifTrue: [180] ifFalse: [0]]. 
 	ans _ (90 + ((y asFloat / x) arcTan radiansToDegrees rounded)) \\ 360.
	^ x > 0
		ifTrue:
			[ans]
		ifFalse:
			[ans + 180]


"  Array with:
		(10 @ 10) asHeading
	with:
		(10 @ -10) asHeading
	with:
		(-10 @ 10) asHeading
	with:
		(-10 @ -10) asHeading"