controlTerminate 
	"Reverse the feedback displayed by controlInitialize, if any. Perform the button action if necessary."

	view triggerOnMouseDown ifFalse: [
		view toggleMouseOverFeedback.
		self viewHasCursor ifTrue: [view performAction]].
