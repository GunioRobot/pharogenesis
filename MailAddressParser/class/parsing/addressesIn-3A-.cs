addressesIn: aString
	"return a collection of the bare addresses listed in aString"
	| tokens |
	tokens _ MailAddressTokenizer tokensIn: aString.
	^(self new initialize: tokens) grabAddresses