serve: aSocket
	"Respond to a request arriving on the given socket and return a string to be entered in the log file."

	| inst |
	inst _ self new.
	[inst initializeFrom: aSocket.
	 inst getReply]
		ifError: [:msg :rec | inst report: msg for: rec].
	aSocket closeAndDestroy: 30.
	^ inst log contents
