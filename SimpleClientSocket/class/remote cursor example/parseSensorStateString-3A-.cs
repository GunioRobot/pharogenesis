parseSensorStateString: aString
	"Parse the given sensor stat string and return an array whose first element is the cursor point and whose second is the cursor button state."
	"SimpleClientSocket parseSensorStateString: SimpleClientSocket sensorStateString"

	| s buttons x y |
	s _ ReadStream on: aString.
	x _ Integer readFrom: s.
	s skipSeparators.
	y _ Integer readFrom: s.
	s skipSeparators.
	buttons _ Integer readFrom: s.
	^ Array with: x@y with: buttons
