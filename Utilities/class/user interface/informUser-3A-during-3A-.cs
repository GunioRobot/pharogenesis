informUser: aString during: aBlock
	"Put a message above (or below if insufficient room) the cursor.
	 Like informUser:while:, but end when aBlock ends.  "

	(SelectionMenu labels: '') displayAt: Sensor cursorPoint
		withCaption: aString during: [aBlock value]