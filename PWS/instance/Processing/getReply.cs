getReply
  "Generate the reply."

	| key |
	Transcript show: ('Now serving:' , url printString, ' from ', peerName) ; cr.
	[key := message at: 1] ifError: [:r :c | key := nil].
	(ActionTable includesKey: key asLowercase)
	ifTrue: ["Transcript show: 'Serving from action ', key ; cr."
		(ActionTable at: key asLowercase) process: self]
	ifFalse: ["Transcript show: 'Serving from action default' ; cr."
		(ActionTable at: 'default') process: self].
