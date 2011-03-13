updateColor: aColor feedbackColor: feedbackColor
	"Set my selected color to the given color if it is different. Give user feedback. Inform the target of the change if the target and selector are not nil." 

	selectedColor = aColor ifTrue: [^ self].  "do nothing if color doesn't change"

	self updateAlpha: aColor alpha.
	originalForm fill: FeedbackBox fillColor: feedbackColor.
	self form: originalForm.
	selectedColor _ aColor.
	updateContinuously ifTrue: [self updateTargetColor].
