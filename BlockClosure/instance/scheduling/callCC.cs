callCC
	"Call with current continuation, ala Scheme.
	Evaluate self against a copy of the sender's call stack, which can be resumed later"

	^ self value: thisContext sender asContinuation