asSquare: aPoint
	self squaresDo:[:sq| (sq bounds containsPoint: aPoint) ifTrue:[^sq valueOfProperty: #squarePosition]].
	^nil