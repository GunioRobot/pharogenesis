quit
	"QUIT <CRLF>"

	self sendCommand: 'QUIT'.
	self checkResponse.