controlTerminate 
	"Reverse the feedback displayed by controlInitialize, if any. Perform the button action if necessary."

	view ifNotNil:
		[view triggerOnMouseDown
			ifFalse:
				[shownAsComplemented ifTrue: [view toggleMouseOverFeedback].
				self viewHasCursor ifTrue: [view performAction]]]