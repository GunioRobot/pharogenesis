report: msg for: rec
	"Write an error report."

	| s |
	self log: '*** ', rec asString, ': ', msg.
	s _ (msg indexOfSubCollection: 'HTTP' startingAt: 1) = 1
		ifTrue: [msg]
		ifFalse: ['HTTP/1.0 400 Bad Request', self class crlfcrlf, msg].
	[self reply: s] ifError: [:m :r | "ignore errors"].
