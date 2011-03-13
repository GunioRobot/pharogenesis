controlActivity 
	"Refer to the comment in Controller|controlActivity."

	| cursorPoint |
	cursorPoint _ Sensor cursorPoint.
	super controlActivity.
	cursorPoint = Sensor cursorPoint
	ifTrue: [ sensor redButtonPressed & self viewHasCursor 
				ifTrue: [^self redButtonActivity].
			sensor yellowButtonPressed & self viewHasCursor 
				ifTrue: [^self yellowButtonActivity].
			sensor blueButtonPressed & self viewHasCursor 
				ifTrue: [^self blueButtonActivity]]