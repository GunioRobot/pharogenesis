talkTo
	"open a window for talking to the selected user"
	| user |
	user _ self selectedUser.
	user ifNil: [ ^self ].

	^IRCDirectMessagesObserver openForConnection: channel connection   talkingTo: user