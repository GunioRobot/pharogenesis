checkForMoreKeyboard
	"Quick check for more keyboard activity -- Allows, eg, many characters
	to be accumulated into a single replacement during type-in."

	| oldPoint |
	Sensor keyboardPressed ifFalse: [^ nil].
	oldPoint _ lastEvent cursorPoint.
	lastEvent _ MorphicEvent new
		setKeyValue: Sensor keyboard asciiValue
		mousePoint: oldPoint
		buttons: Sensor primMouseButtons
		hand: self.
	remoteConnections size > 0 ifTrue: [self transmitEvent: lastEvent].
	^ lastEvent