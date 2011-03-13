isControlActive
	"Answer whether receiver wishes to continue evaluating its controlLoop 
	method. It is sent by Controller|controlLoop in order to determine when 
	the receiver's control loop should terminate, and should be redefined in 
	a subclass if some special condition for terminating the main control loop 
	is needed."

	^ self viewHasCursor
		& sensor blueButtonPressed not
		& sensor yellowButtonPressed not
		"& sensor cmdKeyPressed not"