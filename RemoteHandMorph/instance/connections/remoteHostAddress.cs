remoteHostAddress
	"Return the address of the remote host or zero if not connected."

	(socket ~~ nil and: [socket isUnconnectedOrInvalid not])
		ifTrue: [^ socket remoteAddress]
		ifFalse: [^ 0].
