nextPage: event
	event cursorPoint >= slider topLeft
		ifTrue: [self setValue: value + pageDelta]
		ifFalse: [self setValue: value - pageDelta]
