standUpWithDuration: duration
	"Rotate the object to align it along its parent's up vector"

	^ self turnTo: #(0 #asIs 0) duration: duration.
