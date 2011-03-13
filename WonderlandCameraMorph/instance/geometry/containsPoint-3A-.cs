containsPoint: aPoint
	"Perform a full picking op if the camera does not draw the background"
	myCamera drawSceneBackground
		ifTrue:[^super containsPoint: aPoint].
	"*** hack ***"
	pickedPoint = aPoint 
		ifFalse:[pickedActor _ myCamera pickAt: aPoint].
	pickedPoint _ aPoint.
	^pickedActor notNil