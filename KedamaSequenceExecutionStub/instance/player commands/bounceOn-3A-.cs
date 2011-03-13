bounceOn: aPlayer

	| aTurtle xy |
	aPlayer = exampler ifTrue: [^ false].
	xy _ self getXAndY.
	aTurtle _ aPlayer turtles aTurtleAtX: xy x y: xy y.
	aTurtle ifNil: [^ false].
	self doBounceOn: aTurtle of: aPlayer.
	^ true.
