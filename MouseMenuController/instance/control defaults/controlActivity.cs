controlActivity
	"Refer to the comment in Controller|controlActivity."
	| cursorPoint |
	cursorPoint := sensor cursorPoint.
	super controlActivity.
	(cursorPoint = sensor cursorPoint and: [self viewHasCursor])
		ifTrue: 
			[sensor redButtonPressed ifTrue: [^ self redButtonActivity].
			sensor yellowButtonPressed ifTrue: [^ self yellowButtonActivity].
			sensor blueButtonPressed ifTrue: [^ self blueButtonActivity]]