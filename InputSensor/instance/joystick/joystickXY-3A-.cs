joystickXY: index

	| inputWord x y |
	inputWord _ self primReadJoystick: index.
	x _ (inputWord bitAnd: 16r7FF) - 16r400.
	y _ ((inputWord bitShift: -11) bitAnd: 16r7FF) - 16r400.
	^ x@y
	