goDelta: aPoint 
	"Move the receiver by the relative amount in aPoint. If the pen is down, a line will be 
	drawn from the current position to the new one using the receiver's 
	form source as the shape of the drawing brush. The receiver's set 
	direction does not change.  "

	| old |
	old _ location.
	location _ location + aPoint.
	penDown ifTrue: [self drawFrom: old to: location]