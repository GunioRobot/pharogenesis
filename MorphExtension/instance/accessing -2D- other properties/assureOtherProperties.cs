assureOtherProperties
	"creates an otherProperties for the receiver if needed"
	self hasOtherProperties
		ifFalse: [self initializeOtherProperties].
	^ self otherProperties