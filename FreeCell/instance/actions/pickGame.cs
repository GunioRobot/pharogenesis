pickGame
	| seed |
	seed _ self promptForSeed.
	seed isNil ifTrue: [^ self].
	self newGameNumber: seed.
	state _ #pickGame