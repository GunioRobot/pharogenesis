peek
	"Answer what would be returned if the message next were sent to the receiver. If the receiver is at the end, answer nil.  "

	| next pos |
	self atEnd ifTrue: [^ nil].
	pos _ self position.
	next _ self next.
	self position: pos.
	^ next.

