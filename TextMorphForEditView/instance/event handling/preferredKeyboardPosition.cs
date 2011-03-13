preferredKeyboardPosition

	| pos |
	pos _ super preferredKeyboardPosition.
	^ pos + (self bounds: self bounds in: World) topLeft.
