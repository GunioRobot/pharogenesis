peek
	"Answer what would be returned if the message next were sent to the receiver. If the receiver is at the end, answer nil.  "

	| next save |
	self atEnd ifTrue: [^ nil].
	save _ converter saveStateOf: self.
	next _ self next.
	converter restoreStateOf: self with: save.
	^ next.

