doBounceOn: aTurtle of: aPlayer

	| bounceDir myHeading neg newHeading xy |
	aPlayer = exampler ifTrue: [^ false].
	bounceDir _ aTurtle getHeading.
	myHeading _ self getHeading.
	neg _ (myHeading + 180.0) \\ 360.0.

	newHeading _ (bounceDir - neg + bounceDir).
	self setHeading: newHeading.
	[xy _ self getXAndY. (aPlayer turtles aTurtleAtX: xy x y: xy y) ~= nil] whileTrue: [
		self forward: 0.5.
	].
