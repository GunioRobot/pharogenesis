displayNormal
	"Complement the receiver if its mode is 'complemented'."

	complemented ifTrue: [
		complemented := false.
		Display reverse: self insetDisplayBox].
