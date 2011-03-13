waitForMessage
	"return the next message from the server, waiting if necessary.  Many clients will find this method less convenient than polling on the non-blocking receivedMessagesDo:."
	[
		self receivedMessagesDo: [ :m | ^m ].
		(Delay forMilliseconds: 100) wait.
	] repeat.

