getSMTPResponse
	"wait for an SMTP response, and return the number of the response"
	| line |
	[ line _ self getResponse.
	Transcript show: line.
	(line at: 4) = $- ] whileTrue.

	^(line copyFrom: 1 to: 3) asNumber