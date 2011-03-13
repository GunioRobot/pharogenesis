scrollByPage: event

	self flag: #bob.	"this would appear to be obsolete now"

	nextPageDirection == nil ifTrue: [self setNextDirectionFromEvent: event].
	(self waitForDelay1: 300 delay2: 100) ifFalse: [^ self].
	nextPageDirection
		ifTrue: [self setValue: (value + pageDelta min: 1.0)]
		ifFalse: [self setValue: (value - pageDelta max: 0.0)]
