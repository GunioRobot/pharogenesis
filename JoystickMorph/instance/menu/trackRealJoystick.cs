trackRealJoystick

	| s |
	s _ FillInTheBlank
		request: 'Number of joystick to track?'
		initialAnswer: '1'.
	s isEmpty ifTrue: [^ self].
	realJoystickIndex _ Number readFromString: s.
	self startStepping.
