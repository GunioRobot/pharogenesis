computeBezierSplitAtHalf: index
	"Split the bezier curve at 0.5."
	| startX startY viaX viaY endX endY newIndex 
	leftViaX  leftViaY rightViaX rightViaY sharedX sharedY |
	self inline: false.

	newIndex _ self allocateBezierStackEntry.
	engineStopped ifTrue:[^0]. "Something went wrong"

	leftViaX _ startX _ self bzStartX: index.
	leftViaY _ startY _ self bzStartY: index.
	rightViaX _ viaX _ self bzViaX: index.
	rightViaY _ viaY _ self bzViaY: index.
	endX _ self bzEndX: index.
	endY _ self bzEndY: index.
	"Compute intermediate points"
	leftViaX _ leftViaX + ((viaX - startX) // 2).
	leftViaY _ leftViaY + ((viaY - startY) // 2).
	sharedX _ rightViaX _ rightViaX + ((endX - viaX) // 2).
	sharedY _ rightViaY _ rightViaY + ((endY - viaY) // 2).
	"Compute new shared point"
	sharedX _ sharedX + ((leftViaX - rightViaX) // 2).
	sharedY _ sharedY + ((leftViaY - rightViaY) // 2).
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