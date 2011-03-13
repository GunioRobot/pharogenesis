informUser: aString during: aBlock
	"Put a message above (or below if insufficient room) the cursor.
	 Like informUser:while:, but end when aBlock ends.  9/1/96 di"

	(PopUpMenu labels: '') displayAt: Sensor cursorPoint
		withCaption: aString during: [aBlock value]