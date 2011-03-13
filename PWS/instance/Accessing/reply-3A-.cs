reply: aString
	"Send back part of the reply. If we are in roll forward mode just do nothing."

	((connection ~~ nil) and: [connection isConnected])
		ifTrue: [connection sendData: aString].
