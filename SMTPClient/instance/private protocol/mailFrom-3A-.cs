mailFrom: fromAddress
	" MAIL <SP> FROM:<reverse-path> <CRLF>"

	| address |
	address _ (MailAddressParser addressesIn: fromAddress) first.

	self sendCommand: 'MAIL FROM: <', address, '>'.
	self checkResponse.