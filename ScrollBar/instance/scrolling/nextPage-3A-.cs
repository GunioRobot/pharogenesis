nextPage: event
	"Note: this method is no longer called, except by old scrollBars"
	(self waitForDelay1: 300 delay2: 100) ifFalse: [^ self].
	event cursorPoint y >= slider center y
		ifTrue: [self setValue: (value + pageDelta min: 1.0)]
		ifFalse: [self setValue: (value - pageDelta max: 0.0)]
