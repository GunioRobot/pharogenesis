deleteMessage: num
	"delete the numbered message"
	self sendCommand: 'DELE ', num printString.
	self reportToObservers: self getResponse.
