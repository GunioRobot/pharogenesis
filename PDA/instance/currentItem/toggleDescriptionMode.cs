toggleDescriptionMode

	self okToChange ifFalse: [^ self].
	viewDescriptionOnly _ viewDescriptionOnly not.
	self changed: #currentItemText