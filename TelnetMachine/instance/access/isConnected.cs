isConnected
	"answer whether we are connected to a remote host"
	^socket ~~ nil and: [ socket isValid and: [ socket isConnected ] ]