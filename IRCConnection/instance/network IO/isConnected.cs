isConnected
	"whether we are currently connected"
	^socket ~~ nil  and: [ socket isConnected ]