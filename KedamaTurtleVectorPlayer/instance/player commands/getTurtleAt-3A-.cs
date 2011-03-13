getTurtleAt: aPlayer

	| xy |
	aPlayer isCollection ifTrue: [
		self error: 'should not happen'.
	].
	xy _ aPlayer getXAndY.
	^ (self aTurtleAtX: xy x y: xy y) ifNil: [^ aPlayer].
