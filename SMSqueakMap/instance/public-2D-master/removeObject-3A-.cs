removeObject: anObject
	"Delete it and log it in the logfile."

	anObject delete.
	self logDelete: anObject.
	^anObject
