informUser: aString while: aBlock
	"Put a message above (or below if insufficient room) the cursor.
	 "

	"Utilities informUser: 'How do you do' while: [Sensor anyButtonPressed not]"
	| cp  |
	cp _ Sensor cursorPoint.
	(SelectionMenu labels: '') displayAt: cp
				withCaption: aString
				during: [[aBlock value] whileTrue]