do: optionNo
	"request that the remote side does optionNo"
	self sendChar: IAC.
	self sendChar: DOChar.
	self sendChar: optionNo asCharacter