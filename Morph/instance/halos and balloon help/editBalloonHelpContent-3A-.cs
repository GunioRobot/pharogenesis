editBalloonHelpContent: aString
	Cursor normal show.
	FillInTheBlank
		message: ('Edit the balloon help text for ', self externalName) 
		displayAt: Sensor cursorPoint 
		centered: true
		action: [:reply |  (reply size > 0 and: [reply asString ~= self noHelpString]) ifTrue:
		[self setBalloonText: reply]] 
		initialAnswer: aString
		answerHeight: 200
		windowTitle: 'Hit ENTER when done'.
	Cursor blank show