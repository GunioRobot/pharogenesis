nextSpecial
	| c |
	c _ self nextChar.
	^MailAddressToken type: c  text: c asString.