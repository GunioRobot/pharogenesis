scroll
	"Check to see whether the user wishes to jump, scroll up, or scroll down."
	| savedCursor |
	savedCursor _ sensor currentCursor.
			[self scrollBarContainsCursor]
				whileTrue: 
					[self interActivityPause.
					sensor cursorPoint x <= self downLine
								ifTrue: [self scrollDown]
								ifFalse: [sensor cursorPoint x <= self upLine
										ifTrue: [self scrollAbsolute]
										ifFalse: [sensor cursorPoint x <= self yellowLine
												ifTrue: [self scrollUp]
												ifFalse: [sensor cursorPoint x <= scrollBar right
														ifTrue: "Might not be, with touch pen"
														[self changeCursor: Cursor menu.
														sensor anyButtonPressed 
														ifTrue: [self changeCursor: savedCursor. 
																self anyButtonActivity]]]]]].
	savedCursor show