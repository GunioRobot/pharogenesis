addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'set X range' action: #setXRange.
	aCustomMenu add: 'set Y range' action: #setYRange.
	autoCenter
		ifTrue: [aCustomMenu add: 'turn auto-center off' action: #toggleAutoCenter]
		ifFalse: [aCustomMenu add: 'turn auto-center on' action: #toggleAutoCenter].
	realJoystickIndex
		ifNil: [aCustomMenu add: 'track real joystick' action: #trackRealJoystick]
		ifNotNil: [aCustomMenu add: 'stop tracking joystick' action: #stopTrackingJoystick].
