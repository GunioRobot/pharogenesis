will: optionNo
	"request that we do optionNo"
	self sendChar: IAC.
	self sendChar: WILLChar.
	self sendChar: optionNo asCharacter