primitiveRelinquishProcessor
	"Relinquish the processor for up to the given number of microseconds. The exact behavior of this primitive is platform dependent."

	| microSecs |
	microSecs _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		self ioRelinquishProcessorForMicroseconds: microSecs.
		self pop: 1].  "microSecs; leave rcvr on stack"
