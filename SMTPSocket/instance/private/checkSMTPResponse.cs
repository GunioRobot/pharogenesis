checkSMTPResponse
	"get an SMTP response, and check that it's in the 200's or 300's.  If it's not, close the socket and issue an error:"
	(#(2 3) includes: self getSMTPResponse // 100) ifFalse: [
		self close.
		self error: 'server responded with an error' ].