stepTime
	^ realJoystickIndex
		ifNil:
			[0]  "fast as we can to track actual joystick"
		ifNotNil:
			[super stepTime]
