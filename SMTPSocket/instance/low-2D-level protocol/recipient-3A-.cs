recipient: aRecipient
	"specify a recipient for the message.  aRecipient should be a bare email address"
	self sendCommand: 'RCPT TO: <', aRecipient, '>'.
	self checkSMTPResponse.