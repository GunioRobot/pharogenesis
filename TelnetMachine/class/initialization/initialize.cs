initialize
	"TelnetMachine initialize"
	WILLChar _ 251 asCharacter.
	WONTChar _ 252 asCharacter.
	DOChar _ 253 asCharacter.
	DONTChar _ 254 asCharacter.
	IAC _ 255 asCharacter.

	OPTEcho _ 1 asCharacter.


	"set of characters that need special processing"
	CSSpecialChars _ CharacterSet 
		with: Character escape 
		with: Character cr
		with: Character lf
		with: Character tab.
	