processIO
	"do as much network IO as is immediately possible"
	
	| amount idx messageText message |

	"do nothing if the socket isn't ready for work"
	(socket isNil or: [socket isValid not or: [ socket isConnected not ]]) ifTrue: [ 
		"Transcript show: 'socket not ready; no IO done'; cr."
		^self ].


	"first do sending"
	[ socket sendDone and: [ sendBuffer isNil not or: [ protocolMessagesToSend size > 0 ] ] ]
	whileTrue: [
		sendBuffer ifNil: [
			protocolMessagesToSend isEmpty ifFalse: [
				sendBuffer _ protocolMessagesToSend removeFirst asString ] ].

		sendBuffer ifNotNil: [
			amount _ socket sendSomeData: sendBuffer.
			sendBuffer _ sendBuffer copyFrom: amount+1 to: sendBuffer size.
			sendBuffer isEmpty ifTrue: [ sendBuffer _ nil ] ].
	].


	"now do receiving"
	[ socket dataAvailable ] whileTrue: [ 
		recieveBuffer _ recieveBuffer, socket getData ].

	"parse as many messages as possible"
	[ idx _ recieveBuffer indexOf: Character lf.  
	  idx > 0 ] whileTrue: [
		messageText _ recieveBuffer copyFrom: 1 to: idx.
		message _ IRCProtocolMessage fromString: messageText.
		
		self processMessage: message.

		recieveBuffer _ recieveBuffer copyFrom: idx+1 to: recieveBuffer size ].
