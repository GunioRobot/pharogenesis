pop
	"Answer the top of the receiver's stack and remove the top of the stack."
	| val |
	val _ self at: stackp.
	self stackp: stackp - 1.
	^ val