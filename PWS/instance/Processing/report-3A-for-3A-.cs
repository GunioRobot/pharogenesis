report: msg for: rec
	"Write an error report."

	"msg = 'noAuth' ifTrue: [ ^self ]."
	self log: '*** ', rec asString, ': ', msg.
	[ self reply: ((msg indexOfSubCollection: 'HTTP' startingAt: 1) = 1
		ifTrue: [ msg ] 
		ifFalse: [ 'HTTP/1.0 400 Bad Request', self class crlfcrlf, msg ])]
	 ifError: [ :m :r | ]
