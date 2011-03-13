lastKnownCursorPoint

	self flag: #bob.		"maybe Sensor cursorPoint is adequate"
	^Sensor cursorPoint

"==== World cursorPoint sometimes seems to be 0@0 (fake events or World that has yet had no events??)
	^Smalltalk isMorphic ifTrue: [World cursorPoint] ifFalse: [Sensor cursorPoint]
===="