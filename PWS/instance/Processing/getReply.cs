getReply
	"Generate a reply based on the action selected by the first word of the URL."

	| key |
	message size > 0
		ifTrue: [key _ (message at: 1) asLowercase]
		ifFalse: [key _ 'default'].
	(ActionTable includesKey: key) ifFalse: [key _ 'default'].

	"Transcript show: ('Request: ' , url printString, ' from: ', peerName, ' action: ', key) ; cr."
	(ActionTable at: key) process: self.
