initiateSession
	"HELO <SP> <domain> <CRLF>"

	"self checkResponse."
	self sendCommand: 'HELO ' , NetNameResolver localHostName.
	self checkResponse.
