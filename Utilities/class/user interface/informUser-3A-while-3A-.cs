informUser: aString while: aBlock
	"Put a message above (or below if insufficient room) the cursor.
	 1/22/96 sw"

	"Utilities informUser: 'How do you do' while: [Sensor anyButtonPressed not]"
	| cp  |
	cp _ Sensor cursorPoint.
	(PopUpMenu labels: '') displayAt: cp
				withCaption: aString
				during: [[aBlock value] whileTrue]