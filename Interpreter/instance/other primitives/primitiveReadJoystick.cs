primitiveReadJoystick
	"Read an input word from the joystick with the given index."

	| index |
	index _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		self pop: 2.  "index, rcvr"
		self push: (self positive32BitIntegerFor: (self joystickRead: index)).
	].