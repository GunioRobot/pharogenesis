controlInitialize 
	"Provide feedback indicating that button has been entered with the mouse down. If triggerOnMouseDown is true, then do the button action on mouse down--and don't bother with the feedback since the action happens immediately."

	sensor anyButtonPressed ifFalse: [^ self].
	view triggerOnMouseDown
		ifTrue: [sensor yellowButtonPressed 
			ifTrue: [self yellowButtonActivity]
			ifFalse: [view performAction]]
		ifFalse: [view toggleMouseOverFeedback.
				 shownAsComplemented := true]