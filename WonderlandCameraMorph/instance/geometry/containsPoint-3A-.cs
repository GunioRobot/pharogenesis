containsPoint: aPoint
	"Perform a full picking op if the camera does not draw the background"
	^myCamera drawSceneBackground
		ifTrue:[super containsPoint: aPoint]
		ifFalse:[(myCamera pickAt: aPoint) notNil]