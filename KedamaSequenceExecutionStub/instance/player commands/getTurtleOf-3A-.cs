getTurtleOf: aBreedPlayer

	| ret xy |
	xy _ self getXAndY.
	ret _ aBreedPlayer turtles aTurtleAtX: xy x y: xy y.
	^ ret ifNil: [self].
