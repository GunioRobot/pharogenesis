computeBezier: index splitAt: param
	"Split the bezier curve at the given parametric value.
	Note: Since this method is only invoked to make non-monoton
		beziers monoton we must check for the resulting y values
		to be *really* between the start and end value."
	| startX startY viaX viaY endX endY newIndex 
	leftViaX  leftViaY rightViaX rightViaY sharedX sharedY |
	self inline: false.

	self var: #param declareC:'double param'.
	leftViaX _ startX _ self bzStartX: index.
	leftViaY _ startY _ self bzStartY: index.
	rightViaX _ viaX _ self bzViaX: index.
	rightViaY _ viaY _ self bzViaY: index.
	endX _ self bzEndX: index.
	endY _ self bzEndY: index.

	"Compute intermediate points"
	sharedX _ leftViaX _ leftViaX + ((viaX - startX) asFloat * param) asInteger.
	sharedY _ leftViaY _ leftViaY + ((viaY - startY) asFloat * param) asInteger.
	rightViaX _ rightViaX + ((endX - viaX) asFloat * param) asInteger.
	rightViaY _ rightViaY + ((endY - viaY) asFloat * param) asInteger.
	"Compute new shared point"
	sharedX _ sharedX + ((rightViaX - leftViaX) asFloat * param) asInteger.
	sharedY _ sharedY + ((rightViaY - leftViaY) asFloat * param) asInteger.

	"Check the new via points"
	leftViaY _ self assureValue: leftViaY between: startY and: sharedY.
	rightViaY _ self assureValue: rightViaY between: sharedY and: endY.

	newIndex _ self allocateBezierStackEntry.
	engineStopped ifTrue:[^0]. "Something went wrong"

	"Store the first part back"
	self bzViaX: index put: leftViaX.
	self bzViaY: index put: leftViaY.
	self bzEndX: index put: sharedX.
	self bzEndY: index put: sharedY.
	"Store the second point back"
	self bzStartX: newIndex put: sharedX.
	self bzStartY: newIndex put: sharedY.
	self bzViaX: newIndex put: rightViaX.
	self bzViaY: newIndex put: rightViaY.
	self bzEndX: newIndex put: endX.
	self bzEndY: newIndex put: endY.

	^newIndex