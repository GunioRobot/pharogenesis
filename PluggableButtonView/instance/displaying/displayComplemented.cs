displayComplemented
	"Complement the receiver if it isn't already."

	complemented ifFalse: [
		complemented := true.
		Display reverse: self insetDisplayBox].
