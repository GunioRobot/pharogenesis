talkTo
	"talk to some user using 1-to-1 chat messages"
	| user |
	user _ FillInTheBlank request: 'user to talk to'.
	user _ user withBlanksTrimmed.
	user isEmpty ifTrue: [ ^self ].

	IRCDirectMessagesObserver openForConnection: self  talkingTo: user