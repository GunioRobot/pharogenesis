prefereredKeyboardPosition

	| pos |
	pos _ super prefereredKeyboardPosition.
	^ pos + (self bounds: self bounds in: World) topLeft.
