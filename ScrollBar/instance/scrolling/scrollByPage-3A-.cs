scrollByPage: event
	nextPageDirection == nil ifTrue:
		[nextPageDirection _ event cursorPoint y >= slider center y].
	(self waitForDelay1: 300 delay2: 100) ifFalse: [^ self].
	nextPageDirection
		ifTrue: [self setValue: (value + pageDelta min: 1.0)]
		ifFalse: [self setValue: (value - pageDelta max: 0.0)]
