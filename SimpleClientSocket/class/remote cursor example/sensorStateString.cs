sensorStateString
	"SimpleClientSocket sensorStateString"

	| pt buttons s |
	pt _ Sensor cursorPoint.
	buttons _ Sensor primMouseButtons.
	s _ WriteStream on: (String new: 100).
	s nextPutAll: pt x printString.
	s space.
	s nextPutAll: pt y printString.
	s space.
	s nextPutAll: buttons printString.
	^ s contents
