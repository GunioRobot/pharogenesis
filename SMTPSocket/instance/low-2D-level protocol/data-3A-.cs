data: messageData
	"send the data of a message"
	| cookedLine |

	"inform the server we are sending the message data"
	self sendCommand: 'DATA'.
	self checkSMTPResponse.

	"process the data one line at a time"
	messageData linesDo:  [ :messageLine |
		cookedLine _ messageLine.
		(cookedLine beginsWith: '.') ifTrue: [ 
			"lines beginning with a dot must have the dot doubled"
			cookedLine _ '.', cookedLine ].
		self sendCommand: cookedLine ].

	"inform the server the entire message text has arrived"
	self sendCommand: '.'.
	self checkSMTPResponse.