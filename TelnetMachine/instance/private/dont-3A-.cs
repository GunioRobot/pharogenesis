dont: optionNo
	"demand that the remote side doesn't do optionNo"
	self sendChar: IAC.
	self sendChar: DONTChar.
	self sendChar: optionNo asCharacter