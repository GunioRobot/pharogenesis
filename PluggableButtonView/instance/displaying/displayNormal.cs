displayNormal
	"Complement the receiver if its mode is 'complemented'."

	complemented ifTrue: [
		complemented _ false.
		Display reverse: self insetDisplayBox].
