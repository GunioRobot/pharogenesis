mouseUp: evt

	showSelectionFeedback _ false.
	borderColor isColor ifFalse:[borderColor _ #raised].
	allButtons ifNil: [^ self].
	allButtons do: [:m |
		(m containsPoint: evt cursorPoint) ifTrue: [m performAction]].
	allButtons _ nil.
	self changed.
