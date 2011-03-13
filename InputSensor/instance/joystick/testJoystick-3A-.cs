testJoystick: index
	"Sensor testJoystick: 3"

	| f pt buttons status |
	f _ Form extent: 110@50.
	[Sensor anyButtonPressed] whileFalse: [
		pt _ Sensor joystickXY: index.
		buttons _ Sensor joystickButtons: index.
		status _
'xy: ', pt printString, '
buttons: ', buttons printStringHex.
		f fillWhite.
		status displayOn: f at: 10@10.
		f displayOn: Display at: 10@10.
	].
