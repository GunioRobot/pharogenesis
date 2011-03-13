editBalloonHelpContent: aString

	| reply |
	reply _ FillInTheBlank
		multiLineRequest: ('Edit the balloon help text for ', self externalName)
		centerAt: Sensor cursorPoint
		initialAnswer: aString
		answerHeight: 200.
	(reply size > 0 and: [reply asString ~= self noHelpString])
		ifTrue: [self setBalloonText: reply].
