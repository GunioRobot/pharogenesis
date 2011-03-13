mouseUp: evt

	showSelectionFeedback _ false.
	allButtons ifNil: [^ self].
	allButtons do: [:m |
		(m containsPoint: evt cursorPoint) ifTrue: [m performAction]].
	allButtons _ nil.
	self changed.
