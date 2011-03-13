isControlWanted
	sensor flushKeyboard.
	self viewHasCursor ifFalse: [^ false].
	sensor redButtonPressed ifFalse: [^ false].
	^ model okToChange  "Dont change selection if model is locked"