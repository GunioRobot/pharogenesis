on: eventName send: action
	"Note: We handle more than the standard Morphic events here"
	^self on: eventName sendAll:(Array with: action).