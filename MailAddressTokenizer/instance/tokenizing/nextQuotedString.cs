nextQuotedString
	| res c |
	res _ WriteStream on: String new.
	res nextPut: self nextChar.   "record the starting quote"
	[ self atEndOfChars ] whileFalse: [
		c _ self nextChar.
		c = $\ ifTrue: [
			res nextPut: c.
			res nextPut: self nextChar ]
		ifFalse: [
			c = $" ifTrue: [
				res nextPut: c.
				^MailAddressToken type: #QuotedString  text: res contents ]
			ifFalse: [
				res nextPut: c ] ] ].

	"hmm, never saw the final quote mark"
	^MailAddressToken type: #QuotedString  text: (res contents, '"')