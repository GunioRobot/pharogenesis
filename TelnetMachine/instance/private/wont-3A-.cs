wont: optionNo
	"demand that we won't do optionNo"
	self sendChar: IAC.
	self sendChar: WONTChar.
	self sendChar: optionNo asCharacter