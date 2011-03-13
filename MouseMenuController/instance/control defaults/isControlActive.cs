isControlActive 
	"Refer to the comment in Controller|isControlActive."

	Sensor blueButtonPressed ifTrue: [^ false].
	^ view containsPoint: sensor cursorPoint