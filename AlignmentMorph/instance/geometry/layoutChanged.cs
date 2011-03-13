layoutChanged

	"invalidate old fullBounds in case we shrink"
	fullBounds ifNotNil: [self invalidRect: fullBounds].

	super layoutChanged.
	layoutNeeded _ true.
