retrieveMessage: number
	"retrieve the numbered message"
	| response |

	self sendCommand: 'RETR ', number printString.
	response _ self getResponse.
	self reportToObservers: response.
	(response beginsWith: '+OK') ifFalse: [
		self error: 'error: ', response ].

	^self getMultilineResponse.