privateOwner: newOwner
	"Nil the container when text gets extracted"
	super privateOwner: newOwner.
	container ifNotNil: [self setContainer: nil]