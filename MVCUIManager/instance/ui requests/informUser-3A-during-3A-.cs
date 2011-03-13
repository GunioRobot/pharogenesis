informUser: aString during: aBlock
	"Display a message above (or below if insufficient room) the cursor 
	during execution of the given block.
		UIManager default informUser: 'Just a sec!' during: [(Delay forSeconds: 1) wait].
	"
	(SelectionMenu labels: '')
		displayAt: Sensor cursorPoint
		withCaption: aString
		during: [aBlock value]