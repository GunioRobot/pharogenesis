isControlWanted

	"sensor flushKeyboard."
	self viewHasCursor & sensor anyButtonPressed ifFalse: [^ false].
	view askBeforeChanging
		ifTrue: [^ model okToChange]  "ask before changing"
		ifFalse: [^ true].
