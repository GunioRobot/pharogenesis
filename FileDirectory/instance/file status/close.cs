close
	"Close the receiver if it is not already closed."

	closed ifFalse: [self release]