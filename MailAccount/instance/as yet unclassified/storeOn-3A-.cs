storeOn: aStream
	"Don't write passwords to a file."
	| p |
	p _ popPassword.
	self clearPasswords.
	super storeOn: aStream.
	popPassword _ p.