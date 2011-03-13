peek
	"Answer what would be returned if the message next were sent to the receiver. If the receiver is at the end, answer nil.  1/31/96 sw"
	| next |
	self atEnd ifTrue: [^ nil].
	next _ self next.
	self position: self position - 1.
	^ next