getTurtleAt: aPlayer

	| ret xy |
	xy _ aPlayer getXAndY.
	ret _ exampler turtles aTurtleAtX: xy x y: xy y.
	^ ret ifNil: [self].
