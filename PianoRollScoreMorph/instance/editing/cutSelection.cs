cutSelection

	selection == nil ifTrue: [^ self].
	self copySelection.
	self deleteSelection