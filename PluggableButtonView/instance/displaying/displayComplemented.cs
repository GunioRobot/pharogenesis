displayComplemented
	"Complement the receiver if it isn't already."

	complemented ifFalse: [
		complemented _ true.
		Display reverse: self insetDisplayBox].
